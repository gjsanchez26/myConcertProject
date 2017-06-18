myConcert.service("crearCategoriaModel", function($routeParams, $location, $http){
var myURL = localStorage.getItem("url");   

this.crearCategoria = function (categoria) {
    var categoria;
    
       categoria = {
      "name": categoria.nombre,
      
    }
    
    console.log(categoria);
    
    $http({
                method: 'POST',
                url: myURL+"/API/Categorias",
                headers: {
                    'Content-Type' : 'application/json'
                },
                data: categoria
                }).then(function(result){
                    if (result.data.success)
                    {alert("Categoria Creada");
                     window.location.href = "#vistaColaborador";
                    }
                    else alert(result.data.content)

                }, function(error) {
                    console.log(error);
                });
} 
});