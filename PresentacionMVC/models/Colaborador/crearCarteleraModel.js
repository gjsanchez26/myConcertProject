myConcert.service("crearCarteleraModel", function($routeParams, $location, $http){
var myURL ="http://192.168.100.12:12345";
var listaCategorias=[];
var listaBandas=[]; 
var listaTemporalBandas=[]
var listaCategorias=[];
var listaCategoriaBanda=[];
var categoriaActual;
this.agregarCategoria = function (cartelera){
    listaCategorias.push(cartelera.categoria);
    console.log(listaCategorias);
    cartelera.categoria="";
    cartelera.listaCategorias=listaCategorias;
}
this.agregarBanda= function(banda){
    listaTemporalBandas.push(banda.nombre); 
    console.log("Lista Temporal");
    console.log(listaTemporalBandas);
}

this.crearCategoria= function(banda){
    var categorias = {
        "category": categoriaActual,
        "bands": listaTemporalBandas        
    }
    console.log("Categoria y Bandas");
    console.log(categorias);
    listaCategoriaBanda.push(categorias); 
    console.log("ListaBandaCategoria");
    console.log(listaCategoriaBanda);
}


this.obtenerInformacionBanda = function(){
    console.log("getInfoBanda")
}
this.obtenerBandas  = function(categoria,cartelera){
    categoriaActual = categoria;
    console.log("aqui2");
    console.log(categoria)
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
                       cartelera.listaBandas=newArr;

                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
    
    
    
}


this.crearCartelera= function (cartelera) {
    var Cartelera;
    Cartelera = {
        "event_type":              "Cartelera",
        "event_data":
               {   
                "name":                   cartelera.nombre,
                "ubication":              cartelera.ubicacion,
                "country":                cartelera.pais,
                "initial_date":           cartelera.fechaInicioFestival,
                "initial_hour":           cartelera.horaInicioFestival,
                "final_date":             cartelera.fechaFinalFestival,
                "final_hous" :            cartelera.horaFinalFestival,   
                "vote_initial_date":      cartelera.fechaInicioVotacion,
                "vote_final_date":        cartelera.fechaFinalVotacion,
               },
        "Categories": listaCategoriaBanda
       
    };

    
    console.log(Cartelera);
 /*   
    $http({
                method: 'POST',
                url: myURL+"/API/Carteleras",
                headers: {
                    'Content-Type' : 'application/json'
                },
                data: Fanatico
                }).then(function(result){
                    if (result.data.success)
                    {alert("Usuario Creado");
                     window.location.href = "#vistaColaborador";
                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });*/
}

this.obtenerPaises = function(cartelera) {
    $http({
                method: 'GET',
                url: myURL+"/API/utilidades?data=paises",
                headers: {
                    'Content-Type' : 'application/json'
                },
                }).then(function(result){
                    console.log("Json GET_PAIS");
                    console.log(result);
                    if (result.data.success)
                    {   
                        cartelera.listaPaises=result.data.Elements;
                        return result.data.Elements; 
                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
    
}
this.obtenerCategorias = function(cartelera) {
    $http({
                method: 'GET',
                url: myURL+"/API/Categorias",
                headers: {
                    'Content-Type' : 'application/json'
                },
                }).then(function(result){
                    console.log("Json GET_PAIS");
                    console.log(result);
                    if (result.data.success)
                    {   
                        cartelera.listaCategorias=result.data.Elements;

                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
    
}

});