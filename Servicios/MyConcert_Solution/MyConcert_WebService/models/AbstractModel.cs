using MyConcert.resources.assembler;
using MyConcert.resources.results;

namespace MyConcert.models
{
    //Clase abstracta Model
    public abstract class AbstractModel
    {
        //Atributos en comun necesarios
        protected FacadeDB _manejador;
        protected Assembler _convertidor;
        protected FabricaRespuestas _fabricaRespuestas;
    }
}
