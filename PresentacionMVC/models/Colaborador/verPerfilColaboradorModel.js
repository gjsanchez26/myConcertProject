myConcert.service("verPerfilColaboradorModel", function($routeParams, $location, $http){
//var myURL ="http://192.168.100.12:12345";
var myURL ="http://192.168.43.30:12345";
    
this.obtenerPerfil = function(colaborador){
        console.log("12356")
        var infoColaborador={};                       
        $http({
                method: 'GET', 
                url: myURL+"/API/usuarios?username="+localStorage.getItem("userName"),
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){
                        console.log("usuario")
                        console.log(result.data);
                        colaborador=result.data.user;
                        console.log(colaborador);
                    }
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
        }); 
    }


});