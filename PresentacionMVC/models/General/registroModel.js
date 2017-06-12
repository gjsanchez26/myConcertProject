myConcert.service("registroModel", function($routeParams, $location, $http){
var myURL ="http://192.168.100.12:12345";
var paises;
this.verificarUsuario = function(usuarioLogin){  
    
    console.log("1");
    localStorage.setItem("userName",usuarioLogin.login); 
    var Credenciales = {
                        "username":usuarioLogin.login,
                        "password":usuarioLogin.password
                   };
    console.log(Credenciales);
    $http({
        method: 'POST',
        url: myURL+"/api/login",
        headers: {'Content-Type' : 'application/json'},
        data: Credenciales

        }).then(function(result){
                console.log(Credenciales);
                console.log(result);
                console.log(result.data);
                if (result.data.success) {
                      if (result.data.content.TipoUsuario=="Colaborador")
                          window.location.href = "#vistaColaborador";
                        
                      else window.location.href = "#vistaFanatico";
                    }
                else alert(result.data.content)


        }, function(error) {
            console.log(error);
        });
};
    
this.crearUsuario = function (usuario) {
    var Fanatico;
    if($('input[name="tipoUsuario"]:checked').length > 0){
        Fanatico = {
        "role":              "fanatico",
        "user_data":
               {   
                "username":          usuario.nombreUsuario,
                "name":              usuario.Nombre,
                "last_name":         usuario.Apellido,
                "password":          usuario.Contrasena,
                "email":             usuario.Email,
                "profile_pic" :      "foto",
                "bith_date":         Date(usuario.fechaNacimiento), 
                "phone":             usuario.telefono,
                "ubication":         usuario.ubicacion,
                "country":           usuario.pais.Id    ,
                "university":        usuario.universidad.Id,
                "description":       usuario.descripcion
               },
        "genres": usuario.generos.map(function(a) {return a.Id;})
    };
    console.log(Fanatico);
    }
    else {
        Fanatico = {
        "role":                      "colaborador",
        "user_data":
               {   
                "username":          usuario.nombreUsuario,
                "name":              usuario.Nombre,
                "last_name":         usuario.Apellido,
                "password":          usuario.Contrasena,
                "email":             usuario.Email,
                "profile_pic" :      "foto",
                
               },
        "genres": []
    };
    console.log(Fanatico);
    }
    $http({
                method: 'POST',
                url: myURL+"/API/Usuarios",
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
                });
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
                        usuario.listaPaises=result.data.Elements;
                        return result.data.Elements; 
                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
    
}
this.obtenerUniversidades = function(usuario) {
    $http({
                method: 'GET',
                url: myURL+"/API/utilidades?data=universidades",
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
                        usuario.listaUniversidades=result.data.Elements;
                        return result.data.Elements; 
                    }
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
                });
    
}
this.obtenerGeneros = function(usuario) {
    $http({
                method: 'GET',
                url: myURL+"/API/utilidades?data=generos",
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
                        usuario.listaGeneros=result.data.Elements;
                        return result.data.Elements; 
                    }
                    else alert(result.data)

                }, function(error) {
                    console.log(error);
                });
    
}
        
      
$('.tab a').on('click', function (e) {

  e.preventDefault();

  $(this).parent().addClass('active');
  $(this).parent().siblings().removeClass('active');

  target = $(this).attr('href');

  $('.tab-content > div').not(target).hide();

  $(target).fadeIn(600);

});
});
