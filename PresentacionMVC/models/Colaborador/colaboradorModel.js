myConcert.service("colaboradorModel", function($routeParams, $location, $http){
var myURL ="http://192.168.100.12:12345";    
this.obtenerCategorias = function(listaCatego){
        console.log("ObtenerCategorias");
        console.log(listaCatego)
        var json=  [
            {
                nombre : "Bob Marley",
                edad : "32 años"
            },
            {
                nombre : "Pink Floyd",
                edad : "24 años"
            },
            {
                nombre : "Guns & Roses",
                edad : "28 años"
            },
            {
                nombre : "Metallica",
                edad : "18 años"
            },
            {
                nombre : "System of a Down",
                edad : "45 años"
            },
            {
                nombre : "Bob Marley1",
                edad : "32 años"
            },
            {
                nombre : "Pink Floyd1",
                edad : "24 años"
            },
            {
                nombre : "Guns & Roses1",
                edad : "28 años"
            },
            {
                nombre : "Metallica1",
                edad : "18 años"
            },
            {
                nombre : "System of a Down1",
                edad : "45 años"
            },
            {
                nombre : "Bob Marley",
                edad : "32 años"
            },
            {
                nombre : "Pink Floyd",
                edad : "24 años"
            },
            {
                nombre : "Guns & Roses",
                edad : "28 años"
            },
            {
                nombre : "Metallica",
                edad : "18 años"
            },
            {
                nombre : "System of a Down",
                edad : "45 años"
            },
            {
                nombre : "Bob Marley1",
                edad : "32 años"
            },
            {
                nombre : "Pink Floyd1",
                edad : "24 años"
            },
            {
                nombre : "Guns & Roses1",
                edad : "28 años"
            },
            {
                nombre : "Metallica1",
                edad : "18 años"
            },
            {
                nombre : "System of a Down1",
                edad : "45 años"
            }
    
    
    ];
        console.log(json);
        listaCatego = json;

    }
    
    
    
    
    
    
});