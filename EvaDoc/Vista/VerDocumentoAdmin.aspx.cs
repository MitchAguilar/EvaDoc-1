using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class VerDocumentoAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = new Documento().ConsultarDocumentoTitulo();
            GridView1.Visible = true;
            GridView1.DataBind();
            GridView2.DataSource = new Resultado().ConsultarResultadoGeneral();
            GridView2.Visible = true;
            GridView2.DataBind();
        }
    }
}