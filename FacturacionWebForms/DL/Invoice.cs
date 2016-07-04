using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Entities;
using System.Configuration;

namespace DL
{
    public static class Invoice
    {
        public static void Create()
        {
            var a = new eInvoice { Name="Oscar"};
            MongoClient client = new MongoClient(ConfigurationManager.AppSettings["connMongoDb"]);
            var db = client.GetDatabase(ConfigurationManager.AppSettings["dbMongo"]);
            var Invoice = db.GetCollection<eInvoice>("Invoices");
            Invoice.InsertOne(a);
        }
    }
}
