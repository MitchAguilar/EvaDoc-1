using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc
{
    public partial class PersonaRegistrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegistrar_Click(object sender, EventArgs e)
        {
            if (new Usuario().ConsultarUsuario(TextBoxUsurio.Text)==null)
            {
                Persona PER = new Persona("", TextBoxIdentificacion.Text, TextBoxNombre.Text, TextBoxApellido.Text, TextBoxCorreo.Text);

                if (PER.RegistrarPersona(PER))
                {
                    Usuario USU = new Usuario("", TextBoxUsurio.Text, "2", PER.ConsultarPersona(PER.PER_IDENTIFICACION));
                    USU.USU_PASS = TextBoxPass.Text;
                    if (USU.RegistrarUsuario(USU))
                    {
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Alerta.Visible = true;
                        Alerta.CssClass = "alert alert-danger";
                        Alert.Text = "La constraseña o el usuario registrado no son los adecuados.";
                    }
                }
                else
                {
                    Alerta.Visible = true;
                    Alerta.CssClass = "alert alert-danger";
                    Alert.Text = "Los datos de la persona no son los adecuados o ya existe la identificación con la que se registro";
                }
            }
            else
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-danger";
                Alert.Text = "El usuario ya Existe";
            }
            
        }
    }
}