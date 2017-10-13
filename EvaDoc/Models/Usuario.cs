using EvaDoc.AccesoDato.Conexion;
using EvaDoc.AccesoDato.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EvaDoc.Models
{
    public class Usuario
    {
        //Atributos 
        private IDatos CONSULTA = new Datos();
        public string IDUSUARIO { get; set; }
        public string USU_USER { get; set; }
        public string USU_PASS { get; set; }
        public string USU_ROL { get; set; }
        public Persona IDPERSONA { get; set; }

        //Construtores
        public Usuario()
        {
            IDUSUARIO = "";
            USU_USER = "";
            USU_PASS = "";
            USU_ROL = "";
            IDPERSONA = new Persona();
        }

        public Usuario(string idusuario, string user, string rol, Persona persona)
        {
            IDUSUARIO = idusuario;
            USU_USER = user;
            USU_PASS = "";
            USU_ROL = rol;
            IDPERSONA = persona;
        }

        //Metodos
        //Metodo para registrar Usuario
        public bool RegistrarUsuario(Usuario obj)
        {
            return CONSULTA.OperarDatos("INSERT INTO `evadoc`.`usuario` (`USU_USER`, `USU_PASS`, `USU_IDPERSONA`, `USU_IDROL`) VALUES ('" + obj.USU_USER + "', md5('" + obj.USU_PASS + "'), '" + obj.IDPERSONA.IDPERSONA + "', '" + obj.USU_ROL + "');");
        }

        //Metodo para consultar Usuario
        public Usuario ConsultarUsuario(string user)
        {
            DataTable consulta = CONSULTA.ConsultarDatos("select * from usuario where USU_USER='" + user + "';");
            if (consulta.Rows.Count>0)
            {
                return new Usuario(consulta.Rows[0]["IDUSUARIO"].ToString(), consulta.Rows[0]["USU_USER"].ToString(), consulta.Rows[0]["USU_IDROL"].ToString(), new Persona().ConsultarPersonaId(consulta.Rows[0]["USU_IDPERSONA"].ToString()));
            }
            else
            {
                return null;
            }
        }

        //Metodo para consultar Usuario ID
        public Usuario ConsultarUsuarioId(string id)
        {
            DataTable consulta = CONSULTA.ConsultarDatos("select * from usuario where IDUSUARIO='" + id + "';");
            return new Usuario(consulta.Rows[0]["IDUSUARIO"].ToString(), consulta.Rows[0]["USU_USER"].ToString(), consulta.Rows[0]["USU_IDROL"].ToString(), new Persona().ConsultarPersonaId(consulta.Rows[0]["USU_IDPERSONA"].ToString()));
        }

        //Metodo para consultar el usuario con el id de la persona
        public Usuario ConsultarUsuarioIdPersona(string id)
        {
            DataTable consulta = CONSULTA.ConsultarDatos("select * from usuario where USU_IDPERSONA='" + id + "';");
            return new Usuario(consulta.Rows[0]["IDUSUARIO"].ToString(), consulta.Rows[0]["USU_USER"].ToString(), consulta.Rows[0]["USU_IDROL"].ToString(), new Persona().ConsultarPersonaId(consulta.Rows[0]["USU_IDPERSONA"].ToString()));
        }

        //Metodo para validar el usuario
        public bool ValidarUsuario(Usuario obj)
        {
            if (CONSULTA.ConsultarDatos("select * from usuario where USU_USER='" + obj.USU_USER + "'and USU_PASS=md5('" + obj.USU_PASS + "');").Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

    }
}