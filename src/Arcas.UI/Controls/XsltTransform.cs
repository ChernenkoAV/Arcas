using System;
using System.Windows.Forms;
using System.Xml.Linq;
using Cav;

namespace Arcas.Controls
{
    public partial class XsltTransform : TabControlBase
    {
        public XsltTransform()
        {
            InitializeComponent();
            Text = "Xslt - преобразование";

            splitContainer1_DoubleClick(null, null);
            splitContainer2_DoubleClick(null, null);
            splitContainer3_DoubleClick(null, null);

        }

        private void splitContainer1_DoubleClick(object sender, EventArgs e) => splitContainer1.SplitterDistance = splitContainer1.Width / 2;

        private void splitContainer2_DoubleClick(object sender, EventArgs e) => splitContainer2.SplitterDistance = splitContainer1.Height / 2;

        private void splitContainer3_DoubleClick(object sender, EventArgs e) => splitContainer3.SplitterDistance = splitContainer3.Height / 2;

        private void tbTransform_Click(object sender, EventArgs e)
        {
            try
            {
                tbResTransform.Text = String.Empty;

                var sxml = XDocument.Parse(tbSourseXML.Text);
                tbResTransform.Text = XDocument.Parse(sxml.XMLTransform(tbXsltText.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Expand());

            }
        }

        private void btSourseXMLClear_Click(object sender, EventArgs e) => tbSourseXML.Text = null;

        private void btXsltTextClear_Click(object sender, EventArgs e) => tbXsltText.Text = null;

        private void btSourseXMLFormat_Click(object sender, EventArgs e)
        {
            try
            {
                tbSourseXML.Text = XDocument.Parse(tbSourseXML.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Expand());
            }
        }

        private void btXsltTextFormat_Click(object sender, EventArgs e)
        {
            try
            {
                tbXsltText.Text = XDocument.Parse(tbXsltText.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Expand());
            }
        }
    }
}
