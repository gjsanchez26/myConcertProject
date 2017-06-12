// GLOBAL VARIABLES TO MANAGE GENERAL INFORMATION
var userID = localStorage.getItem("userName");
var userCode = localStorage.code;

var url='http://bryan:7580';
//ANGULAR MODULE TO MANAGE THE PROJECT POP POP
var categoriaForm = angular.module('vistaColaborador',[])
.controller('categoriaCtrl', ['$scope', '$http', function ($scope, $http) {

     document.getElementById("idUser").innerHTML = "Welcome "+userID;
   
    console.log("aaaaaaaaaaaaaaa"+userID);
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
    var listaCanciones = "";
    var listaMiembros  = [];  
    var str2 = "";
    $scope.agregarCancion = function () {
        var Cancion = 
                     {
                      "name":$scope.nombreCancion
                     };
<<<<<<< HEAD
        if(str2==""){
            str2=str2+'{"name":'+$scope.nombreCancion+'}'; 
        }
        else str2=str2+',{"name" : '+ $scope.nombreCancion+'}';
          
        console.log(str2);
        $scope.res = JSON([str2]);
        /*
        if(listaCanciones.length==0){
            listaCanciones.push(Cancion); 
        }
        else (listaCanciones.push(","+Cancion))
        */
   
        
    }
     $scope.agregarMiembro = function () {
        var miembro = $scope.nombreMiembro;
        $scope.listaMiembros.push(miembro);
        console.log($scope.listaMiembros);
    }
       $scope.canciones = [
           {"nombre": "Cancion1"}, 
           {"nombre": "Cancion2"},
           {"nombre": "Cancion3"},
           {"nombre": "Cancion4"},
           {"nombre": "Cancion5"},
           {"nombre": "Cancion6"}
       ];
       
    
=======
        listaCanciones.push(Cancion);
        console.log(listaCanciones); 
    }
     $scope.agregarMiembro = function () {
        var miembro = $scope.nombreMiembro;
        console.log(miembro);
        listaMiembros.push(miembro);
    }
>>>>>>> refs/remotes/origin/master
    $scope.crearBanda = function () {

        var Banda = {
                        "B_Name": $scope.B_Name,
                        "B_Bandas":listaCanciones
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
        $scope.listaCategoria.push(categoria);
        console.log(listaCategoria);
    }
    $scope.crearCartelera = function () {
        var Cartelera = {
                        "C_Name": $scope.C_Name,
                        "C_Bandas": $scope.listaCategoria
                    }
        console.log(Cartelera)
        $http.post(url+'/api/User/post/',Cartelera).
        success(function (data, status, headers, config) {alert('User has been posted');}).
        error(function (data, status, headers, config)   {alert('error posting User')});
    }
 



}]);

categoriaForm = angular.module('vistaColaborador')
.controller('verPerfilCtrl', ['$scope', '$http', function ($scope, $http) {
    var listaCategoria=[];
      $scope.verPerfil = function () {
          $("#verPerfilColaborador").fadeIn();
          $("#modificarPerfil").fadeOut();
          $("#desactivarPefil").fadeOut();
          var img = document.createElement("IMG");
          img.src = "/images/desconocido.jpg";
           document.getElementById('verPerfilColaborador').appendChild(img);
      }
      $scope.modificarPerfil = function () {
          $("#modificarPerfil").fadeIn();
          $("#desactivarPefil").fadeOut();
          $("#verPerfilColaborador").fadeOut();
          //$("#verPerfil").fadeOut("slow");
        } 
            
      $scope.desactivarPerfil = function () {
          $("#desactivarPefil").fadeIn();
          $("#modificarPerfil").fadeOut();
          $("#verPerfilColaborador").fadeOut();
          
          
          var r = confirm("Seguro que desea desactivar su cuenta");
           if (r == true) {
                alert( "Cuenta Desactivada");
            } else {
                alert("Cuenta Activa")
            }
            }
      
      



}]);

<<<<<<< HEAD
categoriaForm = angular.module('vistaColaborador')
.controller('panelPrincipalCtrl', ['$scope', '$http', function ($scope, $http) {
    var img = document.createElement("IMG");
    img.src = "/images/desconocido.jpg";
    
   
    $scope.verCarteleras = function () {
           document.getElementById('imagenPerfil').append(img);
          //document.getElementById("panelFestivales").innerHTML = document.getElementById("panelCarteleras").innerHTML;
          $("#panelCarteleras").fadeIn();
          $("#panelFestivales").fadeOut();

           
      }
      $scope.verFestivales = function () {
          document.getElementById('imagenPerfil').append(img); //document.getElementById("panelCarteleras").innerHTML = document.getElementById("panelFestivales").innerHTML;
          $("#panelCarteleras").fadeOut();
          $("#panelFestivales").fadeIn();
          //$("#verPerfil").fadeOut("slow");
        } 
    
    }]);
=======
>>>>>>> refs/remotes/origin/master

