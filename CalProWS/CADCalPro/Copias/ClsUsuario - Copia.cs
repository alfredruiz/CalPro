using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace CADCalPro.App_Code
{
    public class ClsUsuario: ClsConexion //hereda de ClsConexion
    {
        string tablaUsuario = "usuario"; //nombre de la tabla usuario
        //atributos para guardar los datos
        protected string nombreUsuario, correoElectronico, contrasena;
        protected int usuarioID;


        public ClsUsuario(int _usuarioID, string _nombreUsuario, string _correoElectronico, string _contrasena)
        {
            //inicalizamos los atributos para captura los valores.
            this.usuarioID = _usuarioID;
            this.nombreUsuario = _nombreUsuario;
            this.correoElectronico = _correoElectronico;
            this.contrasena = _contrasena;
        }

        //métodos para establcer y recuperar datos. Cremos un método por cada atributo
        public int UsuarioID 
        {
            set { usuarioID = value;}
            get { return usuarioID; }
        }
        public string NombreUsuario
        {
            set { nombreUsuario = value; }
            get { return nombreUsuario; }
        }
        public string CorreoElectronico
        {
            set { correoElectronico = value; }
            get { return correoElectronico; }
        }
        public string Contrasena
        {
            set { contrasena = value; }
            get { return contrasena; }
        }

        //método agregar registros
        public void agregar() 
        {
            conectar(tablaUsuario); //método de la clase conexion
            DataRow fila;
            fila = Data.Tables[tablaUsuario].NewRow();
            fila["usuarioID"] = UsuarioID;
            fila["nombreUsuario"] = NombreUsuario; //referencia al método global
            fila["correoElectronico"] = CorreoElectronico;
            fila["contrasena"] = Contrasena;

            Data.Tables[tablaUsuario].Rows.Add(fila);
            adaptadorDatos.Update(Data, tablaUsuario);
        }

    }
}