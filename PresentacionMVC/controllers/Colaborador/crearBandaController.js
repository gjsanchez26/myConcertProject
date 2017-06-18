myConcert.controller("crearBandaController", function($scope, $http, crearBandaModel){
    $scope.banda={};
    
    crearBandaModel.obtenerListaGeneros($scope.banda); 
    $scope.agregarMiembro = function(){
        crearBandaModel.agregarMiembro($scope.banda); 
    }
    $scope.agregarCancion = function(){
        crearBandaModel.agregarCancion($scope.banda);
    }
    $scope.crearBanda= function(){
        $scope.notas = crearBandaModel.crearBanda($scope.banda);
    };
    document.getElementById('crearBandaDiv').onclick = function(e) {
    if(e.target == document.getElementById('crearBandaDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }
    
    
});    