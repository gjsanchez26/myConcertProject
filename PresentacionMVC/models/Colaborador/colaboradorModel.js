myConcert.service("colaboradorModel", function($routeParams, $location, $http){
//var myURL ="http://192.168.100.12:12345"; 
var myURL ="http://192.168.43.30:12345";     
var listaBandasActuales={}; 
    
this.crearFestival = function(cartelera){
            var listaBandadXCategoria=[];
            var checkboxes = document.getElementsByName('bandasSeleccionadas');
            var vals = "";
            for (var i=0, n=checkboxes.length;i<n;i++) 
            {
                if (checkboxes[i].checked) 
                {   var temp = checkboxes[i].value;
                    var res = temp.split(".")
                    var bandaXCategoria = { 
                        "band":res[0],
                        "category":res[1]  
                    }
                    
                    listaBandadXCategoria.push(bandaXCategoria);
                    vals += ","+checkboxes[i].value;
                }
            }
            if (vals) vals = vals.substring(1);
            console.log(vals);
            console.log(listaBandadXCategoria);
            nuevoFestival = {
              "event_type" : "festival",
              "event_data" : {
                        "event_id" : cartelera.info.event_data.Id,
                        "name" : cartelera.info.event_data.name,
                        "ubication": cartelera.info.event_data.ubication,
                        "country": cartelera.info.event_data.country,
                        "initial_date" : cartelera.info.event_data.initial_date,
                        "final_date" : cartelera.info.event_data.final_date,
                        "vote_final_date" :cartelera.info.event_data.final_date,
                        "food" : document.getElementById("cartelera.comida").value,
                        "transport" : document.getElementById("cartelera.comida").value,
                        "services" : document.getElementById("cartelera.servicios").value
              },
              "categories" : listaBandadXCategoria
            }
            console.log(nuevoFestival);
}


/*this.crearFestival = function(cartelera){
            var listaBandadXCategoria=[];
            var checkboxes = document.getElementsByName('bandasSeleccionadas');
            var vals = "";
            var jsonFinal=[];
            var nombre=""
            for (var i=0, n=checkboxes.length;i<n;i++) 
            {
                if (checkboxes[i].checked) 
                {   var temp = checkboxes[i].value;
                    var res = temp.split(".")
                    
                    var bandaXCategoria = { 
                        "band_name":res[0],
                        "category":res[1]  
                    }
                    listaBandadXCategoria.push(bandaXCategoria);
                    vals += ","+checkboxes[i].value;
                }
            }
            if (vals) vals = vals.substring(1);
            console.log(listaBandadXCategoria);
            var i=0;
            var listatemp=[];
            for(var i=0, n=listaBandadXCategoria.length;i<n-1;i++ ){
                var name=listaBandadXCategoria[i];
                
                while(listaBandadXCategoria[i].category==listaBandadXCategoria[i+1].category){
                    listatemp.push(listaBandadXCategoria[i].band_name);
                }
                var par = {
                    "category":name,
                    "bands":listatemp
                }
                jsonFinal.push(par);
                console.log(jsonFinal);
                    
            }
            console.log(jsonFinal);
            
            
               
                    
                    
                
            
                
/*                
            
            nuevoFestival = {
              "event_type" : "festival",
              "event_data" : {
                        "event_id" : cartelera.event_data.id,
                        "name" : cartelera.event_data.name,
                        "ubication": cartelera.event_data.ubication,
                        "country": cartelera.event_data.country,
                        "initial_date" : cartelera.event_data.initial_date,
                        "final_date" : cartelera.event_data.final_date,
                        "vote_final_date" : cartelera.event_data.final_date,
                        "food" : document.getElementById("cartelera.comida").value,
                        "transport" : document.getElementById("cartelera.comida").value,
                        "services" : document.getElementById("cartelera.servicios").value
              },
              "categories" : listaBandadXCategoria
            }
            console.log(nuevoFestival);
} */
                  
this.obtenerUnaCartelera=function(evento,cartelera){
    console.log("Evento");
    console.log(evento);
    console.log(evento.Id)

    $http({
                method: 'GET',
                url: myURL+"/API/eventos?id="+1,
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){
                        console.log(result.data);
                        cartelera.info=result.data;
                        console.log(cartelera.info);   
                    }
                    else alert(result.data)
                }, function(error) {
                    console.log(error);
                });    
  

    
}
this.obtenerListaCarteleras = function(cartelera){
        console.log("Get Obtener Carteleras");
         /*  var json = {
          "event_data": {
            "id":"ID",
            "name": "nombreCartelera",
            "ubication" : "ubicacion",
            "country" : "pais",
            "initial_date" : new Date(),
            "final_date" : new Date(),
            "vote_final_date" : new Date(),
            "event_type" : "Cartelera",
            "state" : "active"
          },
          "categories" : [
                    {
                    "category" : "categoria1",
                    "results" : [{"band":"banda1","votes":500},
                                 {"band":"banda2","votes":1500}, 
                                 {"band":"banda3","votes":2500},
                                 {"band":"banda4","votes":3500},
                                 {"band":"banda5","votes":4500}
                                ],
                    },
                    {
                    "category" : "categoria2",
                    "results" : [{"band":"banda21","votes":2500},
                                 {"band":"banda22","votes":21500}, 
                                 {"band":"banda23","votes":22500},
                                 {"band":"banda24","votes":23500},
                                 {"band":"banda25","votes":24500}
                                ],
                    },
                    {
                    "category" : "categoria3",
                    "results" : [{"band":"banda31","votes":3500},
                                 {"band":"banda32","votes":31500}, 
                                 {"band":"banda33","votes":32500},
                                 {"band":"banda34","votes":33500},
                                 {"band":"banda35","votes":34500}
                                ],
                    },

          ]}*/
        $http({
                method: 'GET',
                url: myURL+"/API/eventos?type=carteleras",
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){
                         cartelera.listaCarteleras=result.data.Elements;
                        //cartelera.listaCarteleras=json;
                        
                    }
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
                });
    
}

this.obtenerListaFestivales = function(cartelera){
        console.log("Get Obtener Festivales");
        $http({
                method: 'GET',
                url: myURL+"/API/eventos?type=festivales",
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){

                        cartelera.listaFestivales=result.data.Elements;

                    }
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
                });
    
}
    
});