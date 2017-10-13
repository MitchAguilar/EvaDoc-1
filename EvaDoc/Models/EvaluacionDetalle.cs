using EvaDoc.AccesoDato.Conexion;
using EvaDoc.AccesoDato.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaDoc.Models
{
    public class EvaluacionDetalle
    {
        //Atributo
        private IDatos CONSULTA = new Datos();
        public string IDEVADET { get; set; }
        public string EVADET_IDEVALUACION { get; set; }
        public string EVADET_IDCRITERIO { get; set; }
        public string EVADET_PUNTAJE { get; set; }
        //Constructores
        public EvaluacionDetalle()
        {
            IDEVADET = "";
            EVADET_IDEVALUACION = "";
            EVADET_IDCRITERIO = "";
            EVADET_PUNTAJE = "";
        }

        public EvaluacionDetalle(string idevadet,string eva, string crit, string puntos)
        {
            IDEVADET =idevadet;
            EVADET_IDEVALUACION = eva;
            EVADET_IDCRITERIO = crit;
            EVADET_PUNTAJE =puntos;
        }

        //Metodos
        //Metodo para registrar el detalle de evaluacion
        public bool RegistrarDetEva(EvaluacionDetalle obj,string porc,string just)
        {
            return CONSULTA.OperarDatos("CALL `PR_INSERTAR_EVALUARDETALLE`('"+obj.EVADET_IDEVALUACION+"', '"+obj.EVADET_IDCRITERIO+"', '"+obj.EVADET_PUNTAJE+"', '"+porc+ "','" +just+ "')");
        }

        //Metodo para calcular el promedio 
        public string promedio(string ideva)
        {
            return CONSULTA.ConsultarDatos("select  sum(EVADET_PUNTAJE) AS PROMEDIO from evaluardetalle  group by EVADET_IDEVALUAR having EVADET_IDEVALUAR='"+ideva+"';").Rows[0]["PROMEDIO"].ToString();
        }
    }
}