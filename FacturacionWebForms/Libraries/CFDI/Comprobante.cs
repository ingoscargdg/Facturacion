using System.Collections.Generic;

namespace Libraries.SAT.CFDI
{
    public class Comprobante
    {
        private string ArchivoCer;

        private string ArchivoKey;

        private string PassKey;

        public string Serie { get; set; }

        public string Folio { get; set; }

        public string Fecha { get; set; }

        //public string Sello { get; set; }

        //public string NoCertificado { get; set; }

        //public string Certificado { get; set; }

        public string FormaPago { get; set; }

        public string CondicionesPago { get; set; }

        public string TipoComprobante { get; set; }

        public string MetodoPago { get; set; }

        public string LugarExpedicion { get; set; }

        public string NumCtaPago { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Descuento { get; set; }

        public string MotivoDescuento { get; set; }

        public decimal TipoCambio { get; set; }

        public decimal Total { get; set; }

        public string FolioFiscalOrig { get; set; }

        public string SerieFiscarlOrig { get; set; }

        public string FechaFolioFiscalOrig { get; set; }

        public string MontoFolioFiscalOrig { get; set; }

        private Emisor emisor;

        private Receptor receptor;

        private List<Concepto> Conceptos;

        private List<Impuestos> impuestos;

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
            this.emisor = emisor;
        }

        public void addReceptor(Receptor receptor)
        {
            this.receptor = receptor;
        }

        public void addConceptos(List<Concepto> conceptos)
        {
            this.Conceptos = conceptos;
        }

        public void addConcepto(Concepto concepto)
        {
            this.Conceptos.Add(concepto);
        }

        public void addImpuestos(Impuestos impuestos)
        {
            this.impuestos.Add(impuestos);
        }

        public void Timbrar()
        {
           
        }
    }
}
