using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Entities.Common;

namespace Entities.Invoice
{
    public class Invoice
    {
        public ObjectId _id { get; set; }
        public string Serie { get; set; }
        public Int32 Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Sello { get; set; }
        public string FormaPago { get; set; }
        public string CondicionesPago { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public string MotivoDescuento { get; set; }
        public decimal Paridad { get; set; }
        public Int16 Moneda { get; set; }
        public decimal Total { get; set; }
        public string TipoComprobante { get; set; }
        public string MetodoPago { get; set; }
        public Address LugarExpedicion { get; set; }
        public string NumCuentaPago { get; set; }

    }
}
