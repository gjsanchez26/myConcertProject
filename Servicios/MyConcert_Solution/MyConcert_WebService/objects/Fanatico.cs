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

        public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Ubicacion { get => _ubicacion; set => _ubicacion = value; }
        public string DescripcionPersonal { get => _descripcionPersonal; set => _descripcionPersonal = value; }
        internal Pais Pais { get => _pais; set => _pais = value; }
        internal List<GeneroMusical> Generos { get => _generos; set => _generos = value; }
    }
}
