using Newtonsoft.Json.Linq;

namespace MyConcert_WebService.res.resultados
{
    public class ResultadoArreglo : Respuesta
    {
        private JObject[] elements;

        public ResultadoArreglo(bool pSuccess, JObject[] pArray)
        {
            this.success = pSuccess;
            this.Elements = pArray;
        }

        public JObject[] Elements { get { return elements; } set { elements = value; } }
    }
}
