using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
