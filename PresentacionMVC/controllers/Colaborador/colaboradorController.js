myConcert.controller("colaboradorController", function($scope, $http, colaboradorModel){
    
    $scope.usuario;
    $scope.carteleraVotacion;
    $scope.listaCarteleras;
    $scope.informacionCartelera;
    $scope.listaCarteleras = colaboradorModel.obtenerListaCarteleras();
    $scope.obtenerCartelera= function(cartelera){
       $scope.informacionCartelera = colaboradorModel.obtenerCartelera(cartelera);  
    }

  

    
    
});