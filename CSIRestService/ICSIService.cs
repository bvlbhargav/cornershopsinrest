using System.ServiceModel;
using System.ServiceModel.Web;
using CSIRestService.Entities;

namespace CSIRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICSIService" in both code and config file together.
    [ServiceContract]
    public interface ICsiService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",ResponseFormat = WebMessageFormat.Json,BodyStyle = WebMessageBodyStyle.Bare,UriTemplate = "welcome")]
        string Welcome();


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,RequestFormat = WebMessageFormat.Json,UriTemplate = "request")]
        string InserRequest();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "request/{id}")]
        ServiceRequest GetRequestById(string id);
    }
}
