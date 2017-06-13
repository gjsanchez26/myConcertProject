myConcert.controller("colaboradorController", function($scope, $http, colaboradorModel){
    
    $scope.usuario;
    $scope.carteleraVotacion;
    $scope.listaCatego;
    $scope.obtenerCategorias= function(){
        colaboradorModel.obtenerCategorias($scope.listaCatego);  
    }

  

    
    
});