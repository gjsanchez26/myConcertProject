namespace MyConcert.resources.results
{
    public class ResultadoString : Respuesta
    {
        public string detail;

        public ResultadoString(bool pExito, string pMensaje)
        {
            this.success = pExito;
            this.detail = pMensaje;
        }
    }
}
