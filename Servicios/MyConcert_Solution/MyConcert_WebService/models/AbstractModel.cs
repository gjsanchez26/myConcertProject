using MyConcert.res.assembler;
using MyConcert.res.resultados;

namespace MyConcert.models
{
    public abstract class AbstractModel
    {
        private ManejadorBD _manejador;
        private Assembler _convertidor;
        private FabricaRespuestas _fabricaRespuestas;
    }
}
