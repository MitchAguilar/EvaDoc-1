using EvaDoc.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class GenerarReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonGenerar_Click(object sender, EventArgs e)
        {
            Persona PER = (Persona)Session["Persona"];
            Reporte documento = new Reporte();
            Response.Redirect("../Documento/"+documento.CrearPDF(PER.PER_NOMBRE+" "+PER.PER_APELLIDO));
        }
    }
}