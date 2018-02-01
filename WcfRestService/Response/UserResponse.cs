using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRestService.Response
{
    [DataContract]
    public class UserResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string Message { get; set; }

    }
}