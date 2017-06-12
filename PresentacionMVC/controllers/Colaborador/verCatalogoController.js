myConcert.controller("verCatalogoController", function($scope, $http, verCatalogoModel){

    console.log("aaaaaaaa");
    document.getElementById('verCatalogoDiv').onclick = function(e) {
    if(e.target == document.getElementById('verCatalogoDiv')) {
       window.location.href = "#vistaColaborador";          
        } 
    }
    
}); 