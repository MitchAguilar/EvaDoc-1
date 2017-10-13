using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class DocumentoSubir : System.Web.UI.Page
    {
        string Carpeta = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Persona PER = (Persona)Session["Persona"];
                if (!IsPostBack)
                {
                    DropDownCompa.Items.Clear();
                    DropDownCompa.Items.Add(new ListItem("- Seleccionar Compañero -", "0"));
                    DataTable cons = new Persona().ConsultarPersona();
                    for (int i = 0; i < cons.Rows.Count; i++)
                    {
                        if (cons.Rows[i]["IDPERSONA"].ToString() != PER.IDPERSONA&& cons.Rows[i]["IDPERSONA"].ToString()!="0")
                        {
                            DropDownCompa.Items.Add(new ListItem(cons.Rows[i]["PER_NOMBRE"].ToString() + " " + cons.Rows[i]["PER_APELLIDO"].ToString(), cons.Rows[i]["IDPERSONA"].ToString()));
                        }
                    }
                    DropDownCompa.Items.Add(new ListItem("Ninguno", "null"));
                }
                Carpeta = Path.Combine(Request.PhysicalApplicationPath, "Documento");
            }
            catch 
            {
                Response.Redirect("../Index.aspx");
            }
           
        }

        protected void ButtonSubir_Click(object sender, EventArgs e)
        {
            if (DropDownCompa.Text!="0")
            {
                if (FileUploadDocumento.PostedFile.FileName != "")
                {
                    try
                    {
                        string extension = Path.GetExtension(FileUploadDocumento.PostedFile.FileName);
                        FileUploadDocumento.PostedFile.SaveAs(Path.Combine(Carpeta, Path.GetFileName(FileUploadDocumento.PostedFile.FileName)));
                        Usuario USU = (Usuario)Session["Usuario"];
                        Documento DOC = new Documento("", TextBoxTitulo.Text, FileUploadDocumento.PostedFile.FileName,USU.IDUSUARIO, DropDownCompa.Text);
                        if (DOC.RegistrarDocumento(DOC))
                        {
                            Alerta.Visible = true;
                            Alerta.CssClass = "alert alert-success";
                            Alert.Text = "Registro Exitoso.";
                        }
                        else
                        {
                            Alerta.Visible = true;
                            Alerta.CssClass = "alert alert-danger";
                            Alert.Text = "el registro no fue digilenciado en una forma adecuada";
                        }
                    }
                    catch 
                    {
                        Alerta.Visible = true;
                        Alerta.CssClass = "alert alert-danger";
                        Alert.Text = "Error en la subida del archivo";
                    }
                    
                }
                else
                {
                    Alerta.Visible = true;
                    Alerta.CssClass = "alert alert-danger";
                    Alert.Text = "No agrego el archivo";
                }
            }
            else
            {
                Alerta.Visible = true;
                Alerta.CssClass = "alert alert-danger";
                Alert.Text = "Debe seleccionar un compañero o ninguno";
            }
        }
    }
}