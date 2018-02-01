using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRestService.Request
{  
    [DataContract]
    public class UserRequest
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string City { get; set; }
    }
}