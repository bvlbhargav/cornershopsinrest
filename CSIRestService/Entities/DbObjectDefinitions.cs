using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace CSIRestService.Entities
{
    public class Entity
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
    
    
    public class ServiceRequest
    {
        public ObjectId Id { get; set; }
        public ServiceRequestMetaData RequestMetaInfo { get; set; }
        public DateTime RequestTime { get; set; }
    }
}