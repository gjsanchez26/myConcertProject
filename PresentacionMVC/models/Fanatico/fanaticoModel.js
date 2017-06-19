myConcert.service("fanaticoModel", function($routeParams, $location, $http,$sce){

var myURL =localStorage.getItem("url");  
    
var listaBandasActuales = {}; 
var tipoUsuario         = "";
var carteleraActual     = 0;
    
this.crearVotacion = function(cartelera){
           var listaBandadXCategoria=[];
            var checkboxes = document.getElementsByName('bandasSeleccionadas');
            var listaVotos = document.getElementsByName('voto');
            var vals = "";
            for (var i=0, n=checkboxes.length;i<n;i++) 
            {
                    var temp = checkboxes[i].value;
                    var res = temp.split(".")
                    var bandaXCategoria = { 
                        "cartelera":cartelelaActual,
                        "band":res[0],
                        "category":res[1],
                        "vote":parseInt(listaVotos[i].value),
                        "username":localStorage.getItem("userName")
                    }               
                    listaBandadXCategoria.push(bandaXCategoria);    
            }
            console.log(listaBandadXCategoria); 
    
    $http({
                method: 'POST',
                url: myURL+"/API/Votaciones",
                headers: {'Content-Type' : 'application/json'},
                data: listaBandadXCategoria
                })
                
                .then(function(result){
                    if (result.data.success){
                        alert(result.data.detail);

                    }
                    else alert(result.data.detail);

                }, function(error) {
                    console.log(error);
                });
    
}

this.verBandaEspecifica = function(ID,cartelera){
    console.log("Banda En Model")
    var canciones = [];
    $http({     method: 'GET',
                url: myURL+"/API/bandas?name="+ID,
                headers: {'Content-Type' : 'application/json'},
                }).then(function(result){
                    if (result.data.success){   
                          console.log(result.data);
                          cartelera.banda=result.data;
                          console.log(result.data.songs.length);
                          for(var i=0;i<result.data.songs.length;i++){
                              var test = {
                                  "song_name":result.data.songs[i].song_name,
                                  "song_url":$sce.trustAsResourceUrl(result.data.songs[i].url_sound_test)
                              };

                              canciones.push(test);

                          }
                          cartelera.banda.infoSongs=canciones;
                          console.log(canciones);
                    }
                    else alert(result.data.detail)
                }, function(error) {
                    console.log(error);
                });
}
                  
this.obtenerUnaCartelera=function(evento,cartelera){
    
    cartelelaActual=evento.Id
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
                    else alert(result.data)
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

this.crearComentario=function(cartelera){
    var calificacion = document.getElementsByName("rating").length;
    var comentario = document.getElementById("cartelera.banda.comentario").value;
    var usuario = localStorage.getItem("userName");
    var banda = cartelera.banda.band_data.name;
    if(calificacion!=0){
        if(comentario!=""){
            var json = {
                              "band" : banda,
                              "user" : usuario,
                              "comment" : comentario,
                              "calification" : (calificacion/2)
            }
            
            
            console.log(json);
            
            $http({
                    method: 'PUT',
                    url: myURL+"/API/Bandas",
                    headers: {'Content-Type' : 'application/json'},
                    data: json
                    }).then(function(result){
                        if (result.data.success){
                            alert(result.data.detail);
                            document.getElementsByName("rating").length=0;
                            document.getElementById("cartelera.banda.comentario").value="";
                           
                        }
                        else {alert(result.data.detail);}
                        }, function(error) {
                        console.log(error);
                    });
        }
        else alert("Debe de acompañar Calificación con comentario")
        
    }
    else alert ("Debe de Realizar Calificación Con estrellas");
    
    
}
    
});