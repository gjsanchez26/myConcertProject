using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.viewModels
{
    public class Festival : Evento
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
            this.Id = _id;
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

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Id = json.id;
                this.Nombre = json.name;
                this.Ubicacion = json.ubication;
                this.Pais = json.country;
                this.FechaInicioFestival = json.initial_date;
                this.FechaFinalFestival = json.final_date;
                this.TipoEvento = json.event_type;
                this.Estado = json.state;
                this.Comida = json.food;
                this.Transporte = json.transport;
                this.Servicios = json.services;
                this.RecomendacionChef = json.chef_recommendation;
            }
            catch (Exception e)
            {
                estado = false;
                throw (e);
            }
            return estado;
        }

        public JObject serialize()
        {
            return JObject.FromObject(this);
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
