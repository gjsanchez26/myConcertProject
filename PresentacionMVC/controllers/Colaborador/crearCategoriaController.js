myConcert.controller("crearCategoriaController", function($scope, $http, crearCategoriaModel){
    $scope.categoria;
    $scope.crearCategoria= function(){
        console.log("creacionCategoria");
        crearCategoriaModel.crearCategoria($scope.categoria);
    };
    
    document.getElementById('crearCategoriaDiv').onclick = function(e) {
    if(e.target == document.getElementById('crearCategoriaDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }
    
}); 