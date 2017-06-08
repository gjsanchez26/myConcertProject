using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Evento
    {
        private string _nombre;
        private string _ubicacion;
        private Pais _pais;
        private string _fechaInicioFestival;
        private string _horaInicioFestival;
        private string _fechaFinalFestival;
        private string _horaFinalFestival;
        private List<Categoria> _categorias;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Ubicacion { get => _ubicacion; set => _ubicacion = value; }
        public string FechaInicioFestival { get => _fechaInicioFestival; set => _fechaInicioFestival = value; }
        public string HoraInicioFestival { get => _horaInicioFestival; set => _horaInicioFestival = value; }
        public string FechaFinalFestival { get => _fechaFinalFestival; set => _fechaFinalFestival = value; }
        public string HoraFinalFestival { get => _horaFinalFestival; set => _horaFinalFestival = value; }
        internal Pais Pais { get => _pais; set => _pais = value; }
        internal List<Categoria> Categorias { get => _categorias; set => _categorias = value; }
    }
}
