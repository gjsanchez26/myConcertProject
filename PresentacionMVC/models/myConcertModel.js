
myConcert.service("myConcertModel", function(){
 
	this.getNotas = function(){
		return [
            {
                id : 0,
                nombre : "Israel Parra",
                edad : "32 años"
            },
            {
                id : 1,
                nombre : "Andrés Cuenca",
                edad : "24 años"
            },
            {
                id : 2,
                nombre : "Juan",
                edad : "28 años"
            },
            {
                id : 3,
                nombre : "Pepito",
                edad : "18 años"
            },
            {
                id : 4,
                nombre : "Manuel",
                edad : "45 años"
            }
        ]
	}
 
});