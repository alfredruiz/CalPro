// Punto de entrada de la aplicacion
// Los parentesis finales hacen que se autoinvoque la funcion al cargarse en el html
(function() {
    var app = angular.module('Cal2Pro', ['ngRoute','ui.bootstrap']);


    //===============================
    // FACTORY CON VARIABLES GLOBALES
    //===============================

  	 //factory, variables globales
	app.factory('globales', function() 
	{
	    var varGlobales = {};

	    //varGlobales.loginUsuario = {};
	    varGlobales.sesion = "";
	    varGlobales.loginUsuario = "";
	    varGlobales.Consulta = "";
	    varGlobales.Gastos = "";
	    varGlobales.CuantoGano = "";
	    varGlobales.Gasto = "";
	    varGlobales.HorasTrabajadas = "";
	    varGlobales.ParametroUrl = "";
	    varGlobales.Usuario = "";

        //urlWS para internet
	    //varGlobales.urlWS = "http://innovars.es/calprows/Service1.asmx/";

        //urlWS para localhost
	    varGlobales.urlWS = "http://localhost:1666/Service1.asmx/";
        varGlobales.urlCallBack = "?callback=JSON_CALLBACK";
        
		
  		return varGlobales;
	});
            
})();
