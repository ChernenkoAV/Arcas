using System;
using System.Diagnostics;
using System.Linq;
using Arcas.BL;
using Cav;

namespace Arcas.Controls;

public partial class WsdlXsdCsGen : TabControlBase
{
    public WsdlXsdCsGen(
        CsGenFromWsdlXsd csGenFromWsdlXsd)
    {
        InitializeComponent();
        Text = "Генерация C# из WSDL и XSD";

        this.csGenFromWsdlXsd = csGenFromWsdlXsd;

        tbWsdlUri.Text = Config.Instance.WsdlXsdGenSetting.WsdlPathToWsdl;
        tbSaveWsdlTo.Text = Config.Instance.WsdlXsdGenSetting.WsdlPathToSaveFile;
        tbTargetNamespaceWsdl.Text = Config.Instance.WsdlXsdGenSetting.WsdlNamespace;

        tbXsdUri.Text = Config.Instance.WsdlXsdGenSetting.XsdPathToXsd;
        tbSaveXsdTo.Text = Config.Instance.WsdlXsdGenSetting.XsdPathToSaveFile;
        tbTargetNamespaceXsd.Text = Config.Instance.WsdlXsdGenSetting.XsdNamespace;
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
        new()
        {
            WsdlPathToWsdl = tbWsdlUri.Text,
            WsdlPathToSaveFile = tbSaveWsdlTo.Text,
            WsdlNamespace = tbTargetNamespaceWsdl.Text,

            XsdPathToXsd = tbXsdUri.Text,
            XsdPathToSaveFile = tbSaveXsdTo.Text,
            XsdNamespace = tbTargetNamespaceXsd.Text,
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
