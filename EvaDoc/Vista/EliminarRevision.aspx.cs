using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class EliminarRevision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new Resultado().EliminarResultado(Convert.ToString(Request.QueryString["id"]));
            Response.Redirect("VerDocumento.aspx");
        }
    }
}