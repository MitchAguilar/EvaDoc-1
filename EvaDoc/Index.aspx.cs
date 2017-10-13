using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                Session["Usuario"] = null;
                Session["Persona"] = null;
        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            Usuario USU = new Usuario();
            USU.USU_USER=TextBoxUsurio.Text;
            USU.USU_PASS = TextBoxPass.Text;
            if (USU.ValidarUsuario(USU))
            {
                USU= USU.ConsultarUsuario(USU.USU_USER);
                Session["Usuario"] = USU;
                Session["Persona"] = USU.IDPERSONA;
                Response.Redirect("Vista/Principal.aspx");
            }
            else
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-danger";
                Alert.Text = "Contraseña o el usuario no son correctos";
            }
        }
    }
}