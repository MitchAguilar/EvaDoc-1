using EvaDoc.AccesoDato.Conexion;
using EvaDoc.AccesoDato.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EvaDoc.Models
{
    public class Evalucion
    {
        //Atributo
        private IDatos CONSULTA = new Datos();
        public string IDEVAUACION { get; set; }
        public Persona EVA_EVALUADOR { get; set; }
        public Documento EVA_DOCUMENTO { get; set; }
        //Constructores
        public Evalucion()
        {
            IDEVAUACION = "";
            EVA_EVALUADOR = new Persona();
            EVA_DOCUMENTO = new Documento();
        }

        public Evalucion(string idevaluacion, Persona evaluador, Documento documento)
        {
            IDEVAUACION = idevaluacion;
            EVA_EVALUADOR = evaluador;
            EVA_DOCUMENTO = documento;
        }

        //Metodos
        //Metodo para registrar los evaluadores
        public bool RegistrarEvaluador(string evaluador, string documento)
        {
            if (CONSULTA.ConsultarDatos("select * from evaluar where EVA_IDDOCUMENTO='" + documento + "' AND EVA_EVALUADOR='" + evaluador + "';").Rows.Count == 0)
            {
                return CONSULTA.OperarDatos("INSERT INTO `evadoc`.`evaluar` (`EVA_IDDOCUMENTO`, `EVA_EVALUADOR`, `EVA_ESTADO`,`EVA_CALIFICACION`) VALUES ('" + documento + "', '" + evaluador + "','1','0');");
            }
            return false;

        }

        //Metodo para modificar el estado 
        public bool ModificarEvaluador(string id, string estado)
        {
            return CONSULTA.OperarDatos("UPDATE `evadoc`.`evaluar` SET `EVA_ESTADO`='" + estado + "' WHERE  `IDEVALUAR`='" + id + "';");
        }

        public bool EliminarEvaluador(string id)
        {
            return CONSULTA.OperarDatos("DELETE FROM `evadoc`.`evaluar` WHERE  `IDEVALUAR`='"+id+"';");
        }

        //Metodo para consultar los evaluadores por el documento
        public DataTable CosnultarEvaluador(string documento)
        {
            return CONSULTA.ConsultarDatos("select IDEVALUAR AS ID, CONCAT(PER_NOMBRE,' ',PER_APELLIDO) AS NOMBRE from evaluar inner join usuario on IDUSUARIO = EVA_EVALUADOR inner join persona on IDPERSONA = USU_IDPERSONA where EVA_IDDOCUMENTO = '" + documento + "'; ");
        }

        //Metodo para modificar el estado 
        public bool ModificarEvaluadorPromedio(string id)
        {
            return CONSULTA.OperarDatos("CALL `PR_MODIFICAR_EVALUAR`('"+id+"')");
        }

        //Metodo para consultar los documentos del evaluador
        public DataTable ConsultarEvaluadorDoc(string evaluador)
        {
            return CONSULTA.ConsultarDatos("select IDDOCUMENTO, DOC_TITULO, EVA_ESTADO, IDEVALUAR from evaluar inner join Documento on IDDOCUMENTO = EVA_IDDOCUMENTO where EVA_EVALUADOR = '" + evaluador+"'; ");
        }
    }
}