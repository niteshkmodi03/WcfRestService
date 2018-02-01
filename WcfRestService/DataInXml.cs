using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRestService
{
    [DataContract]
    public class DataInXml
    {
         [DataMember]
        public int id { get; set; }

        [DataMember]
        public string Name { get; set; }
    
    }
}