using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSIRestService.Entities
{
    public class ServiceRequestMetaData
    {
        public string RequestIp { get; set; }
        public string RequestServiceUrl { get; set; }
        public int RequestPort { get; set; }
    }

    public class ServiceRequestHeaders
    {
        public string ApiVersion { get; set; }
    }

    
}