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
    public partial class DetalleEvaluar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string documento = Convert.ToString(Request.QueryString["id"]);
                string est = Convert.ToString(Request.QueryString["Estado"]);
                string evaluar = Convert.ToString(Request.QueryString["Evaluar"]);
                Documento DOC = new Documento().ConsultarDocumento(documento);
                titulo.InnerText = DOC.DOC_TITULO;
                autor1.InnerText = DOC.AUTOR_1.IDPERSONA.PER_NOMBRE + " " + DOC.AUTOR_1.IDPERSONA.PER_APELLIDO;
                if (DOC.AUTOR_2 != null)
                {
                    autor2.InnerText = DOC.AUTOR_2.IDPERSONA.PER_NOMBRE + " " + DOC.AUTOR_2.IDPERSONA.PER_APELLIDO;
                    autor2.Visible = true;
                }
                descarga.HRef = "../Documento/" + DOC.DOC_URL;
                DataTable con = new Criterio().ConsutarCriterioGeneral();
                string html = "";
                for (int i = 0; i < con.Rows.Count; i++)
                {
                    html += "<tr>";
                    html += "<td><label name='idcrit'>" + con.Rows[i]["ID"].ToString() + "</label></td>";
                    html += "<td>" + con.Rows[i]["CRITERIO"].ToString() + "</td>";
                    html += "<td><textarea id='just' class='form-control' name='just' rows='4'></textarea ></td>";
                    html += "<td><select id='crit'name='crit' class='form-control'>";
                    html += "<option value='-1'>..</option>";
                    html += "<option value='0'>0</option>";
                    html += "<option value='0.5'>0.5</option>";
                    html += "<option value='1'>1</option>";
                    html += "<option value='1.5'>1.5</option>";
                    html += "<option value='2'>2</option>";
                    html += "<option value='2.5'>2.5</option>";
                    html += "<option value='3'>3</option>";
                    html += "<option value='3.5'>3.5</option>";
                    html += "<option value='4'>4</option>";
                    html += "<option value='4.5'>4.5</option>";
                    html += "<option value='5'>5</option>";
                    html += "</select></td>";
                    html += "</tr>";
                }
                TB.InnerHtml = html;
                if (est=="1")
                {
                    boton.InnerHtml = "<a id='BtnGuradar' class='btn btn-success' onclick='GuardarCalificacion(\"" + evaluar + "\")'><i class='material-icons'>save</i> Calificar</a>";
                }
                else
                {
                    boton.InnerHtml = "<div class='alert alert-danger'><span>YA SE CALIFICO EL DOCUMENTO</span></div>";
                }
                
            }
            catch 
            {
                Response.Redirect("../Index.aspx");
            }
        }

        
    }
}
