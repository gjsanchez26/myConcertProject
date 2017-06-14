myConcert.service("verCatalogoModel", function($routeParams, $location, $http){
var myURL ="http://192.168.100.12:12345";
    
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