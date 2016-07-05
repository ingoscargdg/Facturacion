using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Entities.Invoice;
using System.Configuration;

namespace DL
{
    public static class InvoiceDL
    {
        public static Invoice Create(Invoice eInvoice)
        {
            MongoClient client = new MongoClient(ConfigurationManager.AppSettings["connMongoDb"]);
            var db = client.GetDatabase(ConfigurationManager.AppSettings["dbMongo"]);
            var Invoice = db.GetCollection<Invoice>("Invoices");
            Invoice.InsertOne(eInvoice);
            return eInvoice;
        }
    }
}
