using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CADCalPro
{
    public class Consulta
    {
        #region "Propiedades"
        public int ConsultaID { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int UsuarioID { get; set; }
        #endregion

        #region "Mantenimiento o CRUD"
        private EnumerableRowCollection<Consulta> GetCollectionFromDataTable(DataTable dt)
        {
            var iEnum = dt.AsEnumerable().Select(row => new Consulta
            {
                ConsultaID = Convert.ToInt32(row["ConsultaID"]),
                FechaEntrada = Convert.ToDateTime(row["FechaEntrada"]),
                UsuarioID = Convert.ToInt32(row["UsuarioID"])
            });
            return iEnum;
        }

        private EnumerableRowCollection<Consulta> GetCollectionFromDataTableBis(DataTable dt)
        {
            var con = new Consulta();
            var iEnum = dt.AsEnumerable().Select(row => new Consulta
            {
                ConsultaID = Convert.ToInt32(row["ConsultaID"]),
                FechaEntrada = Convert.ToDateTime(row["FechaEntrada"]),
                UsuarioID = Convert.ToInt32(row["UsuarioID"])
            });
            return iEnum;
        }

        public EnumerableRowCollection<Consulta> GetAll()
        {
            var dt = Conexion.GetDataTable("SELECT * FROM [CalPro20].[dbo].[consulta]");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum;
        }


        public Consulta Get(int clavePrimaria)
        {
            var dt = Conexion.GetDataTable($"SELECT * FROM [CalPro20].[dbo].[consulta] WHERE ConsultaID = {clavePrimaria}");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }


        public Consulta GetLastConsult(int clavePrimaria)
        {
            var dt = Conexion.GetDataTable("SELECT TOP 1 * FROM [CalPro20].[dbo].[consulta] order by ConsultaID desc");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }

        public int Add(string nombreUsuario) //antes era Consulta con
        {
            var con = new Consulta();
			
            string SQL = ($"INSERT INTO [dbo].[consulta] ([FechaEntrada] ,[UsuarioID]) VALUES(getdate(),(SELECT UsuarioID FROM [dbo].[usuario] WHERE nombreUsuario = '"+nombreUsuario+"'))");
            string SQL2 = ($"insert into [dbo].[gastos] ([GastosID],[Hardware],[HardwareY],[Software],[SoftwareY],[MaterialConsultaAlta],[MaterialConsultaAltaY],[InstalTelefonoInternet],[InstalTelefonoInternetY],[AlquilerOficina],[AlquilerOficinaY],[MobiliarioOficina],[MobiliarioOficinaY],[ImagenProfesional],[ImagenProfesionalY],[GastosEstablVarios],[GastosEstablVariosY],[MaterialConsultaRenov],[MaterialConsultaRenovY],[HardwareRenov],[HardwareRenovY],[SoftwareRenov],[SoftwareRenovY],[Afiliaciones],[AfiliacionesY],[Proteccion],[ProteccionY],[DominioInternet],[DominioInternetY],[MaterialFungible],[MaterialFungibleY],[Formacion],[Publicidad],[PublicidadY],[FormacionY],[Imprevistos],[ImprevistosY],[PRL],[PRLY],[GastosAnualesVarios],[GastosAnualesVariosY],[AlquilerOficinaMensual],[AlquilerOficinaMensualY],[SeguridadSocial],[SeguridadSocialY],[SeguroMedico],[SeguroMedicoY],[LuzCalefaccion],[LuzCalefaccionY],[GestoriaLitigios],[GestoriaLitigiosY],[AsesoriaAveriasInf],[AsesoriaAveriasInfY],[AlojamientoWeb],[AlojamientoWebY],[TelefonoInternetMensual],[TelefonoInternetMensualY],[GastosMensualesVarios],[GastosMensualesVariosY],[ConsultaID],[GastosEstablicimTotal],[GastosAnualesTotal],[GastosMensualesTotal],[AmortizAnual],[GastosAnualesTotalAnual],[GatosMensualesTotalAnual]) VALUES ((SELECT TOP 1[ConsultaID] FROM [CalPro20].[dbo].[consulta] ORDER BY ConsultaID DESC),0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,(SELECT TOP 1[ConsultaID] FROM [CalPro20].[dbo].[consulta] ORDER BY ConsultaID DESC), 0, 0, 0, 0, 0, 0)");
            string SQL3 = ($"insert into [dbo].[cuantogano] ([cuantoganoID],[Rendimiento],[PrecioPalabra],[PagasAnual],[IRPF],[ConsultaID]) VALUES ((SELECT TOP 1[ConsultaID] FROM [CalPro20].[dbo].[consulta] ORDER BY ConsultaID DESC),0, 0, 0, 0, (SELECT TOP 1[ConsultaID] FROM [CalPro20].[dbo].[consulta] ORDER BY ConsultaID DESC))");
            string SQL4 = ($"insert into [dbo].[horastrabajadas] ([horastrabajadasID],[DiasVacacionesAnio],[DiasFestivosAnio],[DiasTrabajoSemana],[DiasFormacionAnio],[DiasAdmAnio],[HorasDiariasTrabajo],[HorasDiariasTrabNoProd],[ConsultaID]) VALUES((SELECT TOP 1[ConsultaID] FROM[CalPro20].[dbo].[consulta] ORDER BY ConsultaID DESC),0, 0, 0, 0, 0, 0, 0, (SELECT TOP 1[ConsultaID] FROM[CalPro20].[dbo].[consulta] ORDER BY ConsultaID DESC))");

            Conexion.ExecuteSQL(SQL);
            Conexion.ExecuteSQL(SQL2);
            Conexion.ExecuteSQL(SQL3);
            Conexion.ExecuteSQL(SQL4);

            return con.ConsultaID;
        }


        public int Update(Consulta con)
        {
            string SQL = "UPDATE [CalPro20].[dbo].[consulta] SET FechaEntrada='{con.FechaEntrada}',UsuarioID={con.UsuarioID} WHERE ConsultaID={con.ConsultaID}";
            Conexion.ExecuteSQL(SQL);
            return con.ConsultaID;
        }


        public bool Delete(int clavePrimaria)

        {
            try
            {
                // Validar datos        
                if (ConsultaID == 0) throw new ApplicationException("No se ha indicado registro para borrar.");
                // Eliminar

                string SQL = $"DELETE FROM [CalPro20].[dbo].[consulta] WHERE ConsultaID={clavePrimaria}";

                Conexion.ExecuteSQL(SQL);
                // Devolver
                return true;
            }
            catch (Exception)
            {
                throw;
            }
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