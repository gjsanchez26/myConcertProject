﻿using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace MyConcert_WebService.server
{
    public class Server
    {
        public Server()
        {
            string url = "http://localhost:";
            //string port = "12345";            //Puerto Release
            string port = "22345";              //Puerto Debug
            var config = new HttpSelfHostConfiguration(url+port);

            config.Routes.MapHttpRoute(
                "MyConcertAPI", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            //Habilita CORS
            config.EnableCors();

            //Format JSON
            var appXmlType =
                config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("---- MyConcert ---- Servidor API -----");
                Console.WriteLine("Presione ENTER para cerrar.");
                Console.ReadLine();
            }
        }
    }
}
