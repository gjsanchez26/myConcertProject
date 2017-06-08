namespace MyConcert_WebService.res.resultados
{
    public class ResultadoString : Respuesta
    {
        public string error;

        public ResultadoString(bool pExito, string pMensaje)
        {
            this.exito = pExito;
            this.error = pMensaje;
        }
    }
}
