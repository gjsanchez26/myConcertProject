using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Fanatico : Usuario
    {
        private string _fechaNacimiento;
        private string _telefono;
        private Pais _pais;
        private string _ubicacion;
        private List<GeneroMusical> _generos;
        private string _descripcionPersonal;

        public string FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }

            set
            {
                _fechaNacimiento = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        internal Pais Pais
        {
            get
            {
                return _pais;
            }

            set
            {
                _pais = value;
            }
        }

        public string Ubicacion
        {
            get
            {
                return _ubicacion;
            }

            set
            {
                _ubicacion = value;
            }
        }

        internal List<GeneroMusical> Generos
        {
            get
            {
                return _generos;
            }

            set
            {
                _generos = value;
            }
        }

        public string DescripcionPersonal
        {
            get
            {
                return _descripcionPersonal;
            }

            set
            {
                _descripcionPersonal = value;
            }
        }
    }
}
