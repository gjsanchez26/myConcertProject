myConcert.controller("crearBandaController", function($scope, $http, crearBandaModel){
    $scope.banda;
   // $scope.crearBandaModel.obtenerGeneros($scope.banda);
    
    $scope.agregarMiembro = function(){
        crearBandaModel.agregarMiembro($scope.banda);
    }
    $scope.agregarCancion = function(){
        crearBandaModel.agregarCancion($scope.banda);
    }
 /*   $scope.obtenerListas = function (){
        $scope.listaGeneros = registroModel.obtenerGeneros($scope.banda);        
    }*/
        
    $scope.changeView = function(view){
            $location.path(view); // path not hash
    }

     $scope.crearBanda= function(){
        console.log("creacionBanda");
        $scope.notas = crearBandaModel.crearBanda($scope.banda);
    };
    
});    