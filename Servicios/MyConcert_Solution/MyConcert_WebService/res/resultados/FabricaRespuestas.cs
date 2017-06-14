using Newtonsoft.Json.Linq;

namespace MyConcert_WebService.res.resultados
{
    class FabricaRespuestas
    {
        public Respuesta crearRespuesta(bool pExito, JObject pObjeto)
        {
            return new ResultadoObjeto(pExito, pObjeto);
        }

        public Respuesta crearRespuesta(bool pExito, string pMensaje)
        {
            return new ResultadoString(pExito, pMensaje);
        }

        public Respuesta crearRespuesta(bool pExito, JObject[] pArray)
        {
            return new ResultadoArreglo(pExito, pArray);
        }

        public Respuesta crearRespuesta(bool pExito, string pContenido, string pDetalleError)
        {
            return new ResultadoDetalle(pExito, pContenido, pDetalleError);
        }

        public Respuesta crearRespuesta(bool pExito, JObject pUser, JObject[] pGenres)
        {
            return new ResultadoUsuario(pExito, pUser, pGenres);
        }
    }
}
