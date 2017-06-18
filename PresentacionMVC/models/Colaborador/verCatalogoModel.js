myConcert.service("verCatalogoModel", function($routeParams, $location, $http,$sce){
var myURL = localStorage.getItem("url");   

this.checkURL = function(src){
    return $sce.trustAsResourceUrl(src);  
}

this.verBandaEspecifica = function(ID,catalogo){
    $http({     method: 'GET',
                url: myURL+"/API/bandas?id="+ID,
                headers: {'Content-Type' : 'application/json'},
                }).then(function(result){
                    if (result.data.success){   
                          console.log(result.data);
                          catalogo.banda=result.data;
                          console.log(catalogo.banda);
                          catalogo.cancion= this.checkURL(catalogo.banda.songs.url_sound_test);
                    }
                    else alert(result.data.content)
                }, function(error) {
                    console.log(error);
                });
}
    

this.obtenerBandas  = function(catalogo){
    $http({
                method: 'GET',
                url: myURL+"/API/Bandas",
                headers: {
                    'Content-Type' : 'application/json'
                },
                }).then(function(result){
                    console.log("Json GET_PAIS");
                    console.log(result);
                    if (result.data.success)
                    {   
                      var json=result.data.Elements;
                      var newArr = [];
                      for (var i=0; i<json.length; i+=4) {
                        newArr.push(json.slice(i, i+4));
                       }
                       catalogo.listaBandas=newArr;
                    }
                    else alert(result.data.content)
                }, function(error) {
                    console.log(error);
                });
}

});