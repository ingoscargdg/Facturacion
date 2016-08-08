using System.Xml.Serialization;

namespace Alis.SAT.CFDI
{
    public class CuentaPredial
    {
        [XmlAttribute]
        public string numero { get; set; }
    }
}
