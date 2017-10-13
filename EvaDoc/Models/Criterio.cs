using EvaDoc.AccesoDato.Conexion;
using EvaDoc.AccesoDato.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EvaDoc.Models
{
    public class Criterio
    {
        //Atributo
        private IDatos CONSULTA = new Datos();
        public string IDCRITERIO { get; set; }
        public string CRI_DETALLE { get; set; }
        public string CRI_PORCENTAJE { get; set; }

        //Constructores
        public Criterio()
        {
            IDCRITERIO = "";
            CRI_DETALLE = "";
            CRI_PORCENTAJE = "";
        }

        public Criterio(string idcriterio, string detalle,string porcentaje)
        {
            IDCRITERIO = idcriterio;
            CRI_DETALLE = detalle;
            CRI_PORCENTAJE = porcentaje;
        }

        //Metodos
        //Metodo para registrar los criterio
        public bool RegistrarCriterio(Criterio obj)
        {
            return CONSULTA.OperarDatos("INSERT INTO `evadoc`.`criterios` (`IDCRITERIOS`,`CRI_DETALLE`,`CRI_PORCENTAJE`) VALUES ((select ifnull(max(c.IDCRITERIOS)+1,1) as SECUENCIA from criterios c),'" + obj.CRI_DETALLE+"','"+obj.CRI_PORCENTAJE+"');");
        }

        //Metodo para modificar los criterios
        public bool ModificarCriterio(Criterio obj)
        {
            return CONSULTA.OperarDatos("UPDATE `evadoc`.`criterios` SET `CRI_DETALLE`='"+obj.CRI_DETALLE+"', `CRI_PORCENTAJE`='"+obj.CRI_PORCENTAJE+"' WHERE  `IDCRITERIOS`='"+obj.IDCRITERIO+"';");
        }

        //Metodo para Consultar los criterios en general
        public DataTable ConsutarCriterioGeneral()
        {
            return CONSULTA.ConsultarDatos("select IDCRITERIOS as ID, CRI_DETALLE AS CRITERIO, CRI_PORCENTAJE AS PORCENTAJE from criterios;");
        }

        //Metodo para Consultar los criterios en general
        public Criterio ConsutarCriterio(string id)
        {
            DataTable con = CONSULTA.ConsultarDatos("select * from criterios where IDCRITERIOS='" + id + "';");
            return new Criterio(con.Rows[0]["IDCRITERIOS"].ToString(), con.Rows[0]["CRI_DETALLE"].ToString(), con.Rows[0]["CRI_PORCENTAJE"].ToString());
        }
    }
}