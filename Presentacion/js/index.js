
/*///ANGULAR MODULE TO MANAGE INDEX.HTML
var url='http://bryan:7580';
var indexApp = angular.module('index',["ngRoute"]).config(function($routeProvider, $locationProvider) {
    $routeProvider
    .when("/", {
        templateUrl : "/pages/index.html"
    })
    .when("/vistaColaborador", {
        templateUrl : "/pages/vistaColaborador1.htm",
        controller: 
    })
    .when("/vistaFanatico", {
        templateUrl : "/pages/vistaFanatico.html"
    })

}); */

var url='http://172.18.4.19';
var indexApp = angular.module('index',[]);
indexApp.controller('indexCtrl', ['$scope', '$http', function ($scope, $http) {
    var input;
   
    var mensaje = {};
  
    //FUNCTION TO CHECK IF USER EXIST IN DB
   
    $scope.checkUser = function()
        {
                $http.get(url+'/api/Employees/get/W_ID,W_Password/'+$scope.U_ID +","+$scope.U_Password)
                    .then(function (response) 
                {
                console.log(response.data[0]);
                mensaje=response.data[0];
               
                console.log(mensaje.W_ID);
                localStorage.setItem("userName", mensaje.W_Name); 
                localStorage.setItem("userID", mensaje.W_ID);
                window.location.assign("/pages/clientView.html");

                });        
            
        }}]);

indexApp = angular.module('index')
.controller('registroCtrl', ['$scope', '$http', function ($scope, $http) {
    var radio_value;
    var listaPaises;
    var listaUniversidades;
    var listaGeneros;
    var file;
    $scope.upload;
    $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };
  
     $http.get(url + '/api/Pais/get/p_ID/undefined')
            .then( function (response) {    
              $scope.listaPaises = response.data;           
        });
     $http.get(url + '/api/Universidad/get/U_ID/undefined')
            .then( function (response) {    
              $scope.listaGeneros = response.data;           
        });
    
     $http.get(url + '/api/Genero/get/G_ID/undefined')
            .then( function (response) {    
              $scope.listaGeneros = response.data;           
        });
      
    $(document).on('change', ':file', function() {
            input = $(this);
            file = $(this);
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [numFiles, label]);
    });
    

    
  
    $scope.crearUsuario = function () {
        if($scope.Contrasena==$scope.Confirmacion){
            if (radio_value == '0') {
              var Colaborador = {
                "C_NombreUsuario": $scope.nombreUsuario,
                "C_Nombre": $scope.Nombre,
                "C_Apellido": $scope.Apellido,
                "C_Password": $scope.Contrasena,
                "C_Correo": $scope.Email,
                "C_Foto" : file
                }
                console.log(Colaborador);

                $http({
                    method: 'POST',
                    url: url+'/Usuarios',
                    headers: {
                        'Content-Type' : 'application/x-www-form-urlencoded'
                    },
                    data: Colaborador
                    }).then(function(result){                         
                        alert('the new employee has been posted!');
                    }, function(error) {
                        alert('the new employee has been posted!');
                    }); 
            
            }    
             else {
                var Fanatico = {
                "F_NombreUsuario": $scope.nombreUsuario,
                "F_Nombre": $scope.Nombre,
                "F_Apellido": $scope.Apellido,
                "F_Password": $scope.Contrasena,
                "F_Correo": $scope.Email,
                "F_Foto" : file,
                "F_FechaNacimiento": document.getElementById("F_FechaNacimiento").value,    
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
            } }else alert('Confirmacion y Contraseña Diferente');
    
    }
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



