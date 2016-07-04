using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DL;

namespace BL
{
    public static class bInvoice
    {
        public static void save(eInvoice eInvoice)
        {
            Invoice.Create();
        }
    }
}
