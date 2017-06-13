using Newtonsoft.Json.Linq;
using System;

namespace MyConcert_WebService.viewModels
{
    public class Cartelera : Evento 
    {
        private DateTime _fechaFinalVotacion;

        public Cartelera(int _id,
                        string nombre,
                        string ubicacion,
                        string pais,
                        DateTime fechaInicioFestival,
                        DateTime fechaFinalFestival, 
                        DateTime fechaFinalVotacion,
                        string tipoEvento,
                        string estado)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Pais = pais;
            this.FechaInicioFestival = fechaInicioFestival;
            this.FechaFinalFestival = fechaFinalFestival;
            this.FechaFinalVotacion = fechaFinalVotacion;
            this.TipoEvento = tipoEvento;
            this.Estado = estado;
        }

        public DateTime FechaFinalVotacion
        {
            get
            {
                return _fechaFinalVotacion;
            }

            set
            {
                _fechaFinalVotacion = value;
            }
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
                this.FechaFinalVotacion = json.vote_final_date;
                this.TipoEvento = json.event_type;
                this.Estado = json.state;
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
    }
}
