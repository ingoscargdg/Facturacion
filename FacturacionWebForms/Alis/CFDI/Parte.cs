using System.Xml.Serialization;

namespace Alis.SAT.CFDI
{
    public class Parte
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
            this.importe = this.valorUnitario * this.cantidad;
        }

        public InformacionAduanera InformacionAduanera;
    }
}
