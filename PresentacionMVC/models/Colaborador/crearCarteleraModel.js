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
    var json=  [
            {
                nombre : "Bob Marley",
                edad : "32 años"
            },
            {
                nombre : "Pink Floyd",
                edad : "24 años"
            },
            {
                nombre : "Guns & Roses",
                edad : "28 años"
            },
            {
                nombre : "Metallica",
                edad : "18 años"
            },
            {
                nombre : "System of a Down",
                edad : "45 años"
            },
            {
                nombre : "Bob Marley1",
                edad : "32 años"
            },
            {
                nombre : "Pink Floyd1",
                edad : "24 años"
            },
            {
                nombre : "Guns & Roses1",
                edad : "28 años"
            },
            {
                nombre : "Metallica1",
                edad : "18 años"
            },
            {
                nombre : "System of a Down1",
                edad : "45 años"
            },
            {
                nombre : "Bob Marley",
                edad : "32 años"
            },
            {
                nombre : "Pink Floyd",
                edad : "24 años"
            },
            {
                nombre : "Guns & Roses",
                edad : "28 años"
            },
            {
                nombre : "Metallica",
                edad : "18 años"
            },
            {
                nombre : "System of a Down",
                edad : "45 años"
            },
            {
                nombre : "Bob Marley1",
                edad : "32 años"
            },
            {
                nombre : "Pink Floyd1",
                edad : "24 años"
            },
            {
                nombre : "Guns & Roses1",
                edad : "28 años"
            },
            {
                nombre : "Metallica1",
                edad : "18 años"
            },
            {
                nombre : "System of a Down1",
                edad : "45 años"
            }
    
    
    ];
    
    var newArr = [];
      for (var i=0; i<json.length; i+=4) {
        newArr.push(json.slice(i, i+4));
      }

    console.log(json);
    console.log(newArr);
    cartelera.listaBandas=newArr;
    /*
    $http({
                method: 'GET',
                url: myURL+"/API/utilidades?data=bandas",
                headers: {
                    'Content-Type' : 'application/json'
                },
                }).then(function(result){
                    console.log("Json GET_PAIS");
                    console.log(result);
                    if (result.data.success)
                    {   
                        console.log("Valor a Retornar");
                        console.log(result.data.Elements);
                        cartelera.listaBandas=result.data.Elements;
                        return result.data.Elements; 
                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });*/
    
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

this.obtenerPaises = function(usuario) {
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
                        console.log("Valor a Retornar");
                        console.log(result.data.Elements);
                        cartelera.listaPaises=result.data.Elements;
                        return result.data.Elements; 
                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
    
}

});