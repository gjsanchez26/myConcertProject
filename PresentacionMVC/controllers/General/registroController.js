myConcert.controller("registroController", function($scope, $http, registroModel){
    console.log("Here");
    $scope.usuario={};
    $scope.usuarioLogin; 
    $scope.listaPaises={};
    $scope.listaGeneros={};
    $scope.listaUniversidades={};
    $scope.listaPaises = registroModel.obtenerPaises($scope.usuario);
    $scope.listaGeneros = registroModel.obtenerGeneros($scope.usuario);
    $scope.listaUniversidades = registroModel.obtenerUniversidades($scope.usuario);
    $scope.obtenerListas = function (){
        
        console.log("Listas a Mostrar");
        console.log($scope.listaPaises);
        console.log($scope.listaGeneros);
        console.log($scope.listaUniversidades);
        //$scope.listaPaises = registroModel.obtenerPaises();
        
    }
    
    console.log("lista");
    console.log($scope.listaPaises);
        
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
