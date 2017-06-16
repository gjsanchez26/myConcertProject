myConcert.service("colaboradorModel", function($routeParams, $location, $http){
var myURL ="http://192.168.100.12:12345"; 
var listaBandasActuales={};   
this.crearFestival = function(){
            var checkboxes = document.getElementsByName('bandasSeleccionadas');
            var vals = "";
        	for 
            for (var i=0, n=checkboxes.length;i<n;i++) 
            {
                if (checkboxes[i].checked) 
                {
                    vals += ","+checkboxes[i].value;
                }
            }
            if (vals) vals = vals.substring(1);
            console.log(vals);

        }
    
this.obtenerUnaCartelera=function(cartelera){
    var listaBandasActuales={}
    
     var json = {
  "event_data": {
    "name": "nombreCartelera",
    "ubication" : "ubicacion",
    "country" : "pais",
    "initial_date" : new Date(),
    "final_date" : new Date(),
    "vote_final_date" : new Date(),
    "event_type" : "Cartelera",
    "state" : "active"
  },
  "categories" : [
            {
            "category" : "categoria1",
            "results" : [{"band":"banda1","votes":500},
                         {"band":"banda2","votes":1500}, 
                         {"band":"banda3","votes":2500},
                         {"band":"banda4","votes":3500},
                         {"band":"banda5","votes":4500}
                        ],
            },
            {
            "category" : "categoria2",
            "results" : [{"band":"banda21","votes":2500},
                         {"band":"banda22","votes":21500}, 
                         {"band":"banda23","votes":22500},
                         {"band":"banda24","votes":23500},
                         {"band":"banda25","votes":24500}
                        ],
            },
            {
            "category" : "categoria3",
            "results" : [{"band":"banda31","votes":3500},
                         {"band":"banda32","votes":31500}, 
                         {"band":"banda33","votes":32500},
                         {"band":"banda34","votes":33500},
                         {"band":"banda35","votes":34500}
                        ],
            },
            
  ]
}
    console.log("Get Informacion de "+cartelera.nombre)
    console.log(json);
    return json;
    
}
this.obtenerListaCarteleras = function(){
        console.log("Get Obtener Carteleras");
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
        return json;

    }

    
    
    
    
    
});