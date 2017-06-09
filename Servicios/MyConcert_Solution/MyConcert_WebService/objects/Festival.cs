using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Festival : Evento
    {
        private string comida;
        private string transporte;
        private string servicios;
        private string _recomendacionChef;

        
        public Festival(string nombre,
                        string ubicacion,
                        string pais,
                        DateTime fechaInicioFestival,
                        DateTime fechaFinalFestival,
                        string tipoEvento,
                        string estado,
                        string comida,
                        string transporte,
                        string servicios,
                        string recomendacionChef)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Pais = pais;
            this.FechaInicioFestival = fechaInicioFestival;
            this.FechaFinalFestival = fechaFinalFestival;
            this.TipoEvento = tipoEvento;
            this.Estado = estado;
            this.Comida = comida;
            this.Transporte = transporte;
            this.Servicios = servicios;
            this.RecomendacionChef = recomendacionChef;
        }

        public string Comida { get => comida; set => comida = value; }
        public string Transporte { get => transporte; set => transporte = value; }
        public string Servicios { get => servicios; set => servicios = value; }

        internal string RecomendacionChef
        {
            get
            {
                return _recomendacionChef;
            }

            set
            {
                _recomendacionChef = value;
            }
        }
    }
}
