using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Cav;

namespace Arcas.BL.TFS
{
    public static class AssemblyResolver
    {
        private static Lazy<string> vsDirs = new Lazy<string>(() =>
        {
            var vsdirs = Directory.EnumerateDirectories(@"C:\Program Files (x86)", "Microsoft Visual Studi*", SearchOption.TopDirectoryOnly).ToList();
            var teDirs = vsdirs
                .SelectMany(x => Directory.GetFiles(x, "Microsoft.TeamFoundation.VersionControl.Controls.dll", SearchOption.AllDirectories))
                .ToList();

            if (!teDirs.Any())
                throw new InvalidOperationException("Не найдено расширение 'Team Explorer' в Visual Studio");

            var pathTfsdll = teDirs.OrderBy(x => x).Last();

            return Path.GetDirectoryName(pathTfsdll);
        }, LazyThreadSafetyMode.ExecutionAndPublication);

        private static bool resolverAdded = false;
        public static void AddResolver()
        {
            if (resolverAdded)
                return;

            AppDomain.CurrentDomain.AssemblyResolve += currentDomain_AssemblyResolve;

            resolverAdded = true;
        }

        public static void RemoveResolver()
        {
            if (!resolverAdded)
                return;

            AppDomain.CurrentDomain.AssemblyResolve -= currentDomain_AssemblyResolve;

            resolverAdded = false;
        }

        private static Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);

            var asly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().ToString() == assemblyName.ToString());

            if (asly != null)
                return asly;

            var assemblyFile = assemblyName.Name + ".dll";

            string localiunAss = null;

            if (!(args.RequestingAssembly?.Location).IsNullOrWhiteSpace())
            {
                localiunAss = Path.Combine(Path.GetDirectoryName(args.RequestingAssembly.Location), assemblyFile);
                if (File.Exists(localiunAss))
                    return Assembly.LoadFrom(localiunAss);
            }

            localiunAss = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), assemblyFile);
            if (File.Exists(localiunAss))
                return Assembly.LoadFrom(localiunAss);

            var path = vsDirs.Value;
            var targetculture = assemblyName.CultureInfo.TwoLetterISOLanguageName;
            if (targetculture != null && targetculture != "iv")
                path = Path.Combine(path, targetculture);

            var tgtAss = Path.Combine(path, assemblyFile);

            if (File.Exists(tgtAss))
                asly = Assembly.LoadFrom(tgtAss);

            return asly;
        }
    }
}
