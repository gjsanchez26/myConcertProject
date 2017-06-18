myConcert.controller("verPerfilFanaticoController", function($scope, $http, verPerfilFanaticoModel){
    $scope.fanatico ={};
    
    
    verPerfilFanaticoModel.obtenerPerfil($scope.fanatico);
    
    document.getElementById('perfilFanaticoDiv').onclick = function(e) {
    if(e.target == document.getElementById('perfilFanaticoDiv')) {
       window.location.href = "#vistaFanatico";          
        } 
    }
    
}); 