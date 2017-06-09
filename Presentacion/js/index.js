
//ANGULAR MODULE TO MANAGE INDEX.HTML
var url = 'http://192.168.100.12:12345';
var indexApp = angular.module('index',[])
.controller('indexCtrl', ['$scope', '$http', function ($scope, $http) {
    var input;
   
    var mensaje = {};
  
    //FUNCTION TO CHECK IF USER EXIST IN DB

       
    $scope.ingresarUsuario = function()
        {
            localStorage.setItem("userName", $scope.U_ID); 
        localStorage.setItem("userID", $scope.U_Password);
        var Credenciales = {
            "username":$scope.U_ID,
            "password":$scope.U_Password
        };
          var _data = '{"usuario":"'+$scope.U_ID+'", "contraseña":'+"'"+$scope.U_Password+"'"+'}';
            $http({
                    method: 'POST',
                    url: url+"/API/login",
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
                             window.location.assign("/pages/vistaColaborador.html");
                           
                        } else {
                            
                        }
                    }, function(error) {
                        console.log(error);
                    });
         };
      /*  console.log(Credenciales);
        console.log("Usuario "+$scope.U_ID);
        console.log("Usuario "+$scope.U_Password);
        ;*/

                    
            
}]);

indexApp = angular.module('index')
.controller('registroCtrl', ['$scope', '$http', function ($scope, $http) {
     var radio_value;
    var branchStores;
    var employees;
    var Charges;
    var filex;
    $scope.upload;
    $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };
  
    $http.get(url + '/api/sucursal/get/S_ID/undefined')
            .then( function (response) {    
              $scope.branchStores = response.data;           
        });
     $http.get(url + '/api/role/get/R_ID/undefined')
            .then( function (response) {    
              $scope.Charges = response.data;           
        });
      
 
    $http.get(url + '/api/sucursal/get/S_ID/undefined')
            .then( function (response) {    
              $scope.branchStores = response.data;           
        });
     $http.get(url + '/api/role/get/R_ID/undefined')
            .then( function (response) {    
              $scope.Charges = response.data;           
        });
     
    $(document).on('change', ':file', function() {
            input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [numFiles, label]);
    });
    

    
  
    $scope.crearUsuario = function () {
        if (radio_value == '1') {
            var Fanatico = {
            
            "F_NombreUsuario": $scope.nombreUsuario,
            "F_Nombre": $scope.Nombre,
            "F_Apellido": $scope.Apellido,
            "F_Password": $scope.Contrasena,
            "F_Correo": $scope.Email,
            "F_Foto" : "",
            "F_FechaNacimiento": $scope.F_Nacimiento,    
            "F_Telefono": $scope.F_Telefono,
            "F_Ubicacion":$scope.F_Ubicacion,
            "P_ID":$scope.F_Pais,
            "U_ID":$scope.F_Universidad,
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
            "C_NombreUsuario": $scope.nombreUsuario,
            "C_Nombre": $scope.Nombre,
            "C_Apellido": $scope.Apellido,
            "C_Password": $scope.Contrasena,
            "C_Correo": $scope.Email,
            "C_Foto" : "",
            
        }
        console.log(Colaborador);
        
        
        $http.post(url + '/api/employees/post',Colaborador).
        success(function (data, status, headers, config) {
            alert('the new employee has been posted!');
        }).
        error(function (data, status, headers, config) {
            alert('Error while posting the new employee')
        });
      
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
    
    
}]);



