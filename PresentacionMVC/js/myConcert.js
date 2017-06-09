var configMyConcert = function($routeProvider){
 
    $routeProvider
        .when("/home", {
            controller: "myConcertController",
            templateUrl: "views/home.html"
        })
        .when("/registroForm", {
            controller: "registroController",
            templateUrl: "views/registroView.html"
        });
 
}
 
//creamos el modulo y le aplicamos la configuración
var myConcert = angular.module("myConcert", ["ngRoute"]).config(configMyConcert);