myConcert.service("crearBandaModel", function($routeParams, $location, $http){
var myURL ="http://192.168.100.12:12345";
var listaMiembros=[];
var listaCanciones=[];
this.agregarMiembro = function (banda){
    listaMiembros.push(banda.miembro);
    console.log(listaMiembros);
    banda.miembro="";
    banda.listaMiembros=listaMiembros;
}
this.agregarCancion= function (banda){
    listaCanciones.push(banda.cancion);
    console.log(listaCanciones);
    banda.cancion="";
    banda.listaCanciones=listaCanciones;
}
this.crearBanda = function (banda) {
    var banda;
    
    Banda = {
      "band_data": banda.nombre,
      "members":listaMiembros,
      "songs":listaCanciones,
      "genres":[1,2,3] //banda.generos.map(function(a) {return a.Id;})          
    }
    
    console.log(Banda );
    
    $http({
                method: 'POST',
                url: myURL+"/API/Bandas",
                headers: {
                    'Content-Type' : 'application/json'
                },
                data: Banda
                }).then(function(result){
                    if (result.data.success)
                    {alert("Banda Creado");
                     window.location.href = "#vistaColaborador";
                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
}
                  
this.obtenerGeneros = function(banda) {
        $http({
                method: 'GET',
                url: myURL+"/API/utilidades?data=generos",
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){

                    if (result.data.success){
                        console.log(result.data);
                        banda.listaGeneros=result.data.Elements;
                        return result.data.Elements; 
                    }
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
                });
    
}
            
});