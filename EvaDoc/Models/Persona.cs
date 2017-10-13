using EvaDoc.AccesoDato.Conexion;
using EvaDoc.AccesoDato.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EvaDoc.Models
{
    public class Persona
    {
        //Atributos
        private IDatos CONSULTA = new Datos();
        public string IDPERSONA { get; set; }
        public string PER_IDENTIFICACION { get; set; }
        public string PER_NOMBRE { get; set; }
        public string PER_APELLIDO { get; set; }
        public string PER_CORREO { get; set; }

        //Constructores
        public Persona()
        {
            IDPERSONA = "";
            PER_IDENTIFICACION = "";
            PER_NOMBRE = "";
            PER_APELLIDO = "";
            PER_CORREO = "";
        }

        public Persona(string idpersona, string identificacion, string nombre, string apellido, string correo)
        {
            IDPERSONA = idpersona;
            PER_IDENTIFICACION = identificacion;
            PER_NOMBRE = nombre;
            PER_APELLIDO = apellido;
            PER_CORREO = correo;
        }

        //Metodos
        //Metodo para registrar persona
        public bool RegistrarPersona(Persona obj)
        {
            return CONSULTA.OperarDatos("INSERT INTO `evadoc`.`persona` (`PER_IDENTIFICACION`, `PER_NOMBRE`, `PER_APELLIDO`, `PER_CORREO`) VALUES ('" + obj.PER_IDENTIFICACION + "', '" + obj.PER_NOMBRE + "', '" + obj.PER_APELLIDO + "', '" + obj.PER_CORREO + "');");
        }

        //Metodo para consultar persona por id
        public Persona ConsultarPersonaId(string id)
        {
            DataTable CON = CONSULTA.ConsultarDatos("select * from persona where IDPERSONA='" + id + "';");
            return new Persona(CON.Rows[0]["IDPERSONA"].ToString(), CON.Rows[0]["PER_IDENTIFICACION"].ToString(), CON.Rows[0]["PER_NOMBRE"].ToString(), CON.Rows[0]["PER_APELLIDO"].ToString(), CON.Rows[0]["PER_CORREO"].ToString());
        } 

        //Metodo para consultar persona por identificación
        public Persona ConsultarPersona(string identificacion)
        {
            DataTable CON = CONSULTA.ConsultarDatos("select * from persona where PER_IDENTIFICACION='" + identificacion + "';");
            return new Persona(CON.Rows[0]["IDPERSONA"].ToString(), CON.Rows[0]["PER_IDENTIFICACION"].ToString(), CON.Rows[0]["PER_NOMBRE"].ToString(), CON.Rows[0]["PER_APELLIDO"].ToString(), CON.Rows[0]["PER_CORREO"].ToString());
        }
        //Metodo para consultar personas en general
        public DataTable ConsultarPersona()
        {
            return CONSULTA.ConsultarDatos("select * from persona;");
        }
    }
}