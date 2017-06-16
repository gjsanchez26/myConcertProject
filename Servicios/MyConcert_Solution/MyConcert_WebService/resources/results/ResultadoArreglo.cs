using Newtonsoft.Json.Linq;

namespace MyConcert.resources.results
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
