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
    public partial class SubirResultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DropDownDocumento.Items.Clear();
                    DropDownDocumento.Items.Add(new ListItem("- Seleccionar Documento -", "0"));
                    Usuario USU = (Usuario)Session["Usuario"];
                    DataTable cons = new Evalucion().ConsultarEvaluadorDoc(USU.IDUSUARIO);
                    for (int i = 0; i < cons.Rows.Count; i++)
                    {
                        DropDownDocumento.Items.Add(new ListItem(cons.Rows[i]["DOC_TITULO"].ToString(), cons.Rows[i]["IDDOCUMENTO"].ToString()));
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("../Index.aspx");
            }
        }

        protected void ButtonSubir_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownDocumento.Text != "0")
                {
                    if (FileUploadDocumento.PostedFile.FileName != "")
                    {
                        try
                        {
                            string extension = Path.GetExtension(FileUploadDocumento.PostedFile.FileName);
                            FileUploadDocumento.PostedFile.SaveAs(Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "Documento"), Path.GetFileName(FileUploadDocumento.PostedFile.FileName)));
                            Usuario USU = (Usuario)Session["Usuario"];
                            Resultado RES = new Resultado("", DropDownDocumento.Text, USU.IDUSUARIO, FileUploadDocumento.PostedFile.FileName);
                            if (RES.ConsultaResultadoDocumento(RES.RES_IDDOCUMENTO, RES.RES_IDUSUARIO))
                            {
                                if (RES.ReistrarResultadoDocumento(RES))
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
                            else
                            {
                                if (RES.ModificarResultadoDocumento(RES))
                                {
                                    Alerta.Visible = true;
                                    Alerta.CssClass = "alert alert-success";
                                    Alert.Text = "Modificación Exitoso.";
                                }
                                else
                                {
                                    Alerta.Visible = true;
                                    Alerta.CssClass = "alert alert-danger";
                                    Alert.Text = "el registro no fue digilenciado en una forma adecuada";
                                }
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
                    Alert.Text = "Debe seleccionar un documento";
                }
            }
            catch
            {
                Response.Redirect("../Index.aspx");
            }
        }
    }
}