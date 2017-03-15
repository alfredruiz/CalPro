// ***********************************************************************
// CAPA DE ORM GENERADA AUTOMATICAMENTE DE LA TABLA [CalPro20].[dbo].[cuantogano]
// Generada por: Alfredo Ruiz
// Fecha: 29/08/2016
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CADCalPro
{
	public class CuantoGano
	{
		#region "Propiedades"
		public int cuantoganoID { get; set; }
		public double Rendimiento { get; set; }
		public double PrecioPalabra { get; set; }
		public int PagasAnual { get; set; }
		public double IRPF { get; set; }
        public int ConsultaID { get; set; }

        #endregion

        #region "Mantenimiento o CRUD"
        private EnumerableRowCollection<CuantoGano> GetCollectionFromDataTable(DataTable dt)
		{
			var iEnum = dt.AsEnumerable().Select(row => new CuantoGano
			{
				cuantoganoID = Convert.ToInt32(row["cuantoganoID"]),
				Rendimiento = Convert.ToDouble(row["Rendimiento"]),
				PrecioPalabra = Convert.ToDouble(row["PrecioPalabra"]),
				PagasAnual = Convert.ToInt32(row["PagasAnual"]),
				IRPF = Convert.ToDouble(row["IRPF"]),
                ConsultaID = Convert.ToInt32(row["ConsultaID"])

            });
			return iEnum;
		}

		public EnumerableRowCollection<CuantoGano> GetAll()
		{
			var dt = Conexion.GetDataTable("SELECT * FROM [CalPro20].[dbo].[cuantogano]");
			var iEnum = this.GetCollectionFromDataTable(dt);
			dt.Dispose();
			return iEnum;
		}

		public CuantoGano Get(int clavePrimaria)
		{
			var dt = Conexion.GetDataTable($"SELECT * FROM [CalPro20].[dbo].[cuantogano] WHERE cuantoganoID = {clavePrimaria}");
			var iEnum = this.GetCollectionFromDataTable(dt);
			dt.Dispose();
			return iEnum.FirstOrDefault();
		}

		public int Add(CuantoGano gan)
		{
           
            string SQL = $"INSERT INTO [CalPro20].[dbo].[cuantogano] (Rendimiento,PrecioPalabra,PagasAnual,IRPF, ConsultaID) VALUES ({gan.Rendimiento.ToString().Replace(",",".")},{gan.PrecioPalabra.ToString().Replace(",",".")},{gan.PagasAnual},{gan.IRPF.ToString().Replace(",",".")},{gan.ConsultaID})";
			Conexion.ExecuteSQL(SQL);
			return gan.cuantoganoID;
		}

		public int Update(CuantoGano gan)
		{
			string SQL = $"UPDATE [CalPro20].[dbo].[cuantogano] SET Rendimiento={gan.Rendimiento.ToString().Replace(",",".")},PrecioPalabra={gan.PrecioPalabra.ToString().Replace(",",".")},PagasAnual={gan.PagasAnual},IRPF={gan.IRPF.ToString().Replace(",",".")},ConsultaID={gan.ConsultaID} WHERE cuantoganoID={gan.cuantoganoID}";
			Conexion.ExecuteSQL(SQL);
			return gan.cuantoganoID;
		}

		public bool Delete(int clavePrimaria)
		{
			string SQL = $"DELETE FROM [CalPro20].[dbo].[cuantogano] WHERE cuantoganoID={clavePrimaria}";
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
