using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace ServidorWEB
{
    class Servidor
    {
        static void Main(string[] args)
        {
            RestDemoServices DemoServices = new RestDemoServices();
            WebHttpBinding binding = new WebHttpBinding();
            WebHttpBehavior behavior = new WebHttpBehavior();

            WebServiceHost _serviceHost = new WebServiceHost(DemoServices, new Uri("http://localhost:8000/DEMOService"));
            _serviceHost.AddServiceEndpoint(typeof(IRESTDemoServices), binding, "");
            _serviceHost.Open();
            Console.ReadKey();
            _serviceHost.Close();

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("---- MyConcert ---- Servidor API -----");
                Console.WriteLine("Presione ENTER para cerrar.");
                Console.ReadLine();
                Console.WriteLine("Confirmacion...");
                Console.ReadLine();
            }
        }
    }
}
