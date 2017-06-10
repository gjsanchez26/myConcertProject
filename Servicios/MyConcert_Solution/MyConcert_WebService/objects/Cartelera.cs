using System;

namespace MyConcert_WebService.objects
{
    class Cartelera : Evento 
    {
        private DateTime _fechaFinalVotacion;

        public Cartelera(string nombre,
                        string ubicacion,
                        string pais,
                        DateTime fechaInicioFestival,
                        DateTime fechaFinalFestival, 
                        DateTime fechaFinalVotacion,
                        string tipoEvento)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Pais = pais;
            this.FechaInicioFestival = fechaInicioFestival;
            this.FechaFinalFestival = fechaFinalFestival;
            this.FechaFinalVotacion = fechaFinalVotacion;
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
