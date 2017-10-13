using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class CriterioModificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Criterio CRI = new Criterio().ConsutarCriterio(Convert.ToString(Request.QueryString["id"]));
                TextBoxId.Text = CRI.IDCRITERIO;
                TextBoxCriterio.Text = CRI.CRI_DETALLE;
                TextBoxPorcentaje.Text = CRI.CRI_PORCENTAJE;
            }
        }

        protected void ButtonRegistrar_Click(object sender, EventArgs e)
        {
            Criterio CRI = new Criterio(TextBoxId.Text,TextBoxCriterio.Text,TextBoxPorcentaje.Text);
            if (CRI.ModificarCriterio(CRI))
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-success";
                Alert.Text = "Modificar Exitoso.";
            }
            else
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-danger";
                Alert.Text = "Los datos registrado no son los adecuados.";
            }
        }
    }
}