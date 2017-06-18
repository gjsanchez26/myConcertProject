namespace MyConcert.resources.results
{
    public class ResultadoString : Respuesta
    {
        public string content;

        public ResultadoString(bool pExito, string pMensaje)
        {
            this.success = pExito;
            this.content = pMensaje;
        }
    }
}
