using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EvaDoc.AccesoDato.Conexion
{
    public class Conexion
    {
        //Cadena de Conexión
        private static MySqlConnection CONEXION = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        //Metodo de conexión con mysql
        protected static MySqlConnection Conectar()
        {
            try
            {
                CONEXION.Open();
            }
            catch 
            {
                CONEXION.Close();
                CONEXION.Open();
            }
            return CONEXION;
        }

        //Metodo de desconectar MySql
        protected static void Desconector()
        {
            CONEXION.Close();
        }

    }
}