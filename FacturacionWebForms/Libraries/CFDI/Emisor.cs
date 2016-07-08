using System.Xml.Serialization;

namespace Libraries.SAT.CFDI
{
    public class Emisor
    {
        [XmlAttribute]
        public string rfc { get; set; }

        [XmlAttribute]
        public string nombre { get; set; }

        public DomicilioFiscal DomicilioFiscal { get; set; }

        public ExpedidoEn ExpedidoEn { get; set; }

        public RegimenFiscal RegimenFiscal { get; set; }
    }
}
