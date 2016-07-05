using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Invoice;
using DL;

namespace BL
{
    public static class bInvoice
    {
        public static Invoice save(Invoice eInvoice)
        {
            return InvoiceDL.Create(eInvoice);
        }
    }
}
