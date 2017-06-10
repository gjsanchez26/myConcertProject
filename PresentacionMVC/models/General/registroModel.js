myConcert.service("registroModel", function($routeParams, $location, $http){

this.verificarUsuario = function(usuarioLogin){  
    
    console.log("1");
    localStorage.setItem("userName",usuarioLogin.login); 
    var Credenciales = {
                        "username":usuarioLogin.login,
                        "password":usuarioLogin.password
                   };
    console.log(Credenciales);
    window.location.href = "#vistaColaborador"
    $http({
        method: 'POST',
        url: "http://192.168.100.12:12345/API/login",
        headers: {'Content-Type' : 'application/x-www-form-urlencoded'},
        data: Credenciales

        }).then(function(result){
                console.log(Credenciales);
                console.log(result);

                if (result.data.success) {
                      if (result.data.tipoUsuario) window.location.href = "#vistaColaborador";
                      else window.location.href = "#vistaFanatico";
                    }
                else alert("Contraseña y/o Usuario Incorrecto")


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
                url: "http://192.168.100.12:12345/API/Usuarios",
                headers: {
                    'Content-Type' : 'application/x-www-form-urlencoded'
                },
                data: Fanatico
                }).then(function(result){
                    if (result.data.success) alert("Usuario Creado");
                    else alert("Usuario No Creado, Intente más tarde")

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
