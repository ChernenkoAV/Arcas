using System;
using System.Collections.Generic;
using System.Text;
using Cav;

namespace Arcas.BL.IbmMq
{
    public class MqBL
    {
        private void chekSettings(MqSettingT sets)
        {
            if (sets.Host.IsNullOrWhiteSpace())
                throw new ArgumentException("Не указан хост");

            if (sets.QueueName.IsNullOrWhiteSpace())
                throw new ArgumentException("Не указано имя очереди");

            if (sets.ChannelName.IsNullOrWhiteSpace())
                throw new ArgumentException(" Не указано имя канала");
        }

        public string Send(
            MqSettingT sets,
            String body,
            Dictionary<String, string> propMessage
            )
        {
            chekSettings(sets);

            MqMessageGeneric msg = new MqMessageGeneric();
            msg.Body = body.GetNullIfIsNullOrWhiteSpace();
            foreach (var item in propMessage)
                msg.AddedProperties.Add(item.Key, item.Value);

            if (msg.Body.IsNullOrWhiteSpace())
                throw new ArgumentException("Пустое тело сообщения");

            var clnt = IBMMqClient.CreateClient(sets);
            clnt.Send(msg);

            StringBuilder sb = new StringBuilder(msg.MessageID.Length * 2);
            foreach (var b in msg.MessageID)
                sb.AppendFormat("{0:X2}", b);

            return sb.ToString();
        }

        public MqMessageGeneric Get(
            MqSettingT sets,
            Boolean rolbackGet)
        {
            chekSettings(sets);

            IBMMqClient clnt = null;

            try
            {
                clnt = IBMMqClient.CreateClient(sets);
                var msg = clnt.GetNextMessage();

                if (rolbackGet)
                    clnt.RollbackGet();
                else
                    clnt.CommitGet();

                return msg;
            }
            catch
            {
                clnt.RollbackGet();
                throw;
            }
        }
    }
}
