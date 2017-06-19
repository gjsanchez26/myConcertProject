myConcert.controller("fanaticoController", function($scope, $http,$sce, fanaticoModel,){
    $scope.colaborador={};
    $scope.banda={};   
    $scope.cartelera={}; 
    $scope.festival={};
    $scope.carteleraVotacion;
    $scope.listaCarteleras={};
    $scope.infoCartelera={};
    $scope.isFirstOpen = true;
    $scope.eventoFlag1 = true;
    $scope.oneAtATime = true;
    $scope.isOpen = false;
    fanaticoModel.obtenerListaCarteleras($scope.cartelera);
    fanaticoModel.obtenerListaFestivales($scope.cartelera);
    
    
    $scope.obtenerUnaCartelera= function(evento){
        fanaticoModel.obtenerUnaCartelera(evento,$scope.cartelera);
    }; 
    
    $scope.verBandaEspecifica = function(banda){
        //$scope.linkSpotify = $sce.trustAsResourceUrl();
        console.log("Banda");
        console.log(banda);
        fanaticoModel.verBandaEspecifica(banda.name_band,$scope.cartelera);
    }
    
    $scope.obtenerUnFestival= function(evento){
        fanaticoModel.obtenerUnFestival(evento,$scope.festival);
    };
    
    $scope.obtenerCartelera= function(cartelera){
        $scope.carterela = obtenerCartelera(cartelera);
    }
    
    $scope.convertirEnFestival=function(){
        $scope.eventoFlag1=false;    
    }
    
    $scope.crearVotacion =function(){
        fanaticoModel.crearVotacion($scope.cartelera);
        $scope.eventoFlag1=true;  
    }

  $scope.crearComentario = function(cartelera){
      fanaticoModel.crearComentario($scope.cartelera);
  }
  
  document.getElementById('infoCarteleraModal').onclick = function(e) {
    if(e.target == document.getElementById('infoCarteleraModal')) {
         $scope.eventoFlag1=true;          
        } 
  }

  

    
    
});