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
    public partial class DocumentoCalificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string html = "";
                Usuario USU = (Usuario)Session["Usuario"];
                DataTable cons = new Evalucion().ConsultarEvaluadorDoc(USU.IDUSUARIO);
                for (int i = 0; i < cons.Rows.Count; i++)
                {
                    if (cons.Rows[i]["EVA_ESTADO"].ToString() == "1")
                    {
                        html += "<li><a href='#' onclick='ConsultarEvaluacion(\"" + cons.Rows[i]["IDDOCUMENTO"].ToString() + "\",\"1\",\"" + cons.Rows[i]["IDEVALUAR"].ToString() + "\")'><i class='material-icons'>description</i> " + cons.Rows[i]["DOC_TITULO"].ToString() + " <div class='ripple-container'></div></a></li>";
                    }
                    else
                    {
                        html += "<li><a href='#' onclick='ConsultarEvaluacion(\"" + cons.Rows[i]["IDDOCUMENTO"].ToString() + "\",\"0\",\"" + cons.Rows[i]["IDEVALUAR"].ToString() + "\")'><i class='material-icons'>assignment_turned_in</i> " + cons.Rows[i]["DOC_TITULO"].ToString() + " <div class='ripple-container'></div></a></li>";
                    }
                }
                menu.InnerHtml = html;
            }
            catch
            {
            }

        }
    }
}