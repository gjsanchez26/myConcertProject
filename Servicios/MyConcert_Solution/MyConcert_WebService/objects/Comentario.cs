using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Comentario
    {
        private Fanatico _fanatico;
        private DateTime _fecha;
        private string _contenido;

        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        internal Fanatico Fanatico { get => _fanatico; set => _fanatico = value; }
    }

   
}
