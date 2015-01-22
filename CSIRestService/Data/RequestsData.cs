using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CSIRestService.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace CSIRestService.Data
{
    
    public class RequestsData
    {
        readonly string _connectionString = ConfigurationManager.AppSettings["DbConnectionString"].ToString();


        public string InsertRequestRecord(ServiceRequestMetaData objServiceRequestMetaData)
        {
            var client = new MongoClient(_connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("cornershopsin"); // "cornershopsin" is the name of the database
            var collection = database.GetCollection<ServiceRequest>("Requests");

            var serviceRequest = new ServiceRequest {RequestMetaInfo = objServiceRequestMetaData, RequestTime = DateTime.UtcNow};
            collection.Insert(serviceRequest);
            return serviceRequest.Id.ToString();
        }

        public ServiceRequest GetRequestRecord(MongoDB.Bson.ObjectId serviceRequestId)
        {
            var client = new MongoClient(_connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("cornershopsin"); // "cornershopsin" is the name of the database
            var collection = database.GetCollection<ServiceRequest>("Requests");

            var query = Query<ServiceRequest>.EQ(e => e.Id, serviceRequestId);
            return collection.FindOne(query);
        }

        //public ServiceRequest GetRequestRecords()
        //{
        //    var client = new MongoClient(_connectionString);
        //    var server = client.GetServer();
        //    var database = server.GetDatabase("cornershopsin"); // "cornershopsin" is the name of the database
        //    var collection = database.GetCollection<ServiceRequest>("Requests");

        //    var query = from e in collection.AsQueryable<ServiceRequest>() ;
        //    BsonClassMap.RegisterClassMap<ServiceRequest>
        //    return collection.Find(query);
        //}
    }
}