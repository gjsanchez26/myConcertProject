using MyConcert.resources.assembler;
using MyConcert.resources.results;

namespace MyConcert.models
{
    public abstract class AbstractModel
    {
        protected FacadeDB _manejador;
        protected Assembler _convertidor;
        protected FabricaRespuestas _fabricaRespuestas;
    }
}
