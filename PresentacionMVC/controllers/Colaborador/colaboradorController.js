myConcert.controller("colaboradorController", function($scope, $http, colaboradorModel){
    
    $scope.colaborador={};
    $scope.banda={};   
    $scope.cartelera={}; 
    $scope.Festival={};
    $scope.carteleraVotacion;
    $scope.listaCarteleras={};
    $scope.infoCartelera={};
    $scope.isFirstOpen = true;
    $scope.eventoFlag1 = true;
    $scope.oneAtATime = true;
    $scope.isOpen = false;
    colaboradorModel.obtenerListaCarteleras($scope.cartelera);
    colaboradorModel.obtenerListaFestivales($scope.cartelera);
    
    
    $scope.obtenerUnaCartelera= function(evento){
        colaboradorModel.obtenerUnaCartelera(evento,$scope.cartelera);
    }; 
    
    $scope.obtenerUnFestival= function(evento){
        colaboradorModel.obtenerUnFestival(evento,$scope.festival);
    };
    
    $scope.obtenerCartelera= function(cartelera){
        $scope.carterela = obtenerCartelera(cartelera);
    }
    
    $scope.convertirEnFestival=function(){
        $scope.eventoFlag1=false;    
    }
    
    $scope.crearFestival =function(){
        colaboradorModel.crearFestival($scope.cartelera);
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