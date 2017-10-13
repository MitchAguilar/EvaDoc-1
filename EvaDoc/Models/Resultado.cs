using EvaDoc.AccesoDato.Conexion;
using EvaDoc.AccesoDato.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EvaDoc.Models
{
    public class Resultado
    {
        //Atributos
        private IDatos CONSULTA = new Datos();
        public string IDRESULTADO { get; set; }
        public string RES_IDDOCUMENTO { get; set; }
        public string RES_IDUSUARIO { get; set; }
        public string RES_URL { get; set; }

        public Resultado()
        {
            IDRESULTADO = "";
            RES_IDDOCUMENTO = "";
            RES_IDUSUARIO = "";
            RES_URL = "";
        }

        public Resultado(string id, string documento, string usuario, string url)
        {
            IDRESULTADO = id;
            RES_IDDOCUMENTO = documento;
            RES_IDUSUARIO = usuario;
            RES_URL = url;
        }

        //Metodo para resgistrar los documentos obtenido los resultados
        public bool ReistrarResultadoDocumento(Resultado obj)
        {
            return CONSULTA.OperarDatos("INSERT INTO `evadoc`.`resultado` (`RES_IDDOCUMENTO`, `RES_IDUSUARIO`, `RES_URL`) VALUES ('"+obj.RES_IDDOCUMENTO+"', '"+obj.RES_IDUSUARIO+"', '"+obj.RES_URL+"');");
        }

        //Metodo para resgistrar los documentos obtenido los resultados
        public bool ModificarResultadoDocumento(Resultado obj)
        {
            return CONSULTA.OperarDatos("UPDATE `evadoc`.`resultado` SET `RES_URL`='"+obj.RES_URL+"' where RES_IDDOCUMENTO='"+obj.RES_IDDOCUMENTO+"' and  RES_IDUSUARIO='"+obj.RES_IDUSUARIO+"';");
        }

        public DataTable ConsultarResultadoGeneral()
        {
            return CONSULTA.ConsultarDatos("select RES_IDDOCUMENTO, RES_URL AS URL, DOC_TITULO AS TITULO, CONCAT(PER_NOMBRE,' ',PER_APELLIDO) AS EVALUADOR from resultado inner join documento on IDDOCUMENTO=RES_IDDOCUMENTO inner join usuario on IDUSUARIO=RES_IDUSUARIO  inner join persona on IDPERSONA=USU_IDPERSONA order by RES_IDDOCUMENTO;");
        }

        //Metodo para consultar si el resultado ya fue subido
        public bool ConsultaResultadoDocumento(string documento, string usuario)
        {
            if (CONSULTA.ConsultarDatos("select * from resultado where RES_IDDOCUMENTO='"+documento+"' and  RES_IDUSUARIO='"+usuario+"';").Rows.Count>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Metodo para consultar Documentos subidos
        public DataTable ConsultarResultados(string usuario)
        {
            return CONSULTA.ConsultarDatos("select IDRESULTADO, RES_URL, CONCAT('Revición ',DOC_TITULO) AS TITULO from resultado"
                                            + " inner join documento on IDDOCUMENTO = RES_IDDOCUMENTO"
                                            +" where RES_IDUSUARIO = '"+usuario+"';");
        }

        public bool EliminarResultado(string id)
        {
            return CONSULTA.OperarDatos("DELETE FROM `evadoc`.`resultado` WHERE  `IDRESULTADO`='"+id+"';");
        }
    }
}