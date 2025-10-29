using System;
using Arcas.Update;

namespace Arcas;

internal static class Program
{
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        AppContext.SetSwitch("Switch.System.Security.Cryptography.Xml.UseInsecureHashAlgorithms", true);
        AppContext.SetSwitch("Switch.System.Security.Cryptography.Pkcs.UseInsecureHashAlgorithms", true);

        Updater.UpdateApp();

        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
#pragma warning disable CA2000 // Ликвидировать объекты перед потерей области
        System.Windows.Forms.Application.Run(new ArcasMain());
#pragma warning restore CA2000 // Ликвидировать объекты перед потерей области
    }
}
