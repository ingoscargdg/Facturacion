using System;
using Alis.SAT.CFDI;
using Entities.Invoice;
using DL;
using System.Xml;

namespace BL
{
    public static class bInvoice
    {
        public static Invoice save(Invoice eInvoice)
        {
            string certificado = "C:\\Users\\oscar\\Desktop\\Archivos\\AAQM610917QJA.cer";
            string key = "C:\\Users\\oscar\\Desktop\\Archivos\\AAQM610917QJA_s.key";
            string archivoXslt = @"cadenaoriginal_3_2.xslt";
            string pass = "12345678a";

            Comprobante comprobante = new Comprobante();
            comprobante.version = "3.2";
            comprobante.serie = "A";
            comprobante.folio = "1";
            comprobante.formaDePago = "PAGO EN UNA SOLA EXHIBICION";
            comprobante.noCertificado = "0000000000000000000";
            comprobante.fecha = "2016-06-13T10:53:39";
            comprobante.Subtotal = 100;
            comprobante.TipoCambio = Convert.ToDecimal(1.0);
            comprobante.Moneda = "MXN";
            comprobante.Total = 116;
            comprobante.MetodoDePago = "EFECTIVO";
            comprobante.TipoDeComprobante = "ingreso";
            comprobante.LugarExpedicion = "AGUASCALIENTES, AGUASCALIENTES";
            comprobante.NumCtaPago = "No Identificado";

            Emisor emisor = new Emisor();
            emisor.rfc = "AAQM610917QJA";
            emisor.nombre = "JOSE MANUEL MARTINEZ";

            emisor.DomicilioFiscal = new DomicilioFiscal();
            emisor.DomicilioFiscal.calle = "Miguel Hidalgo";
            emisor.DomicilioFiscal.noInterior = "209";
            emisor.DomicilioFiscal.colonia = "Vicente Guerrero";
            emisor.DomicilioFiscal.localidad = "Tampico";
            emisor.DomicilioFiscal.municipio = "Tampico";
            emisor.DomicilioFiscal.estado = "Tamaulipas";
            emisor.DomicilioFiscal.pais = "Mexico";
            emisor.DomicilioFiscal.codigoPostal = "89000";

            emisor.ExpedidoEn = new ExpedidoEn();
            emisor.ExpedidoEn.calle = "Miguel Hidalgo";
            emisor.ExpedidoEn.noInterior = "209";
            emisor.ExpedidoEn.colonia = "Vicente Guerrero";
            emisor.ExpedidoEn.localidad = "Tampico";
            emisor.ExpedidoEn.municipio = "Tampico";
            emisor.ExpedidoEn.estado = "Tamaulipas";
            emisor.ExpedidoEn.pais = "Mexico";
            emisor.ExpedidoEn.codigoPostal = "89000";
            RegimenFiscal RegimenFiscal = new RegimenFiscal();
            RegimenFiscal.Regimen = "Régimen de actividades empresariales y profesionales";
            emisor.RegimenFiscal = RegimenFiscal;

            comprobante.addEmisor(emisor);

            Receptor receptor = new Receptor();
            receptor.rfc = "SAA791115JM0";
            receptor.nombre = "SERVICIOS ASESORES S.A. DE C.V.";

            receptor.Domicilio = new DomicilioFiscal();
            receptor.Domicilio.calle = "Miguel Hidalgo";
            receptor.Domicilio.colonia = "Parque Industrial";
            receptor.Domicilio.localidad = "EXPORTEC 1";
            receptor.Domicilio.municipio = "TOLUCA";
            receptor.Domicilio.estado = "MEXICO";
            receptor.Domicilio.pais = "MEXICO";
            receptor.Domicilio.codigoPostal = "50223";

            comprobante.addReceptor(receptor);

            Concepto concepto = new Concepto();
            concepto.cantidad = 1;
            concepto.unidad = "PZA";
            concepto.noIdentificacion = "RAM8GB";
            concepto.descripcion = "RAM 8GB";
            concepto.valorUnitario = Convert.ToDecimal(345.50);
            comprobante.addConcepto(concepto);

            Traslado iva = new Traslado();
            iva.impuesto = "IVA";
            iva.tasa = 16;
            iva.importe = Convert.ToDecimal(55.28);
            Impuestos Impuestos = new Impuestos();
            Impuestos.totalImpuestosTrasladados = Convert.ToDecimal(55.28);
            Impuestos.AddTrasladados(iva);
            comprobante.addImpuestos(Impuestos);

            string xmlNotSigning = Digital.serializarXml(comprobante); //Serializar sin sello
            string cadenaoriginal = Alis.SAT.Common.GetOriginalChain(xmlNotSigning, archivoXslt); //cadena original

            comprobante.noCertificado = Alis.SAT.Common.GetNumberCertificate(certificado);
            comprobante.certificado = Alis.SAT.Common.GetStringCertificate(certificado);
            comprobante.sello = Alis.SAT.Common.SignOriginalChain(key, pass, cadenaoriginal);

            string xmlSigning = Digital.serializarXml(comprobante); //Serializar sin sello

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlSigning);

            Alis.SAT.Common.timbrar(xmlSigning);
           return InvoiceDL.Create(eInvoice);
        }

       


    }
}
