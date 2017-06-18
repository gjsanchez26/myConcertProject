myConcert.service("crearCarteleraModel", function($routeParams, $location, $http){
var myURL = localStorage.getItem("url");   

var listaCategorias=[];
var listaBandas=[]; 
var listaTemporalBandas=[];
var listaTemporalCategorias=[];
var listaCategoriasCrear=[];    
var listaCategorias=[];
var listaCategoriaBanda=[];
var categoriaActual;
  
this.agregarCategorias = function (cartelera){
    for (i = 0; i < cartelera.categoriasElegidas.length; i++) {
        listaTemporalCategorias.push(cartelera.categoriasElegidas[i]);
    }
    cartelera.listaCategorias = listaTemporalCategorias;

}

this.agregarUnaBanda= function(banda){
    var bandaXCategoria={
        "category": categoriaActual.Nombre,
        "band": banda
    }
    listaTemporalBandas.push(bandaXCategoria); 
}
/*
this.crearCategoria= function(){

   // listaCategoriaBanda.push(categorias);
    //listaCategoriasCrear.push(listaTemporalBandas);
    listaTemporalCategorias=[];
    listaTemporalBandas=[];
    console.log("Categarias a Crear");
    console.log(listaCategoriasCrear);
}*/


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
        "event_type":                     "cartelera",
        "event_data":
               {   
                "name":                   cartelera.nombre,
                "ubication":              cartelera.ubicacion,
                "country":                document.getElementById("paisSeleccionado").value,
                "initial_date":           cartelera.fechaInicioFestival,
                "initial_hour":           cartelera.horaInicioFestival,
                "final_date":             cartelera.fechaFinalFestival,
                "final_hour" :            cartelera.horaFinalFestival,   
                "vote_final_date":        cartelera.fechaFinalVotacion,
               },
        "categories": listaTemporalBandas
       
    };

    
    console.log(Cartelera);
 
    $http({
                method: 'POST',
                url: myURL+"/API/Eventos",
                headers: {
                    'Content-Type' :'application/json'
                },
                data: Cartelera
                }).then(function(result){
                    if (result.data.success)
                    {alert("Cartelera Creada");
                     listaTemporalBandas=[]
                     window.location.href = "#vistaColaborador";
                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
        listaCategorias=[];
        listaCategoriaBanda=[]; 
        listaTemporalBandas=[];
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
                        cartelera.CategoriasDisponibles=result.data.Elements;

                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
    
}

});