myConcert.controller("colaboradorController", function($scope, $http, colaboradorModel){
    console.log("Here");
    
    $scope.usuario;
   
          
          
        
    
    $scope.changeView = function(view){
            $location.path(view); // path not hash
        }

    $scope.ingresarUsuario= function(){
         
        console.log("login");
        console.log($scope.usuario);
        $scope.notas = registroModel.verificarUsuario($scope.usuario);

    };
     $scope.crearCuenta= function(){
        console.log("creacionCuenta");
        $scope.notas = registroModel.crearUsuario($scope.usuario);

    };
    
});