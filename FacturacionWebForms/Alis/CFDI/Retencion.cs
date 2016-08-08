
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Alis.SAT.CFDI
{
    public class Retencion
    {
        [XmlAttribute]
        public string impuesto { get; set; }

        [XmlAttribute]
        public decimal importe { get; set; }
    }
}
