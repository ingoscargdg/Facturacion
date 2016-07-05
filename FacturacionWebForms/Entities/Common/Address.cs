using System;

namespace Entities.Common
{
    public class Address:ICloneable
    {
        public string Street { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Colony { get; set; }
        public string Locality { get; set; }
        public string Reference { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public object Clone()
        {
            var Address = new Address
            {
                Street = this.Street,
                NoExterior = this.NoExterior,
                NoInterior = this.NoInterior,
                Colony = this.Colony,
                Locality = this.Locality,
                Reference = this.Reference,
                City = this.City,
                StateProvince = this.StateProvince,
                Country = this.Country,
                PostalCode = this.PostalCode
            };
            return Address;
        }
    }
}
