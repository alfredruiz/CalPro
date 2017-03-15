using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CADCalPro
{
    public class consultaCompleta
    {
        #region "Propiedades"
        public int ConsultaID { get; set; }
        public DateTime FechaEntrada { get; set; }
        public string nombreUsuario { get; set; }
        public int UsuarioID { get; set; }
        public string ip { get; set; }
        public double Hardware { get; set; }
        public double Software { get; set; }
        public double Rendimiento { get; set; }
        public double PrecioPalabra { get; set; }
        public int GastosID { get; set; }
        public int cuantoganoID { get; set; }
        public int horastrabajadasID { get; set; }
        public int DiasTrabajoSemana { get; set; }
        #endregion

        #region "Mantenimiento o CRUD"
        private EnumerableRowCollection<consultaCompleta> GetCollectionFromDataTable(DataTable dt)
        {
            var iEnum = dt.AsEnumerable().Select(row => new consultaCompleta
            {
                ConsultaID = Convert.ToInt32(row["ConsultaID"]),
                FechaEntrada = Convert.ToDateTime(row["FechaEntrada"]),
                nombreUsuario = row["nombreUsuario"].ToString(),
                UsuarioID = Convert.ToInt32(row["UsuarioID"]),
                ip = row["ip"].ToString(),
                Hardware = Convert.ToDouble(row["Hardware"]),
                Software = Convert.ToDouble(row["Software"]),
                Rendimiento = Convert.ToDouble(row["Rendimiento"]),
                PrecioPalabra = Convert.ToDouble(row["PrecioPalabra"]),
                GastosID = Convert.ToInt32(row["GastosID"]),
                cuantoganoID = Convert.ToInt32(row["cuantoganoID"]),
                horastrabajadasID = Convert.ToInt32(row["horastrabajadasID"]),
                DiasTrabajoSemana = Convert.ToInt32(row["DiasTrabajoSemana"])
            });
            return iEnum;
        }

        public EnumerableRowCollection<consultaCompleta> GetAll()
        {
            var dt = Conexion.GetDataTable("SELECT * FROM [CalPro20].[dbo].[consultacompleta] order by FechaEntrada desc");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum;
        }

        public consultaCompleta Get(string clavePrimaria)
        {
            var dt = Conexion.GetDataTable($"SELECT * FROM [CalPro20].[dbo].[consultacompleta] WHERE ConsultaID = {clavePrimaria}");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }

        public consultaCompleta GetLast()
        {
            var dt = Conexion.GetDataTable($"SELECT TOP 1 * FROM [CalPro20].[dbo].[consultacompleta] ORDER BY ConsultaID DESC");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }

        public consultaCompleta GetByUser(string nombreUsuario)
        {
            var dt = Conexion.GetDataTable($"SELECT * FROM [CalPro20].[dbo].[consultacompleta] WHERE nombreUsuario = '{nombreUsuario}'");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }

        public int Add(consultaCompleta obj)
        {
           
            string SQL = $"INSERT INTO [CalPro20].[dbo].[consultacompleta] (ConsultaID,FechaEntrada,nombreUsuario,UsuarioID,ip,Hardware,Software,Rendimiento,PrecioPalabra,GastosID,cuantoganoID,horastrabajadasID,DiasTrabajoSemana) VALUES ({obj.ConsultaID},'{obj.FechaEntrada}','{obj.nombreUsuario}',{obj.UsuarioID},'{obj.ip}',{obj.Hardware.ToString().Replace(",", ".")},{obj.Software.ToString().Replace(",", ".")},{obj.Rendimiento.ToString().Replace(",", ".")},{obj.PrecioPalabra.ToString().Replace(",", ".")},{obj.GastosID},{obj.cuantoganoID},{obj.horastrabajadasID},{obj.DiasTrabajoSemana})";
            Conexion.ExecuteSQL(SQL);
            return obj.ConsultaID;
        }

        public int Update(consultaCompleta obj)
        {
            string SQL = $"UPDATE [CalPro20].[dbo].[consultacompleta] SET ConsultaID={obj.ConsultaID},FechaEntrada='{obj.FechaEntrada}',nombreUsuario='{obj.nombreUsuario}',UsuarioID={obj.UsuarioID},ip='{obj.ip}',Hardware={obj.Hardware.ToString().Replace(",", ".")},Software={obj.Software.ToString().Replace(",", ".")},Rendimiento={obj.Rendimiento.ToString().Replace(",", ".")},PrecioPalabra={obj.PrecioPalabra.ToString().Replace(",", ".")},GastosID={obj.GastosID},cuantoganoID={obj.cuantoganoID},horastrabajadasID={obj.horastrabajadasID},DiasTrabajoSemana={obj.DiasTrabajoSemana} WHERE ConsultaID={obj.ConsultaID}";
            Conexion.ExecuteSQL(SQL);
            return obj.ConsultaID;
        }

        public bool Delete(int clavePrimaria)
        {
            string SQL = $"DELETE FROM [CalPro20].[dbo].[consultacompleta] WHERE ConsultaID={clavePrimaria}";
            Conexion.ExecuteSQL(SQL);
            return true;
        }


        #endregion

        #region "Dispose"
        bool disposed = false;
        System.Runtime.InteropServices.SafeHandle handle = new Microsoft.Win32.SafeHandles.SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) handle.Dispose();
            disposed = true;
        }
        #endregion
    }
}
