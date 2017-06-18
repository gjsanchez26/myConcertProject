myConcert.controller("registroController", function($scope, $http, registroModel){

    $scope.usuario              = {};
    $scope.usuarioLogin         = {};
    $scope.listaPaises          = {};
    $scope.listaGeneros         = {};
    $scope.listaUniversidades   = {};
    $scope.listaPaises          = registroModel.obtenerPaises($scope.usuario);
    $scope.listaGeneros         = registroModel.obtenerGeneros($scope.usuario);
    $scope.listaUniversidades   = registroModel.obtenerUniversidades($scope.usuario);
    $scope.changeView = function(view){
            $location.path(view); // path not hash
    }
    $scope.ingresarUsuario= function(){       
        console.log("login");
        console.log($scope.usuario);
        $scope.notas = registroModel.verificarUsuario($scope.usuarioLogin);
    };
     $scope.crearCuenta= function(){
        console.log("creacionCuenta");
        $scope.notas = registroModel.crearUsuario($scope.usuario);

    };
    
});

