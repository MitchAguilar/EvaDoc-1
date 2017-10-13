using EvaDoc.AccesoDato.Conexion;
using EvaDoc.AccesoDato.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EvaDoc.Models
{
    public class Documento
    {
        //Atributos
        private IDatos CONSULTA = new Datos();
        public string IDDOCUMENTO { get; set; }
        public string DOC_TITULO { get; set; }
        public string DOC_URL { get; set; }
        public Usuario AUTOR_1 { get; set; }
        public Usuario AUTOR_2 { get; set; }
        public string AU_1 { get; set; }
        public string AU_2 { get; set; }

        //Constructores
        public Documento()
        {
            IDDOCUMENTO = "";
            DOC_TITULO = "";
            DOC_URL = "";
            AUTOR_1 = new Usuario();
            AUTOR_2 = new Usuario();
        }
        public Documento(string iddocumento, string titulo, string url, Usuario p1, Usuario p2)
        {
            IDDOCUMENTO = iddocumento;
            DOC_TITULO = titulo;
            DOC_URL = url;
            AUTOR_1 = p1;
            AUTOR_2 = p2;
        }

        public Documento(string iddocumento, string titulo, string url, string p1, string p2)
        {
            IDDOCUMENTO = iddocumento;
            DOC_TITULO = titulo;
            DOC_URL = url;
            AU_1 = p1;
            AU_2 = p2;
        }

        //Metodos
        //Metodo para registrar Documentos
        public bool RegistrarDocumento(Documento obj)
        {
            if (obj.AU_2 == "null")
            {
                return CONSULTA.OperarDatos("INSERT INTO `evadoc`.`documento` ( `DOC_TITULO`, `DOC_URL`, `DOC_AUTOR_1`) VALUES ('" + obj.DOC_TITULO + "', '" + obj.DOC_URL + "', '" + obj.AU_1 + "');");
            }
            else
            {
                Usuario USU = new Usuario().ConsultarUsuarioIdPersona(obj.AU_2);
                return CONSULTA.OperarDatos("INSERT INTO `evadoc`.`documento` ( `DOC_TITULO`, `DOC_URL`, `DOC_AUTOR_1`,`DOC_AUTOR_2`) VALUES ('" + obj.DOC_TITULO + "', '" + obj.DOC_URL + "', '" + obj.AU_1 + "','" + USU.IDUSUARIO + "');");
            }
        }

        //Metodo para consultar los documentos en generar
        public DataTable ConsultarDocumento()
        {
            return CONSULTA.ConsultarDatos("select * from documento;");
        }

        //Metodo para consultar los documentos por  la identificacion
        public Documento ConsultarDocumento(string id)
        {
            DataTable cons = CONSULTA.ConsultarDatos("select * from documento where IDDOCUMENTO='" + id + "';");
            if (cons.Rows[0]["DOC_AUTOR_2"].ToString() == "")
            {
                return new Documento(cons.Rows[0]["IDDOCUMENTO"].ToString(), cons.Rows[0]["DOC_TITULO"].ToString(), cons.Rows[0]["DOC_URL"].ToString(), new Usuario().ConsultarUsuarioId(cons.Rows[0]["DOC_AUTOR_1"].ToString()), null);
            }
            else
            {
                return new Documento(cons.Rows[0]["IDDOCUMENTO"].ToString(), cons.Rows[0]["DOC_TITULO"].ToString(), cons.Rows[0]["DOC_URL"].ToString(), new Usuario().ConsultarUsuarioId(cons.Rows[0]["DOC_AUTOR_1"].ToString()), new Usuario().ConsultarUsuarioId(cons.Rows[0]["DOC_AUTOR_2"].ToString()));
            }

        }

        //Metodo para Consultar Documentos subidos
        public DataTable ConsultarDocumentoSubido(string usuario)
        {
            return CONSULTA.ConsultarDatos("select * from documento where DOC_AUTOR_1='" + usuario + "' or DOC_AUTOR_2='" + usuario + "';");
        }

        //Metodo para consultar los titulos del documento
        public DataTable ConsultarDocumentoTitulo()
        {
            return CONSULTA.ConsultarDatos("Select IDDOCUMENTO AS ID, DOC_TITULO AS TITULO, DOC_URL AS URL, CONCAT(per1.PER_NOMBRE,' ',per1.PER_APELLIDO) AS AUTOR_1, CONCAT(per2.PER_NOMBRE,' ',per2.PER_APELLIDO) AS AUTOR_2, DOC_NOTA AS NOTA  from documento"
                                          + " inner join Usuario usu1 on usu1.IDUSUARIO = DOC_AUTOR_1"
                                          + " inner join Persona per1 on usu1.USU_IDPERSONA = per1.IDPERSONA"
                                          + " left join Usuario usu2 on usu2.IDUSUARIO = DOC_AUTOR_2"
                                          + " left join Persona per2 on usu2.USU_IDPERSONA = per2.IDPERSONA; ");
        }

        //Metodo para consultar todos los documentos rebizados
        public DataTable ConsultarDocumentoRebizado()
        {
            return CONSULTA.ConsultarDatos("select * from documento;");
        }

        //Metodo para modificar la nota
        public bool ModificarNota(string id, string nota)
        {

            return CONSULTA.OperarDatos("UPDATE `evadoc`.`documento` SET `DOC_NOTA`='"+nota.Replace(",",".")+"' WHERE  `IDDOCUMENTO`='"+id+"';");
        }

        //Metodo para Eliminar Documento
        public bool EliminarDocumento(string id)
        {
            return CONSULTA.OperarDatos("DELETE FROM `evadoc`.`documento` WHERE  `IDDOCUMENTO`='"+id+"';");
        }
    }
}