using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.CFDI
{
    class DomicilioFiscal : IDireccion
    {
        string IDireccion.Calle { get; set; }

        string IDireccion.NoExterior { get; set; }

        string IDireccion.NoInterior { get; set; }

        string IDireccion.Colonia { get; set; }

        string IDireccion.Localidad { get; set; }

        string IDireccion.Municipio { get; set; }

        string IDireccion.Estado { get; set; }

        string IDireccion.Pais { get; set; }

        string IDireccion.CP { get; set; }
    }
}
