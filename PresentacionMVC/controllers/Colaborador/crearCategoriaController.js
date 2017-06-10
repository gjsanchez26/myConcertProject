myConcert.controller("crearCategoriaController", function($scope, $http, crearCategoriaModel){
    $scope.categoria;
    $scope.crearCategoria= function(){
        console.log("creacionCategoria");
        crearCategoriaModel.crearCategoria($scope.categoria);
    };
    
}); 