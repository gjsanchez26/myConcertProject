using Newtonsoft.Json.Linq;

namespace MyConcert.res.resultados
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

        public Respuesta crearRespuesta(bool pExito, JObject pBand, JObject[] pGenres, JObject[] pMembers, JObject[] pSongs, JObject[] pComments)
        {
            return new ResultadoBanda(pExito, pBand, pGenres, pMembers, pSongs, pComments);
        }

        public Respuesta crearRespuestaEvento(bool pExito, JObject[] pCategories, JObject pEventData)
        {
            return new ResultadoEvento(pExito, pEventData, pCategories);
        }
    }
}
