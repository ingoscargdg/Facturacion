using System.Xml.Serialization;

namespace Alis.SAT.CFDI
{
    public class Traslado
    {
        [XmlAttribute]
        public string impuesto { get; set; }

        [XmlAttribute]
        public decimal tasa { get; set; }

        [XmlAttribute]
        public decimal importe { get; set; }
    }
}
