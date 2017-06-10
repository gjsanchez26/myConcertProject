myConcert.controller("registroController", function($scope, $http, registroModel){
    console.log("Here");
    $scope.usuario;
    $scope.usuarioLogin;          
    $scope.changeView = function(view){
            $location.path(view); // path not hash
        }

    $scope.ingresarUsuario= function(){
         
        console.log("login");
        console.log($scope.usuario);
        $scope.notas = registroModel.verificarUsuario($scope.usuarioLogin);
     //   window.location.href = "#vistaColaborador";
     //   window.location.assign("#colaboradorView.html")

    };
     $scope.crearCuenta= function(){
        console.log("creacionCuenta");
        $scope.notas = registroModel.crearUsuario($scope.usuario);

    };
    
});
