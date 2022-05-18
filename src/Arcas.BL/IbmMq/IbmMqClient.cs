using System;
using System.Collections;
using System.Text;
using IBM.WMQ;

namespace Arcas.BL.IbmMq
{
    public class IBMMqClient : IDisposable
    {
        private IBMMqClient() { }

        private string host;
        private string managerName;
        private string channelName;
        private string queueName;
        private string userName;
        private string password;

        private MQQueueManager mqManager = null;
        private MQMessage message = null;

        /// <summary>
        /// Создание клиента к MQ 
        /// </summary>
        /// <param name="mqSetting">Настройки очереди</param>
        /// <returns></returns>
        public static IBMMqClient CreateClient(MqSettingT mqSetting) =>
            new IBMMqClient()
            {
                host = mqSetting.Host,
                managerName = mqSetting.ManagerName,
                channelName = mqSetting.ChannelName,
                queueName = mqSetting.QueueName,
                userName = mqSetting.UserName,
                password = mqSetting.Password
            };

        private MQQueueManager createManager()
        {
            var properties = new Hashtable
            {
                { MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED },
                { MQC.CONNECTION_NAME_PROPERTY, host },
                { MQC.CHANNEL_PROPERTY, channelName }
            };
            if (!string.IsNullOrEmpty(userName))
                properties.Add(MQC.USER_ID_PROPERTY, userName);
            if (!string.IsNullOrEmpty(password))
                properties.Add(MQC.PASSWORD_PROPERTY, password);
            properties.Add(MQC.CONNECT_OPTIONS_PROPERTY, MQC.MQCNO_RECONNECT);

            return new MQQueueManager(managerName, properties);
        }

        /// <summary>
        /// Посыл
        /// </summary>
        public void Send(MqMessageGeneric mqMessage)
        {
            var qname = queueName;

            if (String.IsNullOrWhiteSpace(qname))
                throw new ArgumentNullException("Не определено имя очереди");

            try
            {
                message = new MQMessage
                {
                    Persistence = MQC.MQPER_PERSISTENT,
                    Format = MQC.MQFMT_STRING,
                    CharacterSet = MQC.CODESET_UTF
                };

                foreach (var prop in mqMessage.AddedProperties)
                    message.SetStringProperty(prop.Key, prop.Value);

                message.Write(Encoding.UTF8.GetBytes(mqMessage.Body));

                sendMqMessage(qname);
                mqMessage.MessageID = message.MessageId;
                message = null;
            }
            catch (MQException mqex)
            {
                message = null;
                throw new InvalidOperationException(String.Format("MQ {0}", mqex.Message));
            }
            catch
            {
                throw;
            }
        }
        private void sendMqMessage(String queueName)
        {
            using (var qm = createManager())
            using (var q = qm.AccessQueue(queueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING))
            {
                q.Put(message);
                message.ClearMessage();
                q.Close();
            }
        }

        public MqMessageGeneric GetNextMessage()
        {
            MqMessageGeneric res = null;

            var qname = queueName;

            if (String.IsNullOrWhiteSpace(qname))
                throw new ArgumentNullException("Не определено имя очереди");

            var getMessageOptions = new MQGetMessageOptions
            {
                Options = MQC.MQGMO_WAIT + MQC.MQGMO_SYNCPOINT,
                WaitInterval = 100  // 1 seconds wait​
            };

            try
            {
                if (mqManager == null)
                    mqManager = createManager();

                message = new MQMessage();

                using (var queue = mqManager.AccessQueue(queueName, MQC.MQOO_INQUIRE))
                    if (queue.CurrentDepth == 0)
                        return res;

                using (var q = mqManager.AccessQueue(qname, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING))

                    q.Get(message, getMessageOptions);

                res = new MqMessageGeneric
                {
                    Body = Encoding.UTF8.GetString(message.ReadBytes(message.MessageLength)),
                    MessageID = message.MessageId,
                    PutDateTime = message.PutDateTime
                };

                var inames = message.GetPropertyNames("%");
                if (inames != null)
                    while (inames.MoveNext())
                    {
                        var name = inames.Current.ToString();
                        if (name.ToLower().Contains("jms") ||
                            name.ToLower().Contains("mcd"))
                            continue;
                        res.AddedProperties.Add(name, message.GetStringProperty(name));
                    }
            }
            catch (MQException mqex)
            {
                RollbackGet();
                message = null;
                return mqex.ReasonCode == 2033 && mqex.CompCode == 2
                    ? (MqMessageGeneric)null
                    : throw new InvalidOperationException(String.Format("MQ {0}", mqex.Message));
            }
            catch
            {
                RollbackGet();
                throw;
            }

            return res;
        }

        public void RollbackGet()
        {
            if (mqManager != null)
                mqManager.Backout();
        }

        public void CommitGet()
        {
            if (mqManager != null)
                mqManager.Commit();
        }

        #region Члены IDisposable

        public void Dispose()
        {
            if (mqManager != null && mqManager.IsConnected)
                mqManager.Disconnect();
            if (mqManager != null)
                ((IDisposable)mqManager).Dispose();
            mqManager = null;
            message = null;
        }

        #endregion
    }
}
