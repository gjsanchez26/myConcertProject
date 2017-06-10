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
        private string _pais;
        private DateTime _fechaInicioFestival;
        private DateTime _fechaFinalFestival;
        private string tipoEvento;
        private string estado;

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

        internal string Pais
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

        public DateTime FechaInicioFestival
        {
            get
            {
                return _fechaInicioFestival;
            }

            set
            {
                _fechaInicioFestival = value;
            }
        }

        public DateTime FechaFinalFestival
        {
            get
            {
                return _fechaFinalFestival;
            }

            set
            {
                _fechaFinalFestival = value;
            }
        }

        internal List<Categoria> Categorias
        {
            get
            {
                return _categorias;
            }

            set
            {
                _categorias = value;
            }
        }

        public string TipoEvento { get => tipoEvento; set => tipoEvento = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
