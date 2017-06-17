myConcert.controller("crearCarteleraController", function($scope, $http, crearCarteleraModel){
    $scope.cartelera={};
    
    crearCarteleraModel.obtenerPaises($scope.cartelera);
    crearCarteleraModel.obtenerCategorias($scope.cartelera);
        
        
    
    $scope.crearCartelera= function(){
        console.log("creacionCartelera");
        crearCarteleraModel.crearCartelera($scope.cartelera);
    };
    $scope.agregarCategorias = function(){
        crearCarteleraModel.agregarCategorias($scope.cartelera);     
    }
    
    $scope.obtenerBandas = function(categoria){
        crearCarteleraModel.obtenerBandas(categoria,$scope.cartelera); 
        console.log("aqui1");
    }
    $scope.agregarBanda = function (banda) {

        crearCarteleraModel.agregarUnaBanda(banda.Nombre);
    }
/*    $scope.crearCategoria = function(){
        crearCarteleraModel.crearCategoria();
    }*/
    $scope.obtenerInformacionBanda = function(banda){
        crearCarteleraModel.obtenerInformacionBanda(banda);
    }
    
    
    
    document.getElementById('crearCarteleraDiv').onclick = function(e) {
    if(e.target == document.getElementById('crearCarteleraDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }
    
}); 