myConcert.service("colaboradorModel", function($routeParams, $location, $http){

var myURL = localStorage.getItem("url");     
var listaBandasActuales={}; 
var tipoUsuario="";

    
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
                        "name" : cartelera.info.event_data.Nombre,
                        "ubication": cartelera.info.event_data.Ubicacion,
                        "country": cartelera.info.event_data.Pais,
                        "initial_date" : cartelera.info.event_data.FechaInicioFestival,
                        "final_date" : cartelera.info.event_data.FechaFinalFestival,
                        "vote_final_date" :cartelera.info.event_data.FechaFinalVotacion,
                        "food" : document.getElementById("cartelera.comida").value,
                        "transport" : document.getElementById("cartelera.transporte").value,
                        "services" : document.getElementById("cartelera.servicios").value
              },
              "categories" : listaBandadXCategoria
            }
            console.log(nuevoFestival);
                $http({
                method: 'POST',
                url: myURL+"/API/Eventos",
                headers: {'Content-Type' : 'application/json'},
                data:nuevoFestival
                })
                .then(function(result){
                    if (result.data.success){
                        console.log(result.data);
                        cartelera.info=result.data;
                        console.log(cartelera.info);
                        alert(result.data.detail + "La banda incluida por el chef es" + result.data.RecomendacionChef );
                    }
                    else alert(result.data.detail)
                }, function(error) {
                    console.log(error);
                }); 
    
    
}

                  
this.obtenerUnaCartelera=function(evento,cartelera){

    $http({
                method: 'GET',
                url: myURL+"/API/eventos?id="+evento.Id,
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){
                        console.log(result.data);
                        cartelera.info=result.data;
                        console.log(cartelera.info);   
                    }
                    else alert(result.data.detail)
                }, function(error) {
                    console.log(error);
                });        
}

this.obtenerUnFestival=function(evento,festival){

    $http({
                method: 'GET',
                url: myURL+"/API/eventos?id="+evento.Id,
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){
                        console.log(result.data);
                        festival.info=result.data;
                        console.log(festival.info);   
                    }
                    else alert(result.data.detail)
                }, function(error) {
                    console.log(error);
                });        
}
this.obtenerListaCarteleras = function(cartelera){
        console.log("Obtener Todas Carteleras");
        $http({
                method: 'GET',
                url: myURL+"/API/eventos?type=carteleras",
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success)cartelera.listaCarteleras=result.data.Elements;                        
                    else alert(result.data.detail)
                }, function(error) {
                    console.log(error);
                    alert("Informacion No disponible, Intente más tarde")
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
                    else alert(result.data.detail)

                }, function(error) {
                    console.log(error);
                });
    
}
    
});