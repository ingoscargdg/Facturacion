using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries.SAT.CFDI;
using Entities.Invoice;
using DL;

namespace BL
{
    public static class bInvoice
    {
        public static Invoice save(Invoice eInvoice)
        {
            string certificado = "C:\\Users\\oscar\\Desktop\\Archivos\\AAQM610917QJA.cer";
            string key = "C:\\Users\\oscar\\Desktop\\Archivos\\AAQM610917QJA_s.key";
            string pass = "12345678a";

            Comprobante comprobante = new Comprobante(certificado, key, pass);

            Emisor emisor = new Emisor();
            emisor.RFC = "AAQM610917QJA";
            emisor.Nombre ="JOSE MANUEL MARTINEZ";

            emisor.DomicilioFiscal.Calle = "Miguel Hidalgo";
            emisor.DomicilioFiscal.NoInterior = "209";
            emisor.DomicilioFiscal.Colonia = "Vicente Guerrero";
            emisor.DomicilioFiscal.Localidad = "Tampico";
            emisor.DomicilioFiscal.Municipio = "Tampico";
            emisor.DomicilioFiscal.Estado = "Tamaulipas";
            emisor.DomicilioFiscal.Pais = "Mexico";
            emisor.DomicilioFiscal.CP = "89000";

            emisor.ExpedidoEn.Calle = "Miguel Hidalgo";
            emisor.ExpedidoEn.NoInterior = "209";
            emisor.ExpedidoEn.Colonia = "Vicente Guerrero";
            emisor.ExpedidoEn.Localidad = "Tampico";
            emisor.ExpedidoEn.Municipio = "Tampico";
            emisor.ExpedidoEn.Estado = "Tamaulipas";
            emisor.ExpedidoEn.Pais = "Mexico";
            emisor.ExpedidoEn.CP = "89000";

            emisor.RegimenFiscal = "Régimen de actividades empresariales y profesionales";

            comprobante.addEmisor(emisor);

            Receptor receptor = new Receptor();
            receptor.RFC = "GIC900115IN7";
            receptor.Nombre = "GRUPO INDUSTRIAL CREYSI S.A. DE C.V.";

            receptor.DomicilioFiscal.Calle = "Miguel Hidalgo";
            receptor.DomicilioFiscal.Colonia = "Parque Industrial";
            receptor.DomicilioFiscal.Localidad = "EXPORTEC 1";
            receptor.DomicilioFiscal.Municipio = "TOLUCA";
            receptor.DomicilioFiscal.Estado = "MEXICO";
            receptor.DomicilioFiscal.Pais = "MEXICO";
            receptor.DomicilioFiscal.CP = "50223";

            comprobante.addReceptor(receptor);

            Concepto concepto = new Concepto();
            concepto.Cantidad = 1;
            concepto.Unidad = "PZA";
            concepto.NoIdentificacion = "RAM8GB";
            concepto.Descripcion = "RAM 8GB";
            concepto.ValorUnitario = Convert.ToDecimal(345.50);

            comprobante.addConcepto(concepto);

            Trasladados iva = new Trasladados();
            iva.Impuesto = "IVA";
            iva.Tasa = 16;
            iva.Importe =Convert.ToDecimal( 55.28);
            //comprobante.addImpuestos(iva);
            return InvoiceDL.Create(eInvoice);
        }
    }
}
