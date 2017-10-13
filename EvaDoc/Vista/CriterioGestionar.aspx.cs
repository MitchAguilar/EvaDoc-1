using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class CriterioGestionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = new Criterio().ConsutarCriterioGeneral();
            GridView1.Visible = true;
            GridView1.DataBind();
        }

        protected void ButtonRegistrar_Click(object sender, EventArgs e)
        {
            Criterio CR = new Criterio("",TextBoxCriterio.Text,TextBoxPorcentaje.Text);
            if (CR.RegistrarCriterio(CR))
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-success";
                Alert.Text = "Registro Exitoso.";
                Response.Redirect("CriterioGestionar.aspx");
            }
            else
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-danger";
                Alert.Text = "Los datos registrado no son los adecuados.";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("CriterioModificar.aspx?id=" + GridView1.SelectedRow.Cells[1].Text + "&detalle=" + GridView1.SelectedRow.Cells[2].Text + "&procentaje=" + GridView1.SelectedRow.Cells[3].Text);  
        }
    }
}