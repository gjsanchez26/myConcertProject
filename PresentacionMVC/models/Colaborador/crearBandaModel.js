myConcert.service("crearBandaModel", function($routeParams, $location, $http){
var myURL = localStorage.getItem("url");   
    
var listaMiembros=[];
var listaCanciones=[];

this.agregarMiembro = function (banda){
    listaMiembros.push(banda.miembro);
    banda.miembro       = "";
    banda.listaMiembros = listaMiembros;
}

this.agregarCancion= function (banda){
    listaCanciones.push(banda.cancion);
    banda.cancion        = "";
    banda.listaCanciones = listaCanciones;
}

this.crearBanda = function (banda) {
    var banda; 
    Banda = {
      "band_data" : banda.nombre,
      "members"   : listaMiembros,
      "songs"     : listaCanciones,
      "genres"    : banda.generos.map(function(a) {return a.Id;})          
    }  
    $http({
            method: 'POST',
            url: myURL+"/API/Bandas",
            headers: {
                'Content-Type' : 'application/json'
            },
            data: Banda
            }).then(function(result){
                if (result.data.success){
                    alert("Banda Creado");
                    listaMiembros=[];
                    listaCanciones=[];
                    window.location.href = "#vistaColaborador";
                }
                else alert(result.data.detail)

            }, function(error) {
                console.log(error);
            });
}  

this.obtenerListaGeneros = function(banda) {
        console.log("Get Lista Generos");
        $http({
                method: 'GET',
                url: myURL+"/API/utilidades?data=generos",
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){
                        banda.listaGeneros=result.data.Elements;
                    }
                    else alert(result.data.detail);

                }, function(error) {
                    console.log(error);
                });
    
}
            
});