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

        public string Muestra
        {
            get
            {
                return _muestra;
            }

            set
            {
                _muestra = value;
            }
        }

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

        public bool DisponibilidadSpotify
        {
            get
            {
                return _disponibilidadSpotify;
            }

            set
            {
                _disponibilidadSpotify = value;
            }
        }
    }

        

        
    }
