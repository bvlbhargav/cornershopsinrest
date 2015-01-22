using CSIRestService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace CSIRestService.Extensions
{
    public class RequestSkimmer
    {
        public static ServiceRequestMetaData GetRequestMessageProperties(OperationContext currentOperationContext)
        {
            var context = currentOperationContext;
            var messageProperties = context.IncomingMessageProperties;
            var endpointProperty =
              messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            return endpointProperty != null ? new ServiceRequestMetaData() {RequestIp = endpointProperty.Address,RequestPort = endpointProperty.Port} : null;
        }

        public static void GetRequestHeaders()
        {
        }
    }
}