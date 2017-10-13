using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class VerDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario USU = (Usuario)Session["Usuario"];
                GridView1.DataSource = new Documento().ConsultarDocumentoSubido(USU.IDUSUARIO);
                GridView1.Visible = true;
                GridView1.DataBind();

                GridView2.DataSource = new Resultado().ConsultarResultados(USU.IDUSUARIO);
                GridView2.Visible = true;
                GridView2.DataBind();
            }
            catch 
            {
                Response.Redirect("../Index.aspx");
            }
            
        }
    }
}