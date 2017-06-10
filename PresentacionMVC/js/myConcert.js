
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
        
    ;
 
}
 
//creamos el modulo y le aplicamos la configuración
var myConcert = angular.module("myConcert", ["ngRoute"]).config(configMyConcert);
 window.location.href = "#registroForm";