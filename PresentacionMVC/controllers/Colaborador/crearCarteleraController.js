myConcert.controller("crearCarteleraController", function($scope, $http, crearCarteleraModel){
    $scope.cartelera;
    
    $scope.crearCartelera= function(){
        console.log("creacionCartelera");
        crearCarteleraModel.crearCartelera($scope.cartelera);
    };
    $scope.agregarCategoria = function(){
        crearCarteleraModel.agregarCategoria($scope.cartelera);     
    }
    $scope.obtenerBandas = function(categoria){
        crearCarteleraModel.obtenerBandas(categoria,$scope.cartelera); 
        console.log("aqui1");
    }
    $scope.agregarBanda = function (Banda) {
        crearCarteleraModel.agregarBanda(Banda);
    }
    $scope.crearCategoria = function(){
        crearCarteleraModel.crearCategoria();
    }
    $scope.obtenerInformacionBanda = function(banda){
        crearCarteleraModel.obtenerInformacionBanda(banda);
    }
    
    
    
    document.getElementById('crearCarteleraDiv').onclick = function(e) {
    if(e.target == document.getElementById('crearCarteleraDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }
    
}); 