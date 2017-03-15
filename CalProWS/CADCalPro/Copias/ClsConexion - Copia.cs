using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CADCalPro.App_Code
{
    public class ClsConexion
    {
        //asignamos variables para los datos
        protected SqlDataReader reader;
        protected SqlDataAdapter adaptadorDatos;
        protected DataSet data;
        public static SqlConnection conexion = new SqlConnection(); //el del tutorial lo ha llamado oconeccion

        public ClsConexion() { }


        //nuevo método para poeer accede de otras clases
        public void conectar(string tabla)  //recibe un string que es la tabla a la que va a conectar
        {
                        //indicamos la conexion que está en el web config que hace referencia al dataset
            string stringConexion = ConfigurationManager.ConnectionStrings["CalPro20ConnectionString"].ConnectionString;
                         //asignamos la info de conexion
            conexion.ConnectionString = stringConexion;
                          //abrimos la conexion
            conexion.Open();
                         //usamos el adaptador de datos con la consulta a realizsar en select
            adaptadorDatos = new SqlDataAdapter("select * from " + tabla, conexion);
                         //pàra ejecutar los comandos
            SqlCommandBuilder ejecutaComandos = new SqlCommandBuilder(adaptadorDatos);
                         //instancia del dataset
            Data = new DataSet();
            adaptadorDatos.Fill(Data, tabla);
                         //cerramos conexion
            conexion.Close();
        }

        public DataSet Data 
        {
            set { data = value; }
            get { return data; }
        }

        public SqlDataReader DataReader 
        {
            set { reader = value; }
            get { return reader; }
        }
    }
}