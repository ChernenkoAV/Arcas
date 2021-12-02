using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Arcas.BL.TFS
{
    public static class AssemblyResolver
    {
        public static void AddResolver()
        {
            AppDomain.CurrentDomain.AssemblyResolve += currentDomain_AssemblyResolve;
        }

        public static void RemoveResolver()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= currentDomain_AssemblyResolve;
        }

        private static Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);

            var asly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().ToString() == assemblyName.ToString());

            if (asly != null)
                return asly;

            if (args.RequestingAssembly == null)
                return null;

            var assemblyFile = assemblyName.Name + ".dll";

            var location = args.RequestingAssembly.Location ?? Assembly.GetEntryAssembly().Location;
            var requestPath = Path.GetDirectoryName(location);

            var path = Path.Combine(requestPath, assemblyFile);

            if (!File.Exists(path))
            {
                var targetculture = assemblyName.CultureInfo.TwoLetterISOLanguageName;
                if (targetculture == null)
                    throw new FileLoadException($"Not compute culture for {args.Name}");
                path = Path.Combine(Path.Combine(requestPath, targetculture), assemblyFile);
            }

            return File.Exists(path)
                ? Assembly.LoadFile(path)
                : null;
        }
    }
}
