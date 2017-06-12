using System;

namespace MyConcert_WebService.objects
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
    }
}
