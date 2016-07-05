using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.Invoice;
using BL;

namespace Facturacion
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var eInvoice = new Invoice { CondicionesPago = txtNameCustomer.Text };
            bInvoice.save(eInvoice);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}