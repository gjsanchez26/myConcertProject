using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Festival : Evento
    {
        private string _informacionGeneral;
        private List<Banda> _bandasGanadoras;
        private Banda _recomendacionChef;

        public string InformacionGeneral { get => _informacionGeneral; set => _informacionGeneral = value; }
        internal List<Banda> BandasGanadoras { get => _bandasGanadoras; set => _bandasGanadoras = value; }
        internal Banda RecomendacionChef { get => _recomendacionChef; set => _recomendacionChef = value; }
    }
}
