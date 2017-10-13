using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc
{
    public partial class MasterP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Inicio sesión 
            try
            {
                
                Persona PER = (Persona)Session["Persona"];
                Nombre.InnerText = PER.PER_NOMBRE + " " + PER.PER_APELLIDO;
                Usuario USU =(Usuario)Session["Usuario"];
                string html= "";
                if (USU.USU_ROL=="1")
                {
                    html += "<li><a href='CriterioGestionar.aspx'><i class='material-icons'>settings</i><p>Gestionar Criterios</p></a></li>";
                    html += "<li><a href='EvaluadorAsignar.aspx'> <i class='material-icons'>person</i><p>Asignar Evaluador</p> </a></li>";
                    html += "<li><a href='CalificarProfesor.aspx'> <i class='material-icons'>content_paste</i><p>Calificar Documento</p> </a></li>";
                    html += "<li><a href='VerDocumentoAdmin.aspx'><i class='material-icons'>perm_media</i><p>Ver Documento</p></a></li>";
                    html += "<li><a href='GenerarReporte.aspx'><i class='material-icons'>cloud_download</i> <p>Descargar Reporte</p></a></li>";
                }
                else
                {
                    html += "<li><a href='DocumentoSubir.aspx'><i class='material-icons'>backup</i> <p>Subir Documentos</p></a></li>";
                    html += "<li><a href='DocumentoCalificar.aspx'><i class='material-icons'>content_paste</i><p>Calificar Documento</p></a></li>";
                    html += "<li><a href='SubirResultado.aspx'><i class='material-icons'>backup</i><p>Subir Documento De Correcciones</p></a></li>";
                    html += "<li><a href='VerDocumento.aspx'><i class='material-icons'>perm_media</i><p>Ver Documento</p></a></li>";
                }
                men.InnerHtml = html;
            }
            catch 
            {
                Response.Redirect("../Index.aspx");
            }
        }
    }
}