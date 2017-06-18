myConcert.service("registroModel", function($routeParams, $location, $http){
var myURL = localStorage.getItem("url");

    
this.verificarUsuario = function(usuarioLogin){  
    localStorage.setItem("userName",usuarioLogin.login); 
    var Credenciales = {
                        "username":usuarioLogin.login,
                        "password":usuarioLogin.password
                        };     
    $http({
    method: 'POST',
    url: myURL+"/api/login",
    headers: {'Content-Type' : 'application/json'},
    data: Credenciales
    }).then(function(result){
            if (result.data.success) {
                  if (result.data.content.TipoUsuario=="colaborador")
                      window.location.href = "#vistaColaborador";
                  else window.location.href = "#vistaFanatico";
                }
            else alert(result.data.content)
    }, function(error) {
        console.log(error);
    });
}


this.validarEdad = function(fechaNacimiento,edad){
    milisegundos =  parseInt(35*24*60*60*1000); 
    fecha        =  new Date();
    day          =  fecha.getDate();
    month        =  fecha.getMonth()+1;
    year         =  fecha.getFullYear();
    tiempo       =  fecha.getTime();
    milisegundos =  parseInt(-edad*365*24*60*60*1000);
    total        =  fecha.setTime(tiempo+milisegundos);
    day          =  fecha.getDate();
    month        =  fecha.getMonth()+1;
    year         =  fecha.getFullYear();
    if(fecha>fechaNacimiento){
        return true;
    }
    else {
        return false;
    }
}

this.validarUsuario = function(usuario){
        if(usuario.Contrasena == usuario.Confirmacion){
                if(!($('input[name="tipoUsuario"]:checked').length > 0)){
                    if(this.validarEdad(usuario.fechaNacimiento,18)){
                         if(($('input[name="usuario.terminos"]:checked').length > 0)){
                             console.log("usuarioValido")
                            return true
                         }
                         else{
                             alert("Para crear cuenta debe aceptar los terminos y condiciones");
                         }
                        
                    }
                    else { 
                        alert("El usuario debe ser Mayor de Edad");
                        return false
                    }  
                }
                else {
                    return true;
                }
        }
        else {
            alert("Contraseña y Confirmacion no concuerdan");
            return false;
        } 
}
   
this.crearUsuario = function (usuario) {
    var UsuarioACrear;
    if(this.validarUsuario(usuario)){
        if(!($('input[name="tipoUsuario"]:checked').length > 0)){
            UsuarioACrear = {
                        "role":              "fanatico",
                        "user_data":
                               {   
                                "username":          usuario.nombreUsuario,
                                "name":              usuario.Nombre,
                                "last_name":         usuario.Apellido,
                                "password":          usuario.Contrasena,
                                "email":             usuario.Email,
                                "profile_pic" :      "foto",
                                "birth_date":        usuario.fechaNacimiento, 
                                "phone":             usuario.telefono,
                                "ubication":         usuario.ubicacion,
                                "country":           usuario.pais.Nombre,    
                                "university":        usuario.universidad.Nombre,
                                "description":       usuario.descripcion
                               },
                        "genres": usuario.generos.map(function(a) {return a.Id;})
                        };
            $http({
                    method: 'POST',
                    url: myURL+"/API/Usuarios",
                    headers: {
                        'Content-Type' : 'application/json'
                    },
                    data: UsuarioACrear
                    }).then(function(result){
                        if (result.data.success){
                            alert("Usuario Creado");
                                window.location.href = "#vistaFanatico";
                            }

                        else {alert(result.data.detail);}
                        }, function(error) {
                        console.log(error);
                    });
        }
        else {
            UsuarioACrear = {
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
            $http({
                    method: 'POST',
                    url: myURL+"/API/Usuarios",
                    headers: {'Content-Type' : 'application/json'},
                    data: UsuarioACrear
                    }).then(function(result){
                        if (result.data.success){
                            alert("Usuario Creado");
                            window.location.href = "#vistaColaborador"
                        }
                        else {alert(result.data.detail);}
                        }, function(error) {
                        console.log(error);
                    });
        
            }
        
    } else alert("Campos no llenados correctamente")
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
                    else alert(result.data.detail)

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
