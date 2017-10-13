using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class EvaluadorAsignar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["id"]=="1")
                    {
                        Alerta.Visible = true;
                        Alerta.CssClass = "alert alert-success";
                        Alert.Text = "Eliminación Exitosa.";
                    }
                    if (Request.QueryString["id"] == "2") 
                    {
                        Alerta.Visible = true;
                        Alerta.CssClass = "alert alert-danger";
                        Alert.Text = "No se pudo eliminar el evaluador, ya califico el documento";
                    }
                }
                catch 
                {
                }
                DropDownListEvaluador.Items.Clear();
                DropDownListEvaluador.Items.Add(new ListItem("- Seleccionar Evaluador -", "0"));
                DataTable cons = new Persona().ConsultarPersona();
                for (int i = 0; i < cons.Rows.Count; i++)
                {
                    if (cons.Rows[i]["IDPERSONA"].ToString()!="0")
                    {
                        DropDownListEvaluador.Items.Add(new ListItem(cons.Rows[i]["PER_NOMBRE"].ToString() + " " + cons.Rows[i]["PER_APELLIDO"].ToString(), cons.Rows[i]["IDPERSONA"].ToString()));
                    }
                }

                DropDownDocumento.Items.Clear();
                DropDownDocumento.Items.Add(new ListItem("- Seleccionar Documento -", "0"));
                DataTable con = new Documento().ConsultarDocumentoTitulo();
                for (int i = 0; i < con.Rows.Count; i++)
                {
                    if (con.Rows[i]["AUTOR_2"].ToString()=="")
                    {
                        DropDownDocumento.Items.Add(new ListItem(con.Rows[i]["TITULO"].ToString() + " ( " + con.Rows[i]["AUTOR_1"].ToString() + " ) ", con.Rows[i]["ID"].ToString()));
                    }
                    else
                    {
                        DropDownDocumento.Items.Add(new ListItem(con.Rows[i]["TITULO"].ToString() + " ( " + con.Rows[i]["AUTOR_1"].ToString() + " - " + con.Rows[i]["AUTOR_2"].ToString() + " ) ", con.Rows[i]["ID"].ToString()));
                    }
                }
            }
        }

        protected void DropDownDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = new Evalucion().CosnultarEvaluador(DropDownDocumento.Text) ;
            GridView1.Visible = true;
            GridView1.DataBind();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            if (DropDownDocumento.Text!="0")
            {
                if (DropDownListEvaluador.Text!= "0")
                {
                    if (new Evalucion().RegistrarEvaluador(new Usuario().ConsultarUsuarioIdPersona(DropDownListEvaluador.Text).IDUSUARIO, DropDownDocumento.Text))
                    {
                        Alerta.Visible = true;
                        Alerta.CssClass = "alert alert-success";
                        Alert.Text = "Registro Exitoso.";
                        Response.Redirect("EvaluadorAsignar.aspx");
                    }
                    else
                    {
                        Alerta.Visible = true;
                        Alerta.CssClass = "alert alert-danger";
                        Alert.Text = "No se agrego el evaluador ya existe";
                    }
                }
                else
                {
                    Alerta.Visible = true;
                    Alerta.CssClass = "alert alert-danger";
                    Alert.Text = "Debe seleccionar un evaluador";
                }
            }
            else
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-danger";
                Alert.Text = "Debe seleccionar al documento.";
            }
            
        }
    }
}