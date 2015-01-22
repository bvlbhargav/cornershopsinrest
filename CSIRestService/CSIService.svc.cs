using System;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using CSIRestService.Data;
using CSIRestService.Extensions;
using MongoDB.Bson;

namespace CSIRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CSIService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CSIService.svc or CSIService.svc.cs at the Solution Explorer and start debugging.
    // ReSharper disable once InconsistentNaming
    public class CSIService : ICsiService
    {
        public string Welcome()
        {
            RequestSkimmer.GetRequestMessageProperties(OperationContext.Current);
            return "Hi Welcome to Cornershops.in Service Level.Welcome Request made at " +
                   DateTime.UtcNow.ToString(CultureInfo.InvariantCulture) + " UTC.Thank You";
        }


        public string InserRequest()
        {
           return new RequestsData().InsertRequestRecord(RequestSkimmer.GetRequestMessageProperties(OperationContext.Current));
        }

        public Entities.ServiceRequest GetRequestById(string id)
        {
            return new RequestsData().GetRequestRecord(ObjectId.Parse(id));
        }
    }
}
