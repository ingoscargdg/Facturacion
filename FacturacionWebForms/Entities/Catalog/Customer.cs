using System;
using Entities.Common;

namespace Entities.Catalog
{
    public class Customer
    {
        public Int32 Id { get; set; }
        public string Code { get; set; }
        public string BusinessName { get; set; }
        public string ComercialName { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
