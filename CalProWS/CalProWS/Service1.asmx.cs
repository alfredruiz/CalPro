using CADCalPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CalProWS
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Name = "CalProWS", Description = "CalPro 2.0 Web Service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        public Service1()
        {

            //**CADENA CONEXION LOCAL**
            //CADCalPro.Conexion.CadenaConexion = @"Data Source=ALFREDO-VIRTUAL;Initial Catalog=CalPro20;Persist Security Info=True;User ID=alfredo;Password=alfredo";

            //**CADENA CONEXION DINAHOSTING**
            CADCalPro.Conexion.CadenaConexion = @"Data Source=sql.innovars.es;Initial Catalog=CalPro20;Persist Security Info=True;User ID=alfredo;Password=alfredo";

            /* Como el objeto CadaneConexión de la clase ClsConexion es estático es accesible desde cualquier lugar
             de la apliación, por tanto se le da contenido en la clase (web service) desde el que se va a utilizar.
             Para ello se ha cread una función pública con el nombre del servicio para que se inice de forma automática.*/
        }

        #region Login

        [WebMethod]
        public void SesionesVer(string callback)
        {
            var ses = new sesion();
            //var resul = ses.GetAll();

            var o = new JavaScriptSerializer();
            var json = o.Serialize(ses);

            /*  - se crea la variable usu para instanciar la clase Clsusuario
                - se iguala usu al método alojado en dicha clase
                - se crea la varible o como instancia de la función de serializacion
                - la variable json para serializar la instancia de clase usu
                - se devuelven json */

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        public void SesionesVerUna(string callback, string SesionID)
        {
            var ses = new sesion();
            //ses = ses.Get(SesionID);

            var o = new JavaScriptSerializer();
            var json = o.Serialize(ses.SesionID);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void SesionAgregar(string callback, string sesion)
        {
            var ses = new sesion();
            var o = new JavaScriptSerializer();
            ses = o.Deserialize<sesion>(sesion);

            /*  - Esta vez se pide un parámetro que llegará enviado por angularjs desde la aplicación web
                - se crea la variable usu para instanciar la clase Clsusuario
                - se iguala usu a la función de deserializar el parámetro usuario recibido y que se envía a la clase ClsUsuario
                - se llama al método Add pasándole usu ya deserializado como parámetro */
        }


        #endregion

        #region Métodos Clase Usuarios

        [WebMethod]
        public void UsuarioLogin(string callback, string correoElectronico, string contrasena)
        {
            var usu = new Usuario();
            usu = usu.LoginUsuario(correoElectronico, contrasena);

            //serializar a json                
            var o = new JavaScriptSerializer();
            var json = o.Serialize(usu);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        public void UsuariosVer(string callback)
        {
            var usu = new Usuario();
            var resul = usu.GetAll();

            var o = new JavaScriptSerializer();
            var json = o.Serialize(resul);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }


        [WebMethod]
        public void UsuariosVerUno(string callback, int usuarioID)
        {
            var usu = new Usuario();
            usu = usu.Get(usuarioID);

            var o = new JavaScriptSerializer();
            var json = o.Serialize(usu);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void UsuariosAgregar(string usuario)
        {
            var usu = new Usuario();
            var o = new JavaScriptSerializer();
            usu = o.Deserialize<Usuario>(usuario);
            usu.Add(usu);

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void UsuarioModificar(string usuario)
        {
            var usu = new Usuario();
            var o = new JavaScriptSerializer();
            usu = o.Deserialize<Usuario>(usuario);
            usu.Update(usu);
        }

        [WebMethod]
        public void UsuariosEliminar(int usuarioID)
        {
            var usu = new Usuario();
            usu = usu.Get(usuarioID);
            usu.Delete(usuarioID);
        }


        #endregion

        #region Métodos Clase Gastos

        [WebMethod]
        public void GastosVer(string callback)
        {
            var gas = new Gastos();
            var resul = gas.GetAll();

            var o = new JavaScriptSerializer();
            var json = o.Serialize(resul);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }


        [WebMethod]
        public void GastosVerUno(string callback, int gastosID)
        {
            var gas = new Gastos();
            gas = gas.Get(gastosID);

            var o = new JavaScriptSerializer();
            var json = o.Serialize(gas);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        public void GastosVerUltimo(string callback)
        {
            var gas = new Gastos();
            gas = gas.GetLast();

            var o = new JavaScriptSerializer();
            var json = o.Serialize(gas);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        public void GastosVerPorConsulta(string callback, int consultaID)
        {
            var gas = new Gastos();
            gas = gas.Get(consultaID);

            var o = new JavaScriptSerializer();
            var json = o.Serialize(gas);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public void GastosAgregar(string gastos)
        {
            var gas = new Gastos();
            var o = new JavaScriptSerializer();
            gas = o.Deserialize<Gastos>(gastos);
            gas.Add(gas);

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        //ScriptMethod indica al método que no se trata de un GET y así lo convierte en POST pudiendo recibir el JSON
        public void GastosModificar(string gastos)
        {
            var gas = new Gastos();
            var o = new JavaScriptSerializer();
            gas = o.Deserialize<Gastos>(gastos);
            gas.Update(gas);
        }

        [WebMethod]
        public void GastosEliminar(int gastosID)
        {
            var gas = new Gastos();
            gas = gas.Get(gastosID);
            gas.Delete(gastosID);
        }
        #endregion

        #region Métodos Clase CuantoGano

        [WebMethod]
        public void CuantoGanoVerTodo(string callback)
        {
            var gan = new CuantoGano();
            var resul = gan.GetAll();

            var o = new JavaScriptSerializer();
            var json = o.Serialize(resul);
            //o = null; usu = null;
            //return json;

            /*  - se crea la variable usu para instanciar la clase Clsusuario
                - se iguala usu al método alojado en dicha clase
                - se crea la varible o como instancia de la función de serializacion
                - la variable json para serializar la instancia de clase usu
                - se devuelven json */

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }


        [WebMethod]
        public void CuantoGanoVerUno(string callback, int cuantoganoID)
        {
            var gan = new CuantoGano();
            gan = gan.Get(cuantoganoID);

            var o = new JavaScriptSerializer();
            var json = o.Serialize(gan);
            //o = null; usu = null;
            //return json;

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public void CuantoGanoAgregar(string cuantogano)
        {
            var gan = new CuantoGano();
            var o = new JavaScriptSerializer();
            gan = o.Deserialize<CuantoGano>(cuantogano);
            gan.Add(gan);

            /*  - Esta vez se pide un parámetro que llegará enviado por angularjs desde la aplicación web
                - se crea la variable usu para instanciar la clase Clsusuario
                - se iguala usu a la función de deserializar el parámetro usuario recibido y que se envía a la clase ClsUsuario
                - se llama al método Add pasándole usu ya deserializado como parámetro */
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        //ScriptMethod indica al método que no se trata de un GET y así lo convierte en POST pudiendo recibir el JSON
        public void CuantoGanoModificar(string cuantogano)
        {
            var gan = new CuantoGano();
            var o = new JavaScriptSerializer();
            gan = o.Deserialize<CuantoGano>(cuantogano);
            gan.Update(gan);
        }

        [WebMethod]
        public void CuantoGanoEliminar(int cuantoganoID)
        {
            var gan = new CuantoGano();
            gan = gan.Get(cuantoganoID);
            gan.Delete(cuantoganoID);
        }

        #endregion

        #region Métodos clase Consultas
        [WebMethod]
        public void ConsultaAgregarVerUltima(string callback, string nombreUsuario)
        {
            //agregar consulta
            var con = new Consulta();
            con.Add(nombreUsuario);

            //Ver consulta completa
            var conComp = new consultaCompleta();
            var resul = conComp.GetLast();

            
            //var o = new JavaScriptSerializer();
            //var json = o.Serialize(resul);
            var json = ObjectToJSon(resul);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }



        [WebMethod]
        //[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public void ConsultaAgregar(string callback, string nombreUsuario)
        {
            var con = new Consulta();
            con.Add(nombreUsuario);

        }

        [WebMethod]
        public void ConsultasVerUltima(string callback)
        {
            var conComp = new consultaCompleta();
            var resul = conComp.GetLast();

            //var o = new JavaScriptSerializer();
            //var json = o.Serialize(resul);

            var json = ObjectToJSon(resul);


            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }


        [WebMethod]
        public void ConsultaEliminar(int consultaID)
        {
            var cons = new Consulta();
            cons = cons.Get(consultaID);
            cons.Delete(consultaID);
        }

        [WebMethod]
        public void ConsultasVerCompleta(string callback)
        {
            var conComp = new consultaCompleta();
            var resul = conComp.GetAll();

            //var o = new JavaScriptSerializer();
            //var json = o.Serialize(resul);

            var json = ObjectToJSon(resul);


            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        

        [WebMethod]
        public void ConsultasVerCompletaPorUsuario(string callback, string nombreUsuario)
        {

            var conComp = new consultaCompleta();
            conComp = conComp.GetByUser(nombreUsuario);

            //var o = new JavaScriptSerializer();
            //var json = o.Serialize(conComp);

            var json = ObjectToJSon(conComp);
            FormatearCadenaJSON(json);


            // Devolver a Ajax
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(callback + "(");
            //sb.Append(json);
            //sb.Append(");");

            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            //Context.Response.Charset = "utf-8";
            //Context.Response.Write(sb.ToString());
            //Context.Response.End();
        }
        #endregion

        #region Métodos Clase horas trabajadas

        [WebMethod]
        public void HorasTrabajadasVer(string callback)
        {
            var ht = new HorasTrabajadas();
            var resul = ht.GetAll();

            var o = new JavaScriptSerializer();
            var json = o.Serialize(resul);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }


        [WebMethod]
        public void HorasTrabajadasVerUno(string callback, int horastrabajadasID)
        {
            var ht = new HorasTrabajadas();
            ht = ht.Get(horastrabajadasID);

            var o = new JavaScriptSerializer();
            var json = o.Serialize(ht);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        public void HorasTrabajadasVerUltimo(string callback)
        {
            var ht = new HorasTrabajadas();
            ht = ht.GetLast();

            var o = new JavaScriptSerializer();
            var json = o.Serialize(ht);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        public void HorasTrabajadasVerPorConsulta(string callback, int consultaID)
        {
            var ht = new HorasTrabajadas();
            ht = ht.Get(consultaID);

            var o = new JavaScriptSerializer();
            var json = o.Serialize(ht);

            // Devolver a Ajax
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(callback + "(");
            sb.Append(json);
            sb.Append(");");

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Charset = "utf-8";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public void HorasTrabajadasAgregar(string horastrabajadas)
        {
            var ht = new HorasTrabajadas();
            var o = new JavaScriptSerializer();
            ht = o.Deserialize<HorasTrabajadas>(horastrabajadas);
            ht.Add(ht);

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        //ScriptMethod indica al método que no se trata de un GET y así lo convierte en POST pudiendo recibir el JSON
        public void HorasTrabajadasModificar(string horastrabajadas)
        {
            var ht = new HorasTrabajadas();
            var o = new JavaScriptSerializer();
            ht = o.Deserialize<HorasTrabajadas>(horastrabajadas);
            ht.Update(ht);
        }


        [WebMethod]
        public void HorasTrabajadasEliminar(int horastrabajadasID)
        {
            var ht = new HorasTrabajadas();
            ht = ht.Get(horastrabajadasID);
            ht.Delete(horastrabajadasID);
        }
        #endregion

        #region CONVERSIÓN DE JSON

        public static string ObjectToJSon(object objeto)
        {
            //CustomSerializer serializer = new CustomSerializer("yyyy-MM-dd HH:mm:ss");
            CustomSerializer serializer = new CustomSerializer("dd-MM-yyyy -- HH:mm:ss");

            var json = serializer.Serialize(objeto);
            json = FormatearCadenaJSON(json);
            serializer = null;
            return json;
        }

        private static string FormatearCadenaJSON(string json)
        {
            // Cambiar {"DateString": "fecha"} por solo la fecha
            int posFechaIni = json.IndexOf("{\"DateString\":");
            int posFechaFin = 0;
            while (posFechaIni >= 0)
            {
                posFechaFin = json.Substring(posFechaIni, json.Length - posFechaIni).IndexOf("}") + 1;
                string jsonOrigenString = json.Substring(posFechaIni, posFechaFin);
                string jsonDestinoString = jsonOrigenString.Replace("{\"DateString\":", "").Replace("}", "");
                json = json.Replace(jsonOrigenString, jsonDestinoString);
                json = json.Replace(" 00:00:00", "");
                // Siguiente fecha
                posFechaIni = json.IndexOf("{\"DateString\":");
            }
            // Devolver los true y false entre comillas
            json = json.Replace("true", "\"True\"");
            json = json.Replace("false", "\"False\"");
            // Resultado
            return json;
        }



        #endregion


    }
}