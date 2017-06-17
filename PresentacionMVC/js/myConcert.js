
var configMyConcert = function($routeProvider){

    $routeProvider
        .when("/home", {
            controller: "myConcertController",
            templateUrl: "views/General/home.html"
        })
        .when("/registroForm", {
            controller: "registroController",
            templateUrl: "views/General/registroView.html"
        })
        .when("/vistaColaborador", {
            controller: "colaboradorController",
            templateUrl: "views/Colaborador/colaboradorView.html"
        })
        .when("/verPerfilColaborador", {
            controller: "verPerfilColaboradorController",
            templateUrl: "views/Colaborador/verPerfilColaboradorView.html"
        })
        .when("/crearBanda", {
            controller: "crearBandaController",
            templateUrl: "views/Colaborador/crearBandaView.html"
        })
        .when("/crearCartelera", {
            controller: "crearCarteleraController",
            templateUrl: "views/Colaborador/crearCarteleraView.html"
        })
        .when("/crearCategoria", {
            controller: "crearCategoriaController",
            templateUrl: "views/Colaborador/crearCategoriaView.html"
        })
        .when("/crearFestivales", {
            controller: "crearFestivalController",
            templateUrl: "views/Colaborador/crearFestivalView.html"
        })
        .when("/catalogoBandas", {
            controller: "verCatalogoController",
            templateUrl: "views/Colaborador/verCatalogoView.html"
        })
        .when("/crearFestival", {
            controller: "crearFestivalController",
            templateUrl: "views/Colaborador/crearFestivalView.html"
        })
        .when("/vistaFanatico", {
            controller: "fanaticoController",
            templateUrl: "views/Fanatico/fanaticoView.html"
        })
    
        
        
    ;
 
}
 
//creamos el modulo y le aplicamos la configuración
var myConcert = angular.module("myConcert",  ['ngAnimate', 'ngAria', 'ui.bootstrap', 'ngMaterial', 'ngMessages', 'ngRoute', 'ui.router']).config(configMyConcert);


