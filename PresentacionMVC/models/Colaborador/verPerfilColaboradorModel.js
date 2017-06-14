myConcert.service("verPerfilColaboradorModel", function($routeParams, $location, $http){
var myURL ="http://192.168.100.12:12345";
    this.obtenerPerfil = function(colaborador){
        var infoColaborador={};
        colaborador.nombreUsuario="gjsanchez";
                        colaborador.nombre="gabriel";
                        colaborador.apellido="Sanchez";
                        colaborador.pais="Costa Rica";
                        colaborador.ubicacion="San Jose";
                        colaborador.fechaNacimiento="26 Enero 1994";
                        colaborador.fechaInscripcion="14 junio 2017";
                        colaborador.universidad="Tecnológico de Costa Rica";
                        colaborador.email="gjsanchez26@gmail.com";
                        colaborador.foto="noPicture";
                        colaborador.generos=["reggae","HipHop","Dancehall"]; colaborador.descripcion="jnasfondslkfnasojbaodnfaslkdnasouhdnalskndjosfnklsdncsfdsdfsdfsdfsdsdcisbndlcnguisnlkvnsngslngsoudnflsdnfjsdnfsldmfnsjdnflsf";
  /*                      
        $http({
                method: 'GET',
                url: myURL+"/API/Usuarios?username="+,
                headers: {'Content-Type' : 'application/json'},
                })
                .then(function(result){
                    if (result.data.success){
                        colaborador.nombreUsuario="gjsanchez";
                        colaborador.nombre="gabriel";
                        colaborador.apellido="Sanchez";
                        colaborador.pais="Costa Rica";
                        colaborador.ubicacion="San Jose";
                        colaborador.fechaNacimiento="26 Enero 1994"
                        colaborador.fechaCreacion="14 junio 2017"
                        colaborador.universidad="Tecnológico de Costa Rica"
                        colaborador.email="gjsanchez26@gmail.com"
                        colaborador.foto="noPicture"
                        colaborador.generos=["reggae","HipHop","Dancehall"]
                        colaborador.descripcion="jnasfondslkfnasojbaodnfaslkdnasouhdnalskndjosfnklsdncsfdsdfsdfsdfsdsdcisbndlcnguisnlkvnsngslngsoudnflsdnfjsdnfsldmfnsjdnflsf"
                    }
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
        }); */
        
        
        
    }


});