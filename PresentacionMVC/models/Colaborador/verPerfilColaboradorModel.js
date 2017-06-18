myConcert.service("verPerfilColaboradorModel", function($routeParams, $location, $http){
var myURL = localStorage.getItem("url");   
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
                        return colaborador;
                    }
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
        }); 
    }


});