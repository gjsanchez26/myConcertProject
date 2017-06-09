using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Cartelera : Evento 
    {
        private string _fechaInicioVotacion;
        private string _fechaFinalVotacion;

        public string FechaInicioVotacion
        {
            get
            {
                return _fechaInicioVotacion;
            }

            set
            {
                _fechaInicioVotacion = value;
            }
        }

        public string FechaFinalVotacion
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
