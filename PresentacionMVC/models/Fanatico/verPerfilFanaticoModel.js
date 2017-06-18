myConcert.service("verPerfilFanaticoModel", function($routeParams, $location, $http){
var myURL = localStorage.getItem("url"); 
    
this.obtenerPerfil = function(fanatico){
        console.log("12356")
        var infofanatico={};                       
        $http({
                method: 'GET', 
                url: myURL+"/API/usuarios?username="+localStorage.getItem("userName"),
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){
                        console.log("usuario")
                        console.log(result.data);
                        fanatico.info=result.data;
                        console.log(fanatico.info);
                    }
                    else alert(result.data.detail);

                }, function(error) {
                    console.log(error);
        }); 
    }
});