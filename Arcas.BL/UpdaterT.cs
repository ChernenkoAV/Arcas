using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoUpdaterDotNET;
using Cav;

namespace Arcas.Update
{
    public static class Updater
    {
        public static void UpdateApp()
        {
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Synchronous = true;
            AutoUpdater.Mandatory = true;
            AutoUpdater.UpdateMode = Mode.ForcedDownload;
            AutoUpdater.RunUpdateAsAdmin = false;

            UpdateFromGitHub("ChernenkoAV", "Arcas"
#if DEBUG
            , true
#else
            , false
#endif

            );
        }

        public static string CurrentVersion() =>
            Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            DomainContext.CurrentVersion.ToString();

        public static void UpdateFromGitHub(
            string user,
            string repo,
            Boolean? prerelease = null)
        {
            if (user.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(user));
            if (repo.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(repo));

            var relsUri = new Uri($"https://api.github.com/repos/{user}/{repo}/releases");

            string contendGitHub;

            using (var client = new MyWebClient())
            {
                client.Headers.Add("Accept", "application/vnd.github.v3+json");
                client.Headers.Add("User-Agent", Assembly.GetExecutingAssembly().FullName);
                contendGitHub = client.DownloadString(relsUri);
            }

            if (contendGitHub.IsNullOrWhiteSpace())
                throw new InvalidOperationException($"content on {relsUri} is empty");

            var releases = contendGitHub.JsonDeserealize<List<GitHubReleases>>();

            var lastRel = releases
                .Where(x => !prerelease.HasValue || x.prerelease == prerelease)
                .OrderByDescending(x => x.name)
                .FirstOrDefault();

            if (new[] { lastRel?.name, CurrentVersion() }.OrderByDescending(x => x).FirstOrDefault() == CurrentVersion())
                return;

            var asset = lastRel.assets.FirstOrDefault(x => x.name.EndsWith(".zip"));

            if (asset == null)
                return;

            AutoUpdater.ParseUpdateInfoEvent += x => uInf(x, asset);
            AutoUpdater.Start();
        }

        private static void uInf(ParseUpdateInfoEventArgs args, asset relData)
        {
            args.UpdateInfo.CurrentVersion = Assembly.GetEntryAssembly().GetName().Version.ToString() + "1";
            args.UpdateInfo.DownloadURL = relData.browser_download_url;
        }

#pragma warning disable IDE1006 // Стили именования
        internal class asset
        {
            public string name { get; set; }
            public string browser_download_url { get; set; }
        }

        internal class GitHubReleases
        {

            public bool prerelease { get; set; }
            public DateTime published_at { get; set; }
            public Uri html_url { get; set; }
            public String name { get; set; }

            public List<asset> assets { get; set; } = new List<asset>();
        }
#pragma warning restore IDE1006 // Стили именования
    }
}
