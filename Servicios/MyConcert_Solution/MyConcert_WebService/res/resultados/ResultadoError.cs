namespace MyConcert_WebService.res.resultados
{
    public class ResultadoString : Respuesta
    {
        public string contenido;

        public ResultadoString(bool pExito, string pMensaje)
        {
            this.exito = pExito;
            this.contenido = pMensaje;
        }
    }
}
