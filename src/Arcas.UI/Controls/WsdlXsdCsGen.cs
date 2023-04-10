using System;
using System.Diagnostics;
using System.Linq;
using Arcas.BL;
using Cav;

namespace Arcas.Controls
{
    public partial class WsdlXsdCsGen : TabControlBase
    {
        public WsdlXsdCsGen(
            CsGenFromWsdlXsd csGenFromWsdlXsd)
        {
            InitializeComponent();
            Text = "Генерация C# из WSDL и XSD";

            this.csGenFromWsdlXsd = csGenFromWsdlXsd;

            tbWsdlUri.Text = Config.Instance.WsdlXsdGenSetting.Wsdl_PathToWsdl;
            tbSaveWsdlTo.Text = Config.Instance.WsdlXsdGenSetting.Wsdl_PathToSaveFile;
            tbTargetNamespaceWsdl.Text = Config.Instance.WsdlXsdGenSetting.Wsdl_Namespace;

            tbXsdUri.Text = Config.Instance.WsdlXsdGenSetting.Xsd_PathToXsd;
            tbSaveXsdTo.Text = Config.Instance.WsdlXsdGenSetting.Xsd_PathToSaveFile;
            tbTargetNamespaceXsd.Text = Config.Instance.WsdlXsdGenSetting.Xsd_Namespace;
        }

        private CsGenFromWsdlXsd csGenFromWsdlXsd;

        private void btFromFile_Click(object sender, EventArgs e)
        {
            var pathfile = Dialogs.FileBrowser(
                 owner: this,
                 title: "Файл с WSDL",
                 filter: "*.wsdl|*.wsdl",
                 restoreDirectory: true).FirstOrDefault();

            if (pathfile.IsNullOrWhiteSpace())
                return;

            tbWsdlUri.Text = pathfile;
        }

        private void btSelFileForSave_Click(object sender, EventArgs e)
        {
            var pathfile = Dialogs.SaveFile(
                owner: this,
                title: "Сохранить код в файл",
                filter: "C# файл| *.cs",
                fileName: tbSaveWsdlTo.Text.GetNullIfIsNullOrWhiteSpace(),
                defaultExt: "cs",
                restoreDirectory: true);

            if (pathfile.IsNullOrWhiteSpace())
                return;

            tbSaveWsdlTo.Text = pathfile;
        }

        private WsdlXsdGenSettingT createSetting() =>
            new WsdlXsdGenSettingT()
            {
                Wsdl_PathToWsdl = tbWsdlUri.Text,
                Wsdl_PathToSaveFile = tbSaveWsdlTo.Text,
                Wsdl_Namespace = tbTargetNamespaceWsdl.Text,

                Xsd_PathToXsd = tbXsdUri.Text,
                Xsd_PathToSaveFile = tbSaveXsdTo.Text,
                Xsd_Namespace = tbTargetNamespaceXsd.Text,
            };

        private void btGenerateCsFromWsdl_Click(object sender, EventArgs e)
        {
            try
            {

                Config.Instance.WsdlXsdGenSetting = createSetting();
                Config.Instance.Save();

                var msg = csGenFromWsdlXsd.GenFromWsdl(
                    uri: tbWsdlUri.Text,
                    createAsync: chbCreateAsuncMethod.Checked,
                    targetNamespace: tbTargetNamespaceWsdl.Text,
                    outputFile: tbSaveWsdlTo.Text,
                    generateClient: rbGenClient.Checked);

                if (!msg.IsNullOrWhiteSpace())
                    Dialogs.Error(this, msg);
                else
                {
                    if (Dialogs.QuestionOKCancel(this, "Готово. Открыть файл?"))
                        Process.Start(tbSaveWsdlTo.Text);
                }
            }
            catch (Exception ex)
            {
                Dialogs.Error(this, ex.Expand());
            }
        }

        private void btGenerateCsFromXsd_Click(object sender, EventArgs e)
        {
            try
            {

                Config.Instance.WsdlXsdGenSetting = createSetting();
                Config.Instance.Save();

                var msg = csGenFromWsdlXsd.GenFromXsd(
                    uri: tbXsdUri.Text,
                    targetNamespace: tbTargetNamespaceXsd.Text,
                    outputFile: tbSaveXsdTo.Text);

                if (!msg.IsNullOrWhiteSpace())
                    Dialogs.Error(this, msg);
                else
                {
                    if (Dialogs.QuestionOKCancel(this, "Готово. Открыть файл?"))
                        Process.Start(tbSaveXsdTo.Text);
                }
            }
            catch (Exception ex)
            {
                Dialogs.Error(this, ex.Expand());
            }
        }

        private void btSelFileForSaveXsd_Click(object sender, EventArgs e)
        {
            var pathfile = Dialogs.SaveFile(
                   owner: this,
                   title: "Сохранить код в файл",
                   filter: "C# файл| *.cs",
                   fileName: tbSaveXsdTo.Text.GetNullIfIsNullOrWhiteSpace(),
                   defaultExt: "cs",
                   restoreDirectory: true);

            if (pathfile.IsNullOrWhiteSpace())
                return;

            tbSaveXsdTo.Text = pathfile;
        }

        private void btSetXsdFile_Click(object sender, EventArgs e)
        {
            var pathfile = Dialogs.FileBrowser(
                    owner: this,
                    title: "Файл с XSD",
                    filter: "*.xsd|*.xsd",
                    restoreDirectory: true).FirstOrDefault();

            if (pathfile.IsNullOrWhiteSpace())
                return;

            tbXsdUri.Text = pathfile;
        }
    }
}
