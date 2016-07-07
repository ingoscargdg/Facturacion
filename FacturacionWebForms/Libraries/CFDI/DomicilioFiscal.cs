using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.SAT.CFDI
{
    public class DomicilioFiscal : IDireccion
    {
        public string Calle { get; set; }

        public string NoExterior { get; set; }

        public string NoInterior { get; set; }

        public string Colonia { get; set; }

        public string Localidad { get; set; }

        public string Municipio { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public string CP { get; set; }
    }
}
