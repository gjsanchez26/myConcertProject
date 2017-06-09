
myConcert.service("registroModel", function($routeParams, $location, $http){
    console.log("Here2x");


     this.verificarUsuario = function(usuario)
            {   
                console.log("1");

                localStorage.setItem("userName",""); 
                localStorage.setItem("userID","");
                var Credenciales = {
                    "username":usuario.login,
                    "password":usuario.password
            }   ;
            
            console.log(Credenciales);
            $http({
                    method: 'POST',
                    url: "http://192.168.100.12:12345/API/login",
                    headers: {
                        'Content-Type' : 'application/x-www-form-urlencoded'
                    },
                    data: Credenciales
                    }).then(function(result){
                        console.log(Credenciales);
                        console.log(result);
                        console.log(result.data);
                        console.log(result.data.contenido); 
                        console.log(result.data.exito);
                        var _login = result.data; 
                        
                        if (result.data.success) {
                             return true;
                           
                        } else {
                             return false;
                        }
                
                    }, function(error) {
                        console.log(error);
                    });
         };


     


    
  
    this.crearUsuario = function (usuario) {
        var Fanatico;
        if($('input[name="tipoUsuario"]:checked').length > 0){
            Fanatico = {
            "F_NombreUsuario":   usuario.nombreUsuario,
            "F_Nombre":          usuario.Nombre,
            "F_Apellido":        usuario.Apellido,
            "F_Password":        usuario.Contrasena,
            "F_Correo":          usuario.Email,
            "F_Foto" :           "",
            "F_FechaNacimiento": usuario.fechaNacimiento,    
            "F_Telefono":        usuario.telefono,
            "F_Ubicacion":       usuario.ubicacion,
            "P_ID":              usuario.pais,
            "U_ID":              usuario.universidad,
            "F_Generos":         $('#sel2').val(),
            "F_Descripcion":     usuario.descripcion,
            "F_Terminos":        $('input[name="aceptoTerminos"]:checked').length > 0
        };
        console.log(Fanatico);
        }
        else {
            Fanatico = {
            "C_NombreUsuario":  usuario.nombreUsuario,
            "C_Nombre":         usuario.Nombre,    
            "C_Apellido":       usuario.Apellido,
            "C_Password":       usuario.Contrasena,
            "C_Correo":         usuario.Email,
            "C_Foto" :          "", 
        }
        console.log(Fanatico);
        }
        $http({
                    method: 'POST',
                    url: "http://192.168.100.12:12345/API/login",
                    headers: {
                        'Content-Type' : 'application/x-www-form-urlencoded'
                    },
                    data: Fanatico
                    }).then(function(result){
                        console.log(Credenciales);
                        console.log(result);
                        console.log(result.data);
                        console.log(result.data.contenido); 
                        console.log(result.data.exito);
                        var _login = result.data; 
                        
                        if (result.data.success) {
                             return true;
                           
                        } else {
                             return false;
                        }
                
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
