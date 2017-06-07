using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace MyConcert_WebService.controllers
{
    public class UsuariosController : ApiController
    {
        /**
         * @param pRequest JObject : {"tipoUsuario": , "usuario": JOBject}
         *
         * */
        public string Post(JObject pRequest)
        {
            dynamic request = pRequest;
            string tipoUsuario = request.type;
            Usuario nuevoUsuario = request.user;

            switch(tipoUsuario)
            {
                case "fanatico":
                    return "TODO fanatico";
                case "colaborador":
                    return "TODO colaborador";
                default:
                    return "No existe este tipo de usuario";
            }
        }
    }
}
