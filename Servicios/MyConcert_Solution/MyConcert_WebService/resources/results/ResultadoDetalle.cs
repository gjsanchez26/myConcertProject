namespace MyConcert.resources.results
{
    public class ResultadoDetalle : Respuesta
    {
        public string content;
        public string error_detail;

        public ResultadoDetalle(bool pSuccess, string pContent, string pError_detail)
        {
            this.success = pSuccess;
            this.content = pContent;
            this.error_detail = pError_detail;
        }
    }
}
