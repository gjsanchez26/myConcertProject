using MyConcert_WebService.res.usr;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace MyConcert_WebService.controllers
{
    public class UsuariosController : ApiController
    {
        /**
         * @param pRequest JObject : {"usuario": JOBject}
         *
         * */
        public JObject Post(JObject pRequest)
        {
            dynamic request = pRequest;

            try
            {
                Usuario nuevoUsuario = request.user;
                bool response = true;
                return JObject.FromObject(response);
            } catch(Exception e) {
                string error = e.Message;
                return JObject.FromObject(error);
            } 

        }
    }
}
