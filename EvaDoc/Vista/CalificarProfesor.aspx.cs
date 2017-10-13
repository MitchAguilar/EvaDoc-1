using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class CalificarProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = new Documento().ConsultarDocumentoTitulo();
            GridView1.Visible = true;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("DarNota.aspx?id=" + GridView1.SelectedRow.Cells[1].Text + "&Titulo=" + GridView1.SelectedRow.Cells[2].Text);
        }
    }
}