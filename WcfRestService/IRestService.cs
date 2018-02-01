using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfRestService.Response;
using WcfRestService.Request;

namespace WcfRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestService" in both code and config file together.
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Xml,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Xml,
                    UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "json/{id}")]
        string JSONData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Xml,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Xml,
                    UriTemplate = "xmlDet")]
        DataInXml XmlDetails();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "JsonDet")]
        DataInJson JsonDetails();


        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "List")]
        List<UserDetail> GetAllUser();

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "User/{id}")]
        UserDetail GetUserById(string id);



        [OperationContract]
        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "Create")]
        UserResponse Create(UserDetail user);

        [OperationContract]
        [WebInvoke(Method = "PUT",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "Edit/{id}")]
        UserResponse Update(string id,UserDetail user);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "Delete/{id}")]
        UserResponse Delete(string id, UserDetail user);

        //[OperationContract]
        // [WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    RequestFormat = WebMessageFormat.Json,
        //    UriTemplate = "")]



        
    }


}
