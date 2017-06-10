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

        
        public Festival(int _id,
                        string nombre,
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

        public string Comida
        {
            get
            {
                return comida;
            }

            set
            {
                comida = value;
            }
        }

        public string Transporte
        {
            get
            {
                return transporte;
            }

            set
            {
                transporte = value;
            }
        }

        public string Servicios
        {
            get
            {
                return servicios;
            }

            set
            {
                servicios = value;
            }
        }
    }
}
