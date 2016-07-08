﻿
namespace Libraries.SAT.CFDI
{
    interface IDireccion 
    {
        string calle { get; set; }

        string noExterior { get; set; }

        string noInterior { get; set; }

        string colonia { get; set; }

        string localidad { get; set; }

        string municipio { get; set; }

        string estado { get; set; }

        string pais { get; set; }

        string codigoPostal { get; set; }

       
    }
}
