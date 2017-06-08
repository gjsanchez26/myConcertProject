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

        internal Fanatico Fanatico
        {
            get
            {
                return _fanatico;
            }

            set
            {
                _fanatico = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
            }
        }

        public string Contenido
        {
            get
            {
                return _contenido;
            }

            set
            {
                _contenido = value;
            }
        }
    }

   
}
