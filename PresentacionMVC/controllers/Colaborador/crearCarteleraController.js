myConcert.controller("crearCarteleraController", function($scope, $http, crearCarteleraModel){
    $scope.cartelera;
    $scope.crearCartelera= function(){
        console.log("creacionCartelera");
        crearCarteleraModel.crearCartelera($scope.cartelera);
    };
    
    document.getElementById('crearCarteleraDiv').onclick = function(e) {
    if(e.target == document.getElementById('crearCarteleraDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }
    
}); 