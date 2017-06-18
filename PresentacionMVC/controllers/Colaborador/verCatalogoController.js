myConcert.controller("verCatalogoController", function($scope, $http,$sce, verCatalogoModel){
    $scope.catalogo    = {};
    $scope.banda       = {};
    $scope.linkSpotify = "";
    
    verCatalogoModel.obtenerBandas($scope.catalogo);
    
    $scope.verBandaEspecifica = function(banda){
        //$scope.linkSpotify = $sce.trustAsResourceUrl();
        verCatalogoModel.verBandaEspecifica(banda.Id,$scope.catalogo);
    }
    
    
    


    document.getElementById('verCatalogoDiv').onclick = function(e) {
    if(e.target == document.getElementById('verCatalogoDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }

   
    
}   ); 