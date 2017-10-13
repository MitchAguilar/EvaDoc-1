using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
	public partial class DarNota : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                if (!IsPostBack)
                {
                    TextBoxId.Text = Convert.ToString(Request.QueryString["id"]);
                    TextBoxTitulo.Text = Convert.ToString(Request.QueryString["Titulo"]);
                } 
            }
            catch 
            {
                Response.Redirect("CalificarProfesor.aspx");
            }
		}

        protected void ButtonActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                double nota = Convert.ToDouble(TextBoxNota.Text);
                if (nota>=0&& nota<=5)
                {
                    if (new Documento().ModificarNota(TextBoxId.Text,Convert.ToString(nota)))
                    {
                        Response.Redirect("CalificarProfesor.aspx");
                    }
                    else
                    {
                        Alerta.Visible = true;
                        Alerta.CssClass = "alert alert-danger";
                        Alert.Text = "No se registro los datos ingresados";
                    }
                }
                else
                {
                    Alerta.Visible = true;
                    Alerta.CssClass = "alert alert-danger";
                    Alert.Text = "Debe ser la nota en el rango de 0 a 5";
                }
            }
            catch 
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-danger";
                Alert.Text = "La cadena ingresada no es de tipo numerico";
            }
        }
    }
}