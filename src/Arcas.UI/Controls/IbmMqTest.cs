using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Arcas.BL.IbmMq;
using Cav;

namespace Arcas.Controls
{
    public partial class IbmMqTest : TabControlBase
    {
        public IbmMqTest(
            MqBL mqBL)
        {
            InitializeComponent();
            Text = "Взаимодействие с IBM Mq";
            dgvAddProperties.AutoGenerateColumns = false;
            dgvAddProperties.DataSource = addpoplist;
            APKeyCol.DataPropertyName = nameof(KeyValuePair<string, string>.Key);
            APValueCol.DataPropertyName = nameof(KeyValuePair<string, string>.Value);

            var st = Config.Instance.MqSets;

            tbHost.Text = st.Host;
            tbManagerName.Text = st.ManagerName;
            tbChannelName.Text = st.ChannelName;
            tbQueueName.Text = st.QueueName;
            tbUser.Text = st.UserName;
            tbPass.Text = st.Password;

            this.mqBL = mqBL;
        }

        private BindingList<KeyValuePair<String, String>> addpoplist = new BindingList<KeyValuePair<string, string>>();
        private MqBL mqBL;

        private void btSend_Click(object sender, EventArgs e)
        {
            tbMessageID.Text = null;
            tbPutDate.Text = null;

            try
            {
                var sets = createMqSetting();

                tbMessageID.Text = mqBL.Send(
                    sets,
                    tbBodyMessage.Text.GetNullIfIsNullOrWhiteSpace(),
                    addpoplist.ToDictionary(x => x.Key, x => x.Value)
                    );

                Config.Instance.MqSets = sets;
                Config.Instance.Save();
            }
            catch (Exception ex)
            {
                Dialogs.ErrorF(this, ex.Expand());
            }
        }

        private MqSettingT createMqSetting() =>
            new MqSettingT
            {
                Host = tbHost.Text.GetNullIfIsNullOrWhiteSpace(),
                ManagerName = tbManagerName.Text.GetNullIfIsNullOrWhiteSpace(),
                ChannelName = tbChannelName.Text.GetNullIfIsNullOrWhiteSpace(),
                QueueName = tbQueueName.Text.GetNullIfIsNullOrWhiteSpace(),
                UserName = tbUser.Text.GetNullIfIsNullOrWhiteSpace(),
                Password = tbPass.Text.GetNullIfIsNullOrWhiteSpace()
            };

        private void btGetMessage_Click(object sender, EventArgs e)
        {
            tbMessageID.Text = null;
            tbPutDate.Text = null;
            tbBodyMessage.Text = null;

            var sets = createMqSetting();

            try
            {
                var msg = mqBL.Get(sets, chbRollbakGet.Checked);

                if (msg == null)
                {
                    Dialogs.InformationF(this, "Сообщений нет");
                    msg = new MqMessageGeneric();
                }

                addpoplist.Clear();
                foreach (var item in msg.AddedProperties)
                    addpoplist.Add(item);

                tbMessageID.Text = msg.MessageID.JoinValuesToString(distinct: false, format: "{0:X2}");

                if (msg.PutDateTime.HasValue)
                    tbPutDate.Text = msg.PutDateTime.Value.ToString("dd.MM.yyyy HH:mm:ss");

                tbBodyMessage.Text = msg.Body;

                Config.Instance.MqSets = sets;
                Config.Instance.Save();
            }
            catch (Exception ex)
            {
                Dialogs.ErrorF(this, ex.Expand());
            }
        }

        private string fillAddProp(String xml)
        {
            addpoplist.Clear();
            var xl = XDocument.Parse(xml);

            if (xl.Root.Name.LocalName == "Message")
            {
                addpoplist.Add(new KeyValuePair<string, string>("Method", "SendRequest"));

                var enoNode = xl.Root.Name.Namespace + "ServiceTypeCode";

                var sn = xl.Descendants(enoNode).FirstOrDefault();
                if (sn == null)
                    throw new Exception("Не найден элемент ServiceTypeCode");

                addpoplist.Add(new KeyValuePair<string, string>("ServiceTypeCode", sn.Value));
            }

            if (xl.Root.Name.LocalName == "StatusMessage")
                addpoplist.Add(new KeyValuePair<string, string>("Method", "SetFilesAndStatus"));

            return xl.ToString();
        }

        private void btSendFromFile_Click(object sender, EventArgs e)
        {
            var files = Dialogs.FileBrowser(
            Owner: this,
            Title: "Выбор файлов с XML сообщений",
            Multiselect: true,
            CheckFileExists: true);

            foreach (var file in files)
                try
                {
                    tbMessageID.Text = null;
                    tbPutDate.Text = null;
                    tbBodyMessage.Text = File.ReadAllText(file);
                    fillAddProp(tbBodyMessage.Text);

                    var sets = createMqSetting();

                    tbMessageID.Text = mqBL.Send(
                        sets,
                        tbBodyMessage.Text.GetNullIfIsNullOrWhiteSpace(),
                        addpoplist.ToDictionary(x => x.Key, x => x.Value)
                        );

                    Config.Instance.MqSets = sets;
                    Config.Instance.Save();

                }
                catch (Exception ex)
                {
                    Dialogs.ErrorF(this, ex.Expand());
                }
        }

        private void tbBodyMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fillAddProp(tbBodyMessage.Text);
            }
            catch { }
        }
    }
}
