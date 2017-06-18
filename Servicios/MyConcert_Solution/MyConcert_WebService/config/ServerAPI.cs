using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace MyConcert.server
{
    public class ServerAPI
    {
        private string _url_servidor;
        private string _puerto;
        private HttpSelfHostServer _servidor;
        private HttpSelfHostConfiguration _configuracion_servidor;
        
        public ServerAPI()
        {
            _url_servidor = "http://localhost:";
            _puerto = "12345";             //Puerto Release
            //_puerto = "22345";                      //Puerto Debug

            _configuracion_servidor = new HttpSelfHostConfiguration(_url_servidor + _puerto);

            _configuracion_servidor.Routes.MapHttpRoute(
                "MyConcertAPI", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            //Habilita CORS
            _configuracion_servidor.EnableCors();

            //Configuracion para aceptar formato JSON
            var appXmlType =
                _configuracion_servidor.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            _configuracion_servidor.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //Inicializa el servidor
            using (_servidor = new HttpSelfHostServer(_configuracion_servidor))
            {
                _servidor.OpenAsync().Wait();
                Console.WriteLine("---- MyConcert ---- Servidor API -----");
                Console.WriteLine("Presione ENTER para cerrar.");
                Console.ReadLine();
            }
        }

        //Metodo Main.
        //Inicia el servidor API.
        public static void Main(string[] args)
        {
            //ServerAPI _server = new ServerAPI();
            List<bandas> obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.bandas.Join(context.categoriasevento,
                                                   b => b.PK_bandas,
                                                   ce => ce.FK_CATEGORIASEVENTO_BANDAS,
                                                   (b, ce) => new { b, ce })
                                                   .Where(w => w.ce.FK_CATEGORIASEVENTO_CATEGORIAS == 1 && w.ce.FK_CATEGORIASEVENTO_EVENTOS == 1)
                                                   .Select(s => s.b).ToList(); ;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
