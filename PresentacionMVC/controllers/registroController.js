myConcert.controller("registroController", function($scope, $http, registroModel){
    console.log("Here");
	$scope.notas = registroModel.crearUsuario();
    $scope.ingresarUsuario= function(){
        console.log("boton ")
        $scope.notas = registroModel.verificarUsuario($scope.U_ID,$scope.U_Password);
    };
    
});
