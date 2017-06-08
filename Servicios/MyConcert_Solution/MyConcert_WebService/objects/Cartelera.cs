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

        public string FechaInicioVotacion { get => _fechaInicioVotacion; set => _fechaInicioVotacion = value; }
        public string FechaFinalVotacion { get => _fechaFinalVotacion; set => _fechaFinalVotacion = value; }
    }
}
