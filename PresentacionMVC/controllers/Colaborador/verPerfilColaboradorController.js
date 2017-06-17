myConcert.controller("verPerfilColaboradorController", function($scope, $http, verPerfilColaboradorModel){
    $scope.colaborador = {} ;
    verPerfilColaboradorModel.obtenerPerfil($scope.colaborador);
    
    document.getElementById('perfilColaboradorDiv').onclick = function(e) {
    if(e.target == document.getElementById('perfilColaboradorDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }
    
}); 