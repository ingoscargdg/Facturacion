using System.Xml.Serialization;

namespace Libraries.SAT.CFDI
{
    public class Receptor
    {
        [XmlAttribute]
        public string rfc { get; set; }

        [XmlAttribute]
        public string nombre { get; set; }

        public DomicilioFiscal Domicilio { get; set; }
    }
}
