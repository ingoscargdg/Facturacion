
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Libraries.SAT.CFDI
{
    public class Impuestos
    {

        [XmlAttribute]
        public decimal totalImpuestosRetenidos;

        [XmlAttribute]
        public decimal totalImpuestosTrasladados;

        public List<Retencion> Retenciones;

        public List<Traslado> Traslados;

        public void AddTrasladados(Traslado traslado)
        {
            if (this.Traslados == null)
            {
                this.Traslados = new List<Traslado>();
            }
            this.Traslados.Add( traslado);
        }

        public void AddRetenidos(Retencion retencion)
        {
            if(this.Retenciones == null)
            {
                this.Retenciones = new List<Retencion>();
            }
            this.Retenciones.Add(retencion);
        }


    }
}
