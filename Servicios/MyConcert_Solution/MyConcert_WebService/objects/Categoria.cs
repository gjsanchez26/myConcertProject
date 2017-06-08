using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Categoria
    {
        private string _nombre;
        private List<Banda> _bandas;

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        internal List<Banda> Bandas
        {
            get
            {
                return _bandas;
            }

            set
            {
                _bandas = value;
            }
        }
    }
}
