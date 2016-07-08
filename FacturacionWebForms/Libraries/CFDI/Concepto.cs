using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Libraries.SAT.CFDI
{
    public class Concepto: IDeserializationCallback
    {
        [XmlAttribute]
        public decimal cantidad { get; set; }

        [XmlAttribute]
        public string unidad { get; set; }

        [XmlAttribute]
        public string noIdentificacion { get; set; }

        [XmlAttribute]
        public string descripcion { get; set; }

        [XmlAttribute]
        public decimal valorUnitario { get; set; }

        private decimal importe;

        public void OnDeserialization(object sender)
        {
            importe= this.valorUnitario * this.cantidad;
        }
    }
}
