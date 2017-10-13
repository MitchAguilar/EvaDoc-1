using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class EliminarDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (new Documento().EliminarDocumento(Convert.ToString(Request.QueryString["id"])))
                {
                    arleta.InnerHtml = "<div class='col-md-12 text-center alert alert-success' ><spam>El Documento fue eliminado</spam></div>";
                }
                else
                {
                    arleta.InnerHtml = "<div class='col-md-12 text-center alert alert-danger' ><spam>Documento no se pudo eliminara por que ya fue asignado a un evaluador</spam></div>";
                }
            }
            catch
            {
                Response.Redirect("VerDocumento.aspx");
            }

        }
    }
}