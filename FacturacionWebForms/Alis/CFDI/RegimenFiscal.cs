using System.Xml.Serialization;

namespace Alis.SAT.CFDI
{
    public class RegimenFiscal
    {
        [XmlAttribute]
        public string Regimen { get; set; }
    }
}
