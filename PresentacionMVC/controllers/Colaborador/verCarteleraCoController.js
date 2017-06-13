myConcert.controller("verCarteleraCoController", function($scope, $http, verCarteleraCoModel){
    $scope.cartelera;
   // $scope.crearBandaModel.obtenerGeneros($scope.banda);
    
    
    document.getElementById('crearBandaDiv').onclick = function(e) {
    if(e.target == document.getElementById('crearBandaDiv')) {
        
       window.location.href = "#vistaColaborador";          
        } 
    }
    
    
}); 