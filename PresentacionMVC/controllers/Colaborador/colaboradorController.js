myConcert.controller("colaboradorController", function($scope, $http, colaboradorModel){
    
    $scope.colaborador={};
    $scope.banda={};   
    $scope.cartelera={}; 
    $scope.carteleraVotacion;
    $scope.listaCarteleras;
    $scope.infoCartelera={};
    $scope.isFirstOpen = true;

    $scope.listaCarteleras = colaboradorModel.obtenerListaCarteleras();
    $scope.obtenerUnaCartelera= function(cartelera){
       console.log("asdsada");
       $scope.infoCartelera = colaboradorModel.obtenerUnaCartelera(cartelera);  
    }
    $scope.obtenerCarterelera= function(cartelera){
        $scope.carterela = obtenerCartelera(cartelera);
    }
    $scope.convertirEnFestival=function(){
        window.location.href = "#crearFestival";
        
    }
    $scope.oneAtATime = true;
    $scope.isOpen = false;
    
    $scope.crearFestival =function(){
        console.log("creacion de festival");
        colaboradorModel.crearFestival($scope.infoCartelera);
        
    }
    // Data 
     $scope.groups = [
    {
      title: "Dynamic Group Header - 1",
      content: "Content - 1"
    },
    {
      title: "Dynamic Group Header - 2",
      content: "Content - 2"
    }
  ];

  $scope.updateOpenStatus = function(){
    $scope.isOpen = $scope.groups.some(function(item){
      return item.isOpen;
    });
  }

  

    
    
});