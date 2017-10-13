using EvaDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaDoc.Vista
{
    public partial class EliminarEvaluador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (new Evalucion().EliminarEvaluador(Request.QueryString["id"]))
            {
                Response.Redirect("EvaluadorAsignar.aspx?id=1");
            }
            else
            {
                Response.Redirect("EvaluadorAsignar.aspx?id=2");
            }
        }
    }
}