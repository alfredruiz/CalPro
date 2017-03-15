// ***********************************************************************
// CAPA DE ORM GENERADA AUTOMATICAMENTE DE LA TABLA [CalPro20].[dbo].[horastrabajadas]
// Generada por: Nombre del autor
// Fecha: 21/09/2016
// ***********************************************************************

using System;
using System.Data;
using System.Linq;

namespace CADCalPro
{
    public partial class HorasTrabajadas
	{
		#region "Propiedades"
		public int horastrabajadasID { get; set; }
		public int DiasVacacionesAnio { get; set; }
		public int DiasFestivosAnio { get; set; }
		public int DiasTrabajoSemana { get; set; }
		public int DiasFormacionAnio { get; set; }
		public int DiasAdmAnio { get; set; }
		public double HorasDiariasTrabajo { get; set; }
		public double HorasDiariasTrabNoProd { get; set; }
		public int ConsultaID { get; set; }
		#endregion

		#region "Mantenimiento o CRUD"
		private EnumerableRowCollection<HorasTrabajadas> GetCollectionFromDataTable(DataTable dt)
		{
			var iEnum = dt.AsEnumerable().Select(row => new HorasTrabajadas
			{
				horastrabajadasID = Convert.ToInt32(row["horastrabajadasID"]),
				DiasVacacionesAnio = Convert.ToInt32(row["DiasVacacionesAnio"]),
				DiasFestivosAnio = Convert.ToInt32(row["DiasFestivosAnio"]),
				DiasTrabajoSemana = Convert.ToInt32(row["DiasTrabajoSemana"]),
				DiasFormacionAnio = Convert.ToInt32(row["DiasFormacionAnio"]),
				DiasAdmAnio = Convert.ToInt32(row["DiasAdmAnio"]),
				HorasDiariasTrabajo = Convert.ToDouble(row["HorasDiariasTrabajo"]),
				HorasDiariasTrabNoProd = Convert.ToDouble(row["HorasDiariasTrabNoProd"]),
				ConsultaID = Convert.ToInt32(row["ConsultaID"])
			});
			return iEnum;
		}

		public EnumerableRowCollection<HorasTrabajadas> GetAll()
		{
			var dt = Conexion.GetDataTable("SELECT * FROM [CalPro20].[dbo].[horastrabajadas]");
			var iEnum = this.GetCollectionFromDataTable(dt);
			dt.Dispose();
			return iEnum;
		}

		public HorasTrabajadas Get(int clavePrimaria)
		{
			var dt = Conexion.GetDataTable($"SELECT * FROM [CalPro20].[dbo].[horastrabajadas] WHERE horastrabajadasID = {clavePrimaria}");
			var iEnum = this.GetCollectionFromDataTable(dt);
			dt.Dispose();
			return iEnum.FirstOrDefault();
		}

        public HorasTrabajadas GetLast()
        {
            var dt = Conexion.GetDataTable($"SELECT TOP 1 * FROM [CalPro20].[dbo].[horastrabajadas] order by horastrabajadasID desc");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }

        public int Add(HorasTrabajadas obj)
		{
			
            string SQL = $"INSERT INTO [CalPro20].[dbo].[horastrabajadas] (horastrabajadasID,DiasVacacionesAnio,DiasFestivosAnio,DiasTrabajoSemana,DiasFormacionAnio,DiasAdmAnio,HorasDiariasTrabajo,HorasDiariasTrabNoProd,ConsultaID) VALUES ({obj.horastrabajadasID},{obj.DiasVacacionesAnio},{obj.DiasFestivosAnio},{obj.DiasTrabajoSemana},{obj.DiasFormacionAnio},{obj.DiasAdmAnio},{obj.HorasDiariasTrabajo.ToString().Replace(",",".")},{obj.HorasDiariasTrabNoProd.ToString().Replace(",",".")},{obj.ConsultaID})";
			Conexion.ExecuteSQL(SQL);
			return obj.horastrabajadasID;
		}

		public int Update(HorasTrabajadas obj)
		{
			string SQL = $"UPDATE [CalPro20].[dbo].[horastrabajadas] SET horastrabajadasID={obj.horastrabajadasID},DiasVacacionesAnio={obj.DiasVacacionesAnio},DiasFestivosAnio={obj.DiasFestivosAnio},DiasTrabajoSemana={obj.DiasTrabajoSemana},DiasFormacionAnio={obj.DiasFormacionAnio},DiasAdmAnio={obj.DiasAdmAnio},HorasDiariasTrabajo={obj.HorasDiariasTrabajo.ToString().Replace(",",".")},HorasDiariasTrabNoProd={obj.HorasDiariasTrabNoProd.ToString().Replace(",",".")},ConsultaID={obj.ConsultaID} WHERE horastrabajadasID={obj.horastrabajadasID}";
			Conexion.ExecuteSQL(SQL);
			return obj.horastrabajadasID;
		}

		public bool Delete(int clavePrimaria)
		{
			string SQL = $"DELETE FROM [CalPro20].[dbo].[horastrabajadas] WHERE horastrabajadasID={clavePrimaria}";
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
