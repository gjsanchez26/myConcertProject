myConcert.controller("verCatalogoController", function($scope, $http, verCatalogoModel){
    $scope.catalogo={};
    $scope.banda={};
    
    verCatalogoModel.obtenerBandas($scope.catalogo);
    $scope.verBandaEspecifica = function(banda){
        verCatalogoModel.verBandaEspecifica(banda.Id,$scope.catalogo);
    }
    
   // verCatalogoModel.verBanda($scope.catalogo);  
    console.log("aaaaaaaa");
    $scope.currentPage = 0;
    $scope.pageSize = 20;
    $scope.data = [];
    $scope.numberOfPages=function(){
        return Math.ceil($scope.data.length/$scope.pageSize);                
    }
    for (var i=0; i<45; i++) {
        $scope.data.push("Item "+i);
    }
    
    document.getElementById('verCatalogoDiv').onclick = function(e) {
    if(e.target == document.getElementById('verCatalogoDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }

   
    
}   ); 