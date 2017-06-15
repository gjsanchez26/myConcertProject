using MyConcert_WebService.res.serial;
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
            this.Id = _id;
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
            SerialHelper serial = new SerialHelper();
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Id = (int) json.id;
                this.Nombre = (string) json.name;
                this.Ubicacion = (string) json.ubication;
                this.Pais = (string) json.country;
                this.FechaInicioFestival = serial.fecha(json.initial_date);
                this.FechaFinalFestival = serial.fecha(json.final_date);
                this.FechaFinalVotacion = serial.fecha(json.vote_final_date);
                this.TipoEvento = (string) json.event_type;
                this.Estado = (string) json.state;
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
