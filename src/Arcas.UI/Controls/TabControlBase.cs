using System;
using System.Windows.Forms;
using Arcas.BL;

namespace Arcas.Controls;

public class TabControlBase : UserControl
{
    public TabControlBase() =>
        Name = GetType().FullName;

    public virtual void RefreshTab() { }
    public virtual void CloseApp() { }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
#pragma warning disable CA1003 // Используйте экземпляры обработчика универсальных событий
    public event ProgressStateDelegat StateProgress;
#pragma warning restore CA1003 // Используйте экземпляры обработчика универсальных событий

    protected void SetSateProgress(String message) =>
        StateProgress?.Invoke(message);
}
