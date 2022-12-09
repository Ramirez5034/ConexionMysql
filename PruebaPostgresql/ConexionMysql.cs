
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PruebaMySQL
{
    class ConexionMysql
    {
        public static MySqlConnection conexion = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "pokemon";
        static string ususario = "root";
        static string password = "Sistermon";
        static string port = "3306";

        static String cadenaConexion = "server=" + servidor + ";" + "user id =" + ususario + ";" + "password=" + password + ";" + "port=" +port+ ";" + "database=" + bd + ";";

        private static void conectar()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                //MessageBox.Show("Se conecto correctamente la base de datos");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se puede conectar a la base de datos de PostgreSQL, error:" + e.ToString());
            }




        }

        public static DataTable ejecutaConsultaSelect(string consulta)
        {
            conectar();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public static void ejecutaConsulta(string consulta)
        {
            conectar();
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
