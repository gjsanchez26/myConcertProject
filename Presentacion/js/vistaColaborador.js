// GLOBAL VARIABLES TO MANAGE GENERAL INFORMATION
var userID = localStorage.user;
var userCode = localStorage.code;
var listaCanciones=[];
var url='http://bryan:7580';
//ANGULAR MODULE TO MANAGE THE PROJECT POP POP
var categoriaForm = angular.module('vistaColaborador',[])
.controller('categoriaCtrl', ['$scope', '$http', function ($scope, $http) {



    $scope.crearCategoria = function () {

        var Categoria = {
                        "C_Name": $scope.C_Name
                    
                    }
        console.log(Categoria)
        $http.post(url+'/api/User/post/',Categoria).
        success(function (data, status, headers, config) {alert('User has been posted');}).
        error(function (data, status, headers, config)   {alert('error posting User')});
    }
 



}]);

categoriaForm = angular.module('vistaColaborador')
.controller('bandaCtrl', ['$scope', '$http', function ($scope, $http) {
    var listaCanciones = [];
    var listaMiembros  = [];
    $scope.agregarCancion = function () {
        var miembro = $scope.nombreCancion;
        console.log(miembro);
        var Cancion = 
                     {
                      "name":$scope.nombreCancion
                     };
        listaCanciones.push(Cancion);
        console.log(listaCanciones);
        
    }
     $scope.agregarMiembro = function () {
        var miembro = $scope.nombreMiembro;
        console.log(miembro);
        listaMiembros.push(miembro);

    }
    
    $scope.crearBanda = function () {

        var Banda = {
                        "B_Name": $scope.B_Name 
                    }
        console.log(Banda)
        $http.post(url+'/api/User/post/',Banda).
        success(function (data, status, headers, config) {alert('User has been posted');}).
        error(function (data, status, headers, config)   {alert('error posting User')});
    }

}]);

categoriaForm = angular.module('vistaColaborador')
.controller('carteleraCtrl', ['$scope', '$http', function ($scope, $http) {
    var listaCategoria=[];
    $scope.agregarCategoria = function () {
        var categoria = $scope.nombreCategoria;
        listaCategoria.push(categoria);
        console.log(listaCategoria);
    }
    $scope.crearCartelera = function () {
        var Cartelera = {
                        "C_Name": $scope.C_Name 
                    }
        console.log(Cartelera)
        $http.post(url+'/api/User/post/',Cartelera).
        success(function (data, status, headers, config) {alert('User has been posted');}).
        error(function (data, status, headers, config)   {alert('error posting User')});
    }
 



}]);

categoriaForm = angular.module('vistaColaborador')
.controller('anadirBandaCtrl', ['$scope', '$http', function ($scope, $http) {
    var listaCategoria=[];
    $scope.agregarCategoria = function () {
        var categoria = $scope.nombreCategoria;
        listaCategoria.push(categoria);
        console.log(listaCategoria);
    }
    $scope.crearCartelera = function () {
        var Cartelera = {
                        "C_Name": $scope.C_Name 
                    }
        console.log(Cartelera)
        $http.post(url+'/api/User/post/',Cartelera).
        success(function (data, status, headers, config) {alert('User has been posted');}).
        error(function (data, status, headers, config)   {alert('error posting User')});
    }
 



}]);


