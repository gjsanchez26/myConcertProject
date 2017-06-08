using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Cancion
    {
        private string _nombre;
        private bool _disponibilidadSpotify;
        private string _muestra;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public bool DisponibilidadSpotify { get => _disponibilidadSpotify; set => _disponibilidadSpotify = value; }
        public string Muestra { get => _muestra; set => _muestra = value; }
    }
}
