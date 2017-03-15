using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CADCalPro
{
    public class Gastos
    {

        public int GastosID { get; set; }

        //Gastos establecimiento

        public double Hardware { get; set; }
        public int HardwareY { get; set; }
        public double Software { get; set; }
        public int SoftwareY { get; set; }
        public double MaterialConsultaAlta { get; set; }
        public int MaterialConsultaAltaY { get; set; }
        public double InstalTelefonoInternet { get; set; }
        public int InstalTelefonoInternetY { get; set; }
        public double AlquilerOficina { get; set; }
        public int AlquilerOficinaY { get; set; }
        public double MobiliarioOficina { get; set; }
        public int MobiliarioOficinaY { get; set; }
        public double ImagenProfesional { get; set; }
        public int ImagenProfesionalY { get; set; }
        public double GastosEstablVarios { get; set; }
        public int GastosEstablVariosY { get; set; }

        //Gastos anuales

        public double MaterialConsultaRenov { get; set; }
        public int MaterialConsultaRenovY { get; set; }
        public double HardwareRenov { get; set; }
        public int HardwareRenovY { get; set; }
        public double SoftwareRenov { get; set; }
        public int SoftwareRenovY { get; set; }
        public double Afiliaciones { get; set; }
        public int AfiliacionesY { get; set; }
        public double Proteccion { get; set; }
        public int ProteccionY { get; set; }
        public double DominioInternet { get; set; }
        public int DominioInternetY { get; set; }
        public double MaterialFungible { get; set; }
        public int MaterialFungibleY { get; set; }
        public double Formacion { get; set; }
        public int FormacionY { get; set; }
        public double Publicidad { get; set; }
        public int PublicidadY { get; set; }
        public double Imprevistos { get; set; }
        public int ImprevistosY { get; set; }
        public double PRL { get; set; }
        public int PRLY { get; set; }
        public double GastosAnualesVarios { get; set; }
        public int GastosAnualesVariosY { get; set; }

        //Gastos mensuales

        public double AlquilerOficinaMensual { get; set; }
        public int AlquilerOficinaMensualY { get; set; }
        public double SeguridadSocial { get; set; }
        public int SeguridadSocialY { get; set; }
        public double SeguroMedico { get; set; }
        public int SeguroMedicoY { get; set; }
        public double LuzCalefaccion { get; set; }
        public int LuzCalefaccionY { get; set; }
        public double GestoriaLitigios { get; set; }
        public int GestoriaLitigiosY { get; set; }
        public double AsesoriaAveriasInf { get; set; }
        public int AsesoriaAveriasInfY { get; set; }
        public double AlojamientoWeb { get; set; }
        public int AlojamientoWebY { get; set; }
        public double TelefonoInternetMensual { get; set; }
        public int TelefonoInternetMensualY { get; set; }
        public double GastosMensualesVarios { get; set; }
        public int GastosMensualesVariosY { get; set; }

        public int ConsultaID { get; set; }

        public double GastosEstablicimTotal { get; set; }
        public double GastosAnualesTotal { get; set; }
        public double GastosMensualesTotal { get; set; }
        public double AmortizAnual { get; set; }
        public double GastosAnualesTotalAnual { get; set; }
        public double GatosMensualesTotalAnual { get; set; }


        /* MÉTODOS */

        private string ValidationErrors(Gastos gas)
        {
            string errores = "";

            if (gas.Hardware == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.HardwareY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.Software == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.SoftwareY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.MaterialConsultaAlta == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.MaterialConsultaAltaY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.InstalTelefonoInternet == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.InstalTelefonoInternetY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.AlquilerOficina == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.AlquilerOficinaY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.MobiliarioOficina == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.MobiliarioOficinaY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.ImagenProfesional == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.ImagenProfesionalY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.GastosEstablVarios == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.GastosEstablVariosY == 0) errores += "Debe introducir una cantidad válida\r\n";

            //Gastos anuales

            if (gas.MaterialConsultaRenov == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.MaterialConsultaRenovY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.HardwareRenov == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.HardwareRenovY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.SoftwareRenov == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.SoftwareRenovY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.Afiliaciones == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.AfiliacionesY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.Proteccion == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.ProteccionY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.DominioInternet == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.DominioInternetY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.MaterialFungible == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.MaterialFungibleY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.Formacion == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.FormacionY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.Publicidad == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.PublicidadY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.Imprevistos == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.ImprevistosY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.PRL == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.PRLY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.GastosAnualesVarios == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.GastosAnualesVariosY == 0) errores += "Debe introducir una cantidad válida\r\n";

            //Gastos mensuales

            if (gas.AlquilerOficinaMensual == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.AlquilerOficinaMensualY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.SeguridadSocial == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.SeguridadSocialY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.SeguroMedico == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.SeguroMedicoY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.LuzCalefaccion == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.LuzCalefaccionY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.GestoriaLitigios == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.GestoriaLitigiosY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.AsesoriaAveriasInf == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.AsesoriaAveriasInfY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.AlojamientoWeb == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.AlojamientoWebY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.TelefonoInternetMensual == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.TelefonoInternetMensualY == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.GastosMensualesVarios == 0) errores += "Debe introducir una cantidad válida\r\n"; if (gas.GastosMensualesVariosY == 0) errores += "Debe introducir una cantidad válida\r\n";

            if (gas.ConsultaID == 0) errores += "Debe introducir una cantidad válida\r\n";

            //¿validar?
            if (gas.GastosEstablicimTotal == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.GastosAnualesTotal == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.GastosMensualesTotal == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.AmortizAnual == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.GastosAnualesTotalAnual == 0) errores += "Debe introducir una cantidad válida\r\n";
            if (gas.GatosMensualesTotalAnual == 0) errores += "Debe introducir una cantidad válida\r\n";


            return errores;
        }

        private EnumerableRowCollection<Gastos> GetCollectionFromDataTable(DataTable dt)
        {
            var con = new Conexion();
            var iEnum = dt.AsEnumerable().Select(row => new Gastos
            {
                GastosID = (row["GastosID"] != null) ? Convert.ToInt32(row["GastosID"]) : 0,
                Hardware = (row["Hardware"] != null) ? Convert.ToDouble(row["Hardware"]) : 0,
                HardwareY = (row["HardwareY"] != null) ? Convert.ToInt32(row["HardwareY"]) : 0,
                Software = (row["Software"] != null) ? Convert.ToDouble(row["Software"]) : 0,
                SoftwareY = (row["SoftwareY"] != null) ? Convert.ToInt32(row["SoftwareY"]) : 0,
                MaterialConsultaAlta = (row["MaterialConsultaAlta"] != null) ? Convert.ToDouble(row["MaterialConsultaAlta"]) : 0,
                MaterialConsultaAltaY = (row["MaterialConsultaAltaY"] != null) ? Convert.ToInt32(row["MaterialConsultaAltaY"]) : 0,
                InstalTelefonoInternet = (row["InstalTelefonoInternet"] != null) ? Convert.ToDouble(row["InstalTelefonoInternet"]) : 0,
                InstalTelefonoInternetY = (row["InstalTelefonoInternetY"] != null) ? Convert.ToInt32(row["InstalTelefonoInternetY"]) : 0,
                AlquilerOficina = (row["AlquilerOficina"] != null) ? Convert.ToDouble(row["AlquilerOficina"]) : 0,
                AlquilerOficinaY = (row["AlquilerOficinaY"] != null) ? Convert.ToInt32(row["AlquilerOficinaY"]) : 0,
                MobiliarioOficina = (row["MobiliarioOficina"] != null) ? Convert.ToDouble(row["MobiliarioOficina"]) : 0,
                MobiliarioOficinaY = (row["MobiliarioOficinaY"] != null) ? Convert.ToInt32(row["MobiliarioOficinaY"]) : 0,
                ImagenProfesional = (row["ImagenProfesional"] != null) ? Convert.ToDouble(row["ImagenProfesional"]) : 0,
                ImagenProfesionalY = (row["ImagenProfesionalY"] != null) ? Convert.ToInt32(row["ImagenProfesionalY"]) : 0,
                GastosEstablVarios = (row["GastosEstablVarios"] != null) ? Convert.ToDouble(row["GastosEstablVarios"]) : 0,
                GastosEstablVariosY = (row["GastosEstablVariosY"] != null) ? Convert.ToInt32(row["GastosEstablVariosY"]) : 0,
                MaterialConsultaRenov = (row["MaterialConsultaRenov"] != null) ? Convert.ToDouble(row["MaterialConsultaRenov"]) : 0,
                MaterialConsultaRenovY = (row["MaterialConsultaRenovY"] != null) ? Convert.ToInt32(row["MaterialConsultaRenovY"]) : 0,
                HardwareRenov = (row["HardwareRenov"] != null) ? Convert.ToDouble(row["HardwareRenov"]) : 0,
                HardwareRenovY = (row["HardwareRenovY"] != null) ? Convert.ToInt32(row["HardwareRenovY"]) : 0,
                SoftwareRenov = (row["SoftwareRenov"] != null) ? Convert.ToDouble(row["SoftwareRenov"]) : 0,
                SoftwareRenovY = (row["SoftwareRenovY"] != null) ? Convert.ToInt32(row["SoftwareRenovY"]) : 0,
                Afiliaciones = (row["Afiliaciones"] != null) ? Convert.ToDouble(row["Afiliaciones"]) : 0,
                AfiliacionesY = (row["AfiliacionesY"] != null) ? Convert.ToInt32(row["AfiliacionesY"]) : 0,
                Proteccion = (row["Proteccion"] != null) ? Convert.ToDouble(row["Proteccion"]) : 0,
                ProteccionY = (row["ProteccionY"] != null) ? Convert.ToInt32(row["ProteccionY"]) : 0,
                DominioInternet = (row["DominioInternet"] != null) ? Convert.ToDouble(row["DominioInternet"]) : 0,
                DominioInternetY = (row["DominioInternetY"] != null) ? Convert.ToInt32(row["DominioInternetY"]) : 0,
                MaterialFungible = (row["MaterialFungible"] != null) ? Convert.ToDouble(row["MaterialFungible"]) : 0,
                MaterialFungibleY = (row["MaterialFungibleY"] != null) ? Convert.ToInt32(row["MaterialFungibleY"]) : 0,
                Formacion = (row["Formacion"] != null) ? Convert.ToDouble(row["Formacion"]) : 0,
                Publicidad = (row["Publicidad"] != null) ? Convert.ToDouble(row["Publicidad"]) : 0,
                PublicidadY = (row["PublicidadY"] != null) ? Convert.ToInt32(row["PublicidadY"]) : 0,
                FormacionY = (row["FormacionY"] != null) ? Convert.ToInt32(row["FormacionY"]) : 0,
                Imprevistos = (row["Imprevistos"] != null) ? Convert.ToDouble(row["Imprevistos"]) : 0,
                ImprevistosY = (row["ImprevistosY"] != null) ? Convert.ToInt32(row["ImprevistosY"]) : 0,
                PRL = (row["PRL"] != null) ? Convert.ToDouble(row["PRL"]) : 0,
                PRLY = (row["PRLY"] != null) ? Convert.ToInt32(row["PRLY"]) : 0,
                GastosAnualesVarios = (row["GastosAnualesVarios"] != null) ? Convert.ToDouble(row["GastosAnualesVarios"]) : 0,
                GastosAnualesVariosY = (row["GastosAnualesVariosY"] != null) ? Convert.ToInt32(row["GastosAnualesVariosY"]) : 0,
                AlquilerOficinaMensual = (row["AlquilerOficinaMensual"] != null) ? Convert.ToDouble(row["AlquilerOficinaMensual"]) : 0,
                AlquilerOficinaMensualY = (row["AlquilerOficinaMensualY"] != null) ? Convert.ToInt32(row["AlquilerOficinaMensualY"]) : 0,
                SeguridadSocial = (row["SeguridadSocial"] != null) ? Convert.ToDouble(row["SeguridadSocial"]) : 0,
                SeguridadSocialY = (row["SeguridadSocialY"] != null) ? Convert.ToInt32(row["SeguridadSocialY"]) : 0,
                SeguroMedico = (row["SeguroMedico"] != null) ? Convert.ToDouble(row["SeguroMedico"]) : 0,
                SeguroMedicoY = (row["SeguroMedicoY"] != null) ? Convert.ToInt32(row["SeguroMedicoY"]) : 0,
                LuzCalefaccion = (row["LuzCalefaccion"] != null) ? Convert.ToDouble(row["LuzCalefaccion"]) : 0,
                LuzCalefaccionY = (row["LuzCalefaccionY"] != null) ? Convert.ToInt32(row["LuzCalefaccionY"]) : 0,
                GestoriaLitigios = (row["GestoriaLitigios"] != null) ? Convert.ToDouble(row["GestoriaLitigios"]) : 0,
                GestoriaLitigiosY = (row["GestoriaLitigiosY"] != null) ? Convert.ToInt32(row["GestoriaLitigiosY"]) : 0,
                AsesoriaAveriasInf = (row["AsesoriaAveriasInf"] != null) ? Convert.ToDouble(row["AsesoriaAveriasInf"]) : 0,
                AsesoriaAveriasInfY = (row["AsesoriaAveriasInfY"] != null) ? Convert.ToInt32(row["AsesoriaAveriasInfY"]) : 0,
                AlojamientoWeb = (row["AlojamientoWeb"] != null) ? Convert.ToDouble(row["AlojamientoWeb"]) : 0,
                AlojamientoWebY = (row["AlojamientoWebY"] != null) ? Convert.ToInt32(row["AlojamientoWebY"]) : 0,
                TelefonoInternetMensual = (row["TelefonoInternetMensual"] != null) ? Convert.ToDouble(row["TelefonoInternetMensual"]) : 0,
                TelefonoInternetMensualY = (row["TelefonoInternetMensualY"] != null) ? Convert.ToInt32(row["TelefonoInternetMensualY"]) : 0,
                GastosMensualesVarios = (row["GastosMensualesVarios"] != null) ? Convert.ToDouble(row["GastosMensualesVarios"]) : 0,
                GastosMensualesVariosY = (row["GastosMensualesVariosY"] != null) ? Convert.ToInt32(row["GastosMensualesVariosY"]) : 0,
                ConsultaID = (row["ConsultaID"] != null) ? Convert.ToInt32(row["ConsultaID"]) : 0,
                GastosEstablicimTotal = (row["GastosEstablicimTotal"] != null) ? Convert.ToDouble(row["GastosEstablicimTotal"]) : 0,
                GastosAnualesTotal = (row["GastosAnualesTotal"] != null) ? Convert.ToDouble(row["GastosAnualesTotal"]) : 0,
                GastosMensualesTotal = (row["GastosMensualesTotal"] != null) ? Convert.ToDouble(row["GastosMensualesTotal"]) : 0,
                AmortizAnual = (row["AmortizAnual"] != null) ? Convert.ToDouble(row["AmortizAnual"]) : 0,
                GastosAnualesTotalAnual = (row["GastosAnualesTotalAnual"] != null) ? Convert.ToDouble(row["GastosAnualesTotalAnual"]) : 0,
                GatosMensualesTotalAnual = (row["GatosMensualesTotalAnual"] != null) ? Convert.ToDouble(row["GatosMensualesTotalAnual"]) : 0
            });
            return iEnum;
        }

        
        public EnumerableRowCollection<Gastos> GetAll()
        {
            var dt = Conexion.GetDataTable("SELECT * FROM [CalPro20].[dbo].[gastos]");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum;
        }

        public Gastos Get(int clavePrimaria)
        {
            var dt = Conexion.GetDataTable($"SELECT * FROM [CalPro20].[dbo].[gastos] WHERE GastosID = {clavePrimaria}");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }

        public Gastos GetLast()
        {
            var dt = Conexion.GetDataTable($"SELECT TOP 1 * FROM [CalPro20].[dbo].[gastos] order by GastosID desc");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }
        public Gastos GetByConsult(int consultaID)
        {
            var dt = Conexion.GetDataTable($"SELECT * FROM [CalPro20].[dbo].[gastos] WHERE ConsultaID = {consultaID}");
            var iEnum = this.GetCollectionFromDataTable(dt);
            dt.Dispose();
            return iEnum.FirstOrDefault();
        }

        //public string Add(Gastos gas)
        public int Add(Gastos gas)

        {
            string SQL = $"INSERT INTO [CalPro20].[dbo].[gastos] (Hardware,HardwareY,Software,SoftwareY,MaterialConsultaAlta,MaterialConsultaAltaY,InstalTelefonoInternet,InstalTelefonoInternetY,AlquilerOficina,AlquilerOficinaY,MobiliarioOficina,MobiliarioOficinaY,ImagenProfesional,ImagenProfesionalY,GastosEstablVarios,GastosEstablVariosY,MaterialConsultaRenov,MaterialConsultaRenovY,HardwareRenov,HardwareRenovY,SoftwareRenov,SoftwareRenovY,Afiliaciones,AfiliacionesY,Proteccion,ProteccionY,DominioInternet,DominioInternetY,MaterialFungible,MaterialFungibleY,Formacion,Publicidad,PublicidadY,FormacionY,Imprevistos,ImprevistosY,PRL,PRLY,GastosAnualesVarios,GastosAnualesVariosY,AlquilerOficinaMensual,AlquilerOficinaMensualY,SeguridadSocial,SeguridadSocialY,SeguroMedico,SeguroMedicoY,LuzCalefaccion,LuzCalefaccionY,GestoriaLitigios,GestoriaLitigiosY,AsesoriaAveriasInf,AsesoriaAveriasInfY,AlojamientoWeb,AlojamientoWebY,TelefonoInternetMensual,TelefonoInternetMensualY,GastosMensualesVarios,GastosMensualesVariosY,ConsultaID,GastosEstablicimTotal,GastosAnualesTotal,GastosMensualesTotal,AmortizAnual,GastosAnualesTotalAnual,GatosMensualesTotalAnual) VALUES ({gas.Hardware.ToString().Replace(",", ".")},{gas.HardwareY},{gas.Software.ToString().Replace(",", ".")},{gas.SoftwareY},{gas.MaterialConsultaAlta.ToString().Replace(",", ".")},{gas.MaterialConsultaAltaY},{gas.InstalTelefonoInternet.ToString().Replace(",", ".")},{gas.InstalTelefonoInternetY},{gas.AlquilerOficina.ToString().Replace(",", ".")},{gas.AlquilerOficinaY},{gas.MobiliarioOficina.ToString().Replace(",", ".")},{gas.MobiliarioOficinaY},{gas.ImagenProfesional.ToString().Replace(",", ".")},{gas.ImagenProfesionalY},{gas.GastosEstablVarios.ToString().Replace(",", ".")},{gas.GastosEstablVariosY},{gas.MaterialConsultaRenov.ToString().Replace(",", ".")},{gas.MaterialConsultaRenovY},{gas.HardwareRenov.ToString().Replace(",", ".")},{gas.HardwareRenovY},{gas.SoftwareRenov.ToString().Replace(",", ".")},{gas.SoftwareRenovY},{gas.Afiliaciones.ToString().Replace(",", ".")},{gas.AfiliacionesY},{gas.Proteccion.ToString().Replace(",", ".")},{gas.ProteccionY},{gas.DominioInternet.ToString().Replace(",", ".")},{gas.DominioInternetY},{gas.MaterialFungible.ToString().Replace(",", ".")},{gas.MaterialFungibleY},{gas.Formacion.ToString().Replace(",", ".")},{gas.Publicidad.ToString().Replace(",", ".")},{gas.PublicidadY},{gas.FormacionY},{gas.Imprevistos.ToString().Replace(",", ".")},{gas.ImprevistosY},{gas.PRL.ToString().Replace(",", ".")},{gas.PRLY},{gas.GastosAnualesVarios.ToString().Replace(",", ".")},{gas.GastosAnualesVariosY},{gas.AlquilerOficinaMensual.ToString().Replace(",", ".")},{gas.AlquilerOficinaMensualY},{gas.SeguridadSocial.ToString().Replace(",", ".")},{gas.SeguridadSocialY},{gas.SeguroMedico.ToString().Replace(",", ".")},{gas.SeguroMedicoY},{gas.LuzCalefaccion.ToString().Replace(",", ".")},{gas.LuzCalefaccionY},{gas.GestoriaLitigios.ToString().Replace(",", ".")},{gas.GestoriaLitigiosY},{gas.AsesoriaAveriasInf.ToString().Replace(",", ".")},{gas.AsesoriaAveriasInfY},{gas.AlojamientoWeb.ToString().Replace(",", ".")},{gas.AlojamientoWebY},{gas.TelefonoInternetMensual.ToString().Replace(",", ".")},{gas.TelefonoInternetMensualY},{gas.GastosMensualesVarios.ToString().Replace(",", ".")},{gas.GastosMensualesVariosY},{gas.ConsultaID},{gas.GastosEstablicimTotal.ToString().Replace(",", ".")},{gas.GastosAnualesTotal.ToString().Replace(",", ".")},{gas.GastosMensualesTotal.ToString().Replace(",", ".")},{gas.AmortizAnual.ToString().Replace(",", ".")},{gas.GastosAnualesTotalAnual.ToString().Replace(",", ".")},{gas.GatosMensualesTotalAnual.ToString().Replace(",", ".")})";
            
            Conexion.ExecuteSQL(SQL);
            // Devolver
            //return (gas.GastosID).ToString();
            return gas.GastosID;

        }

        //public string Update(Gastos gas)
        public int Update(Gastos gas)
        {
            string SQL = $"UPDATE [CalPro20].[dbo].[gastos] SET Hardware={gas.Hardware.ToString().Replace(",", ".")},HardwareY={gas.HardwareY},Software={gas.Software.ToString().Replace(",", ".")},SoftwareY={gas.SoftwareY},MaterialConsultaAlta={gas.MaterialConsultaAlta.ToString().Replace(",", ".")},MaterialConsultaAltaY={gas.MaterialConsultaAltaY},InstalTelefonoInternet={gas.InstalTelefonoInternet.ToString().Replace(",", ".")},InstalTelefonoInternetY={gas.InstalTelefonoInternetY},AlquilerOficina={gas.AlquilerOficina.ToString().Replace(",", ".")},AlquilerOficinaY={gas.AlquilerOficinaY},MobiliarioOficina={gas.MobiliarioOficina.ToString().Replace(",", ".")},MobiliarioOficinaY={gas.MobiliarioOficinaY},ImagenProfesional={gas.ImagenProfesional.ToString().Replace(",", ".")},ImagenProfesionalY={gas.ImagenProfesionalY},GastosEstablVarios={gas.GastosEstablVarios.ToString().Replace(",", ".")},GastosEstablVariosY={gas.GastosEstablVariosY},MaterialConsultaRenov={gas.MaterialConsultaRenov.ToString().Replace(",", ".")},MaterialConsultaRenovY={gas.MaterialConsultaRenovY},HardwareRenov={gas.HardwareRenov.ToString().Replace(",", ".")},HardwareRenovY={gas.HardwareRenovY},SoftwareRenov={gas.SoftwareRenov.ToString().Replace(",", ".")},SoftwareRenovY={gas.SoftwareRenovY},Afiliaciones={gas.Afiliaciones.ToString().Replace(",", ".")},AfiliacionesY={gas.AfiliacionesY},Proteccion={gas.Proteccion.ToString().Replace(",", ".")},ProteccionY={gas.ProteccionY},DominioInternet={gas.DominioInternet.ToString().Replace(",", ".")},DominioInternetY={gas.DominioInternetY},MaterialFungible={gas.MaterialFungible.ToString().Replace(",", ".")},MaterialFungibleY={gas.MaterialFungibleY},Formacion={gas.Formacion.ToString().Replace(",", ".")},Publicidad={gas.Publicidad.ToString().Replace(",", ".")},PublicidadY={gas.PublicidadY},FormacionY={gas.FormacionY},Imprevistos={gas.Imprevistos.ToString().Replace(",", ".")},ImprevistosY={gas.ImprevistosY},PRL={gas.PRL.ToString().Replace(",", ".")},PRLY={gas.PRLY},GastosAnualesVarios={gas.GastosAnualesVarios.ToString().Replace(",", ".")},GastosAnualesVariosY={gas.GastosAnualesVariosY},AlquilerOficinaMensual={gas.AlquilerOficinaMensual.ToString().Replace(",", ".")},AlquilerOficinaMensualY={gas.AlquilerOficinaMensualY},SeguridadSocial={gas.SeguridadSocial.ToString().Replace(",", ".")},SeguridadSocialY={gas.SeguridadSocialY},SeguroMedico={gas.SeguroMedico.ToString().Replace(",", ".")},SeguroMedicoY={gas.SeguroMedicoY},LuzCalefaccion={gas.LuzCalefaccion.ToString().Replace(",", ".")},LuzCalefaccionY={gas.LuzCalefaccionY},GestoriaLitigios={gas.GestoriaLitigios.ToString().Replace(",", ".")},GestoriaLitigiosY={gas.GestoriaLitigiosY},AsesoriaAveriasInf={gas.AsesoriaAveriasInf.ToString().Replace(",", ".")},AsesoriaAveriasInfY={gas.AsesoriaAveriasInfY},AlojamientoWeb={gas.AlojamientoWeb.ToString().Replace(",", ".")},AlojamientoWebY={gas.AlojamientoWebY},TelefonoInternetMensual={gas.TelefonoInternetMensual.ToString().Replace(",", ".")},TelefonoInternetMensualY={gas.TelefonoInternetMensualY},GastosMensualesVarios={gas.GastosMensualesVarios.ToString().Replace(",", ".")},GastosMensualesVariosY={gas.GastosMensualesVariosY},ConsultaID={gas.ConsultaID},GastosEstablicimTotal={gas.GastosEstablicimTotal.ToString().Replace(",", ".")},GastosAnualesTotal={gas.GastosAnualesTotal.ToString().Replace(",", ".")},GastosMensualesTotal={gas.GastosMensualesTotal.ToString().Replace(",", ".")},AmortizAnual={gas.AmortizAnual.ToString().Replace(",", ".")},GastosAnualesTotalAnual={gas.GastosAnualesTotalAnual.ToString().Replace(",", ".")},GatosMensualesTotalAnual={gas.GatosMensualesTotalAnual.ToString().Replace(",", ".")} WHERE GastosID={gas.GastosID}";
            
            Conexion.ExecuteSQL(SQL);
            // Devolver
            //return (gas.GastosID).ToString();
            return gas.GastosID;
        }

        //public bool Delete(int gastosID)
        public bool Delete(int clavePrimaria)

        {
            try
            {
                // Validar datos        
                if (GastosID == 0) throw new ApplicationException("No se ha indicado registro para borrar.");
                // Eliminar

                string SQL = $"DELETE FROM [CalPro20].[dbo].[gastos] WHERE GastosID={clavePrimaria}";

                Conexion.ExecuteSQL(SQL);
                // Devolver
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}