using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Pais
    {
        private string _nombre;
        private string _id;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Id { get => _id; set => _id = value; }
    }
}
