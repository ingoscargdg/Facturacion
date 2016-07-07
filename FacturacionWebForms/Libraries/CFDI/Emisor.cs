using System;

namespace Libraries.SAT.CFDI
{
    public class Emisor
    {
        public string RFC { get; set; }

        public string Nombre { get; set; }

        public DomicilioFiscal DomicilioFiscal { get; set; }

        public ExpedidoEn ExpedidoEn { get; set; }

        public string RegimenFiscal { get; set; }
    }
}
