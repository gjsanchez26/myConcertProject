
myConcert.service("registroModel", function( $http){
    console.log("Here2x");
     var mensaje = {};
     var radio_value;
     
    //FUNCTION TO CHECK IF USER EXIST IN DB
      this.formFanatico = function () {
          console.log(this.U_ID);
          $("#fanaticoForm").fadeIn();
          $("#colaboradorForm").fadeOut();
          return this.U_ID;
      }
      this.formColaborador = function () {
          console.log("asdf");
          $("#fanaticoForm").fadeIn();
          $("#colaboradorForm").fadeOut();
        } 
            

     this.verificarUsuario = function(id,nombre)
            {   
                console.log("1");
                console.log($scope.U_ID);
                localStorage.setItem("userName",id); 
                localStorage.setItem("userID",nombre);
                var Credenciales = {
                    "username":id,
                    "password":nombre
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


     
     $(document).on('change', ':file', function() {
            input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [numFiles, label]);
     });
    

    
  
    this.crearUsuario = function () {
        if (radio_value == '1') {
            var Fanatico = {
            
            "F_NombreUsuario": this.nombreUsuario,
            "F_Nombre": this.Nombre,
            "F_Apellido": this.Apellido,
            "F_Password": this.Contrasena,
            "F_Correo": this.Email,
            "F_Foto" : "",
            "F_FechaNacimiento": this.F_Nacimiento,    
            "F_Telefono": this.F_Telefono,
            "F_Ubicacion":this.F_Ubicacion,
            "P_ID":this.F_Pais,
            "U_ID":this.F_Universidad,
            "F_Generos":$('#sel2').val(),
            "F_Descripcion": document.getElementById("F_Descripcion").value,
            "F_Terminos":$('#tipoUsuario').val()
            
        };
            console.log(Fanatico);
            $http.post(url + '/api/employees/post',Colaborador).
        success(function (data, status, headers, config) {
            alert('the new employee has been posted!');
        }).
        error(function (data, status, headers, config) {
            alert('Error while posting the new employee')
        });
        }
          
          
         else  {
          var Colaborador = {
            "C_NombreUsuario": this.nombreUsuario,
            "C_Nombre":  "",   
            "C_Apellido": this.Apellido,
            "C_Password": this.Contrasena,
            "C_Correo": this.Email,
            "C_Foto" : "",
            
        }
        console.log(Colaborador);

      
    }}
    $(document).ready(function() {
        
       
        $(':file').on('fileselect', function(event, numFiles, label) {
            console.log(numFiles);
            console.log(label);
        });

      $("input[name$='bn']").click(function() {
        radio_value = $(this).val();
        if (radio_value == '0') {
          $("#dlcert").fadeIn("slow");
          $("#contact").fadeOut("slow");
          
        } else if (radio_value == '1') {
          $("#contact").fadeIn("slow");
          $("#dlcert").fadeOut("slow");
        }
          else {
          $("#dlcert").fadeIn("slow");
          $("#contact").fadeOut("slow"); 
              
          }
      });
    });

    $('input[name="bn"]').change(function() {
       if($(this).is(':checked') && $(this).val() == '0') {
            $('#myModal').modal('show');
       }
    });
    
    


  
    $('.tab a').on('click', function (e) {

      e.preventDefault();

      $(this).parent().addClass('active');
      $(this).parent().siblings().removeClass('active');

      target = $(this).attr('href');

      $('.tab-content > div').not(target).hide();

      $(target).fadeIn(600);

    });
});
