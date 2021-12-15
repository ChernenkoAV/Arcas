using System;
using System.Collections.Generic;

namespace Arcas.BL.IbmMq
{
    public class MqMessageGeneric
    {
        public MqMessageGeneric()
        {
            AddedProperties = new Dictionary<string, string>();
        }
        public Dictionary<String, String> AddedProperties { get; private set; }
        public string Body { get; set; }
        public byte[] MessageID { get; set; }
        public DateTime? PutDateTime { get; set; }
    }
}