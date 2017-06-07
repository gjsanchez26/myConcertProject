using MyConcert_WebService.res;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };


        public JObject Post(JObject pRequest)
        {
            dynamic request = pRequest;
            JObject requestProducto = request.producto;
            Resultado response = new Resultado();

            try
            {
                Product nuevoUsuario = requestProducto.ToObject<Product>();
                response.exito = true;
                response.mensajeError = JObject.FromObject(nuevoUsuario);
                return JObject.FromObject(response);
            }
            catch (Exception e)
            {
                response.exito = false;
                response.mensajeError = JObject.FromObject(e.Message);
                return JObject.FromObject(response);
            }

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where(p => string.Equals(p.Category, category,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
