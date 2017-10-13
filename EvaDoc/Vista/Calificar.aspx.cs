using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class Calificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Convert.ToString(Request.QueryString["id"]);
            string idcrit = Convert.ToString(Request.QueryString["idcrit"]);
            string valor = Convert.ToString(Request.QueryString["valor"]);
            string just = Convert.ToString(Request.QueryString["just"]);
            Criterio CRI = new Criterio().ConsutarCriterio(idcrit);
            EvaluacionDetalle DETEVA = new EvaluacionDetalle("", id, idcrit, valor);
            DETEVA.RegistrarDetEva(DETEVA, CRI.CRI_PORCENTAJE,just);
            new Evalucion().ModificarEvaluador(id, "0");
            bool m = new Evalucion().ModificarEvaluadorPromedio(id);
        }
    }


}