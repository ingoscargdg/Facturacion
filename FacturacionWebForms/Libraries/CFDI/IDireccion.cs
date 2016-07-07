
namespace Libraries.SAT.CFDI
{
    interface IDireccion 
    {
        string Calle { get; set; }

        string NoExterior { get; set; }

        string NoInterior { get; set; }

        string Colonia { get; set; }

        string Localidad { get; set; }

        string Municipio { get; set; }

        string Estado { get; set; }

        string Pais { get; set; }

        string CP { get; set; }

       
    }
}
