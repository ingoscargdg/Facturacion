using System.Xml.Serialization;

namespace Libraries.SAT.CFDI
{
    public class RegimenFiscal
    {
        [XmlAttribute]
        public string Regimen { get; set; }
    }
}
