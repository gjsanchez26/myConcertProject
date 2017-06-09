myConcert.controller("registroController", function($scope, $http, $routeParams, $location, registroModel){
    console.log("Here");
	$scope.notas = registroModel.crearUsuario();
    $scope.formRegistro1 = registroModel.formFanatico();
    $scope.formRegistro2 = registroModel.formColaborador();
          
          
        
    
    $scope.changeView = function(view){
            $location.path(view); // path not hash
        }

    $scope.ingresarUsuario= function(){
        
        console.log("boton");
        $scope.notas = registroModel.verificarUsuario($scope.U_ID,$scope.U_Password);
        console.log($scope.notas);
    };
    
});
