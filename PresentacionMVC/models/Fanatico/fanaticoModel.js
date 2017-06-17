myConcert.service("fanaticoModel", function($routeParams, $location, $http){
//var myURL ="http://192.168.100.12:12345"; 
var myURL ="http://192.168.43.30:12345";     
var listaBandasActuales={}; 
var tipoUsuario="";
var carteleraActual=0;
    
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
                        alert("Votacion Realizada Correctamente")

                    }
                    else alert(result.data)

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
                    else alert(result.data)
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
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
                });
    
}
    
});