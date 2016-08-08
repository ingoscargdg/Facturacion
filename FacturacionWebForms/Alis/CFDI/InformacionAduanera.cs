using System.Xml.Serialization;

namespace Alis.SAT.CFDI
{
    public class InformacionAduanera
    {
        [XmlAttribute]
        public string numero { get; set; }

        [XmlAttribute]
        public string fecha { get; set; }

        [XmlAttribute]
        public string aduana { get; set; }
    }
}
