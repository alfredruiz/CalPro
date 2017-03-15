//===============================
// CONFIG CON RUTAS
//===============================
angular
.module('Cal2Pro')
.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'parcial/home.html',
            controller: 'inicioCtrl',
        })

        //gastos
        .when('/gastos', {
            templateUrl: 'gastos/gastos.html',
            controller: 'gastosCtrl',
            controllerAs: 'vm'
        })
        .when('/gasto', {
            templateUrl: 'gastos/gasto.html',
            controller: 'gastoCtrl',
            controllerAs: 'vm'
        })
        .when('/gasto/:GastosID', {
            templateUrl: 'gastos/gasto.html',
            controller: 'gastoCtrl',
            controllerAs: 'vm'
        })

        .when('/gasto/:consultaID', {
            templateUrl: 'gastos/gasto.html',
            controller: 'consultaCtrl',
            controllerAs: 'vm'
        })

        //cuanto gano
        .when('/cuantoganolista', {
            templateUrl: 'cuantogano/cuantoganoall.html',
            controller: 'cuantoganoallCtrl',
            controllerAs: 'vm'
        })
        .when('/cuantogano', {
            templateUrl: 'cuantogano/cuantogano.html',
            controller: 'cuantoganoCtrl',
            controllerAs: 'vm'
        })
        .when('/cuantogano/:cuantoganoID', {
            templateUrl: 'cuantogano/cuantogano.html',
            controller: 'cuantoganoCtrl',
            controllerAs: 'vm'
        })
        .when('/cuantogano/:consultaID', {
            templateUrl: 'cuantogano/cuantogano.html',
            controller: 'consultaCtrl',
            controllerAs: 'vm'
        })

        //horas trabajadas

        .when('/horastrabajadas', {
            templateUrl: 'horastrabajadas/horastrabajadas.html',
            controller: 'horastrabajadasCtrl',
            controllerAs: 'vm'
        })
        .when('/horastrabajadas/:horastrabajadasID', {
            templateUrl: 'horastrabajadas/horastrabajadas.html',
            controller: 'horastrabajadasCtrl',
            controllerAs: 'vm'
        })

        //usuarios y login
        .when('/usuarios', {
            templateUrl: 'usuarios/usuarios.html',
            controller: 'usuariosCtrl',
            controllerAs: 'vm'
        })
        .when('/usuario', {
            templateUrl: 'usuarios/usuario.html',
            controller: 'usuariosCtrl',
            controllerAs: 'vm'
        })
        .when('/usuario/:usuarioID', {
            templateUrl: 'usuarios/usuario.html',
            controller: 'usuariosCtrl',
            controllerAs: 'vm'
        })
        .when('/login', {
            templateUrl: 'usuarios/login.html',
            controller: 'sesionCtrl'
        })

        //consultas
        .when('/consultas', {
            templateUrl: 'consultas/consultas.html',
            controller: 'consultaCtrl',
            controllerAs: 'vm'
        })

        //otherwise
        .otherwise({
            redirectTo: '/'
        });



}]);