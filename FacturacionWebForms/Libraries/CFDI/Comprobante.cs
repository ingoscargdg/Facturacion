using System.Data;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Libraries.SAT.CFDI
{
    public class Comprobante
    {
        [XmlAttribute]
        public string version { get; set; }

        [XmlAttribute]
        public string serie { get; set; }

        [XmlAttribute]
        public string folio { get; set; }

        [XmlAttribute]
        public string fecha { get; set; }

        [XmlAttribute]
        public string sello { get; set; }

        [XmlAttribute]
        public string formaDePago { get; set; }

        [XmlAttribute]
        public string noCertificado { get; set; }

        [XmlAttribute]
        public string certificado { get; set; }

        [XmlAttribute]
        public string condicionesDePago { get; set; }

        [XmlAttribute]
        public decimal Subtotal { get; set; }

        [XmlAttribute]
        public decimal Descuento { get; set; }

        [XmlAttribute]
        public string MotivoDescuento { get; set; }

        [XmlAttribute]
        public decimal TipoCambio { get; set; }

        [XmlAttribute]
        public string Moneda { get; set; }

        [XmlAttribute]
        public decimal Total { get; set; }

        [XmlAttribute]
        public string TipoDeComprobante { get; set; }

        [XmlAttribute]
        public string MetodoDePago { get; set; }

        [XmlAttribute]
        public string LugarExpedicion { get; set; }

        [XmlAttribute]
        public string NumCtaPago { get; set; }

        [XmlAttribute]
        public string FolioFiscalOrig { get; set; }

        [XmlAttribute]
        public string SerieFiscarlOrig { get; set; }

        [XmlAttribute]
        public string FechaFolioFiscalOrig { get; set; }

        [XmlAttribute]
        public string MontoFolioFiscalOrig { get; set; }

        public Emisor Emisor;

        public Receptor Receptor;

        public List<Concepto> Conceptos;

        public Impuestos Impuestos;

        private string ArchivoCer;

        private string ArchivoKey;

        private string PassKey;

        public Comprobante()
        {

        }
        ///<summary>
        ///<param name="ArchivoCer">Path del Archivo .cer</param>
        ///<param name="ArchivoKey">Path del Archivo .key</param>
        ///<param name="PassKey">Contraseña para el archivo .key</param>
        ///</summary>
        public Comprobante(string ArchivoCer,string ArchivoKey,string PassKey)
        {
            this.ArchivoCer = ArchivoCer;
            this.ArchivoKey = ArchivoKey;
            this.PassKey = PassKey;
        }

        public void addEmisor(Emisor emisor)
        {
            this.Emisor = emisor;
        }

        public void addReceptor(Receptor receptor)
        {
            this.Receptor = receptor;
        }

        public void addConceptos(List<Concepto> conceptos)
        {
            this.Conceptos = conceptos;
        }

        public void addConcepto(Concepto concepto)
        {
            if(this.Conceptos == null)
            {
                this.Conceptos = new List<Concepto>();
            }

            this.Conceptos.Add(concepto);
        }

        public void addImpuestos(Impuestos impuestos)
        {
            this.Impuestos = impuestos;
        }

    }
}
