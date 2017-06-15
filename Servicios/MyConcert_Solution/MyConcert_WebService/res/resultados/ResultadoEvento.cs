using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.res.resultados
{
    public class ResultadoEvento : Respuesta
    {
        public JObject event_data;
        public JObject[] categories;
    }
}
