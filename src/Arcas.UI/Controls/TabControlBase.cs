using System;
using System.Windows.Forms;
using Arcas.BL;

namespace Arcas.Controls
{
    public class TabControlBase : UserControl
    {
        public TabControlBase() =>
            Name = GetType().FullName;

        public virtual void RefreshTab() { }
        public virtual void CloseApp() { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        public event ProgressStateDelegat StateProgress;

        protected void SetSateProgress(String message) =>
            StateProgress?.Invoke(message);
    }
}
