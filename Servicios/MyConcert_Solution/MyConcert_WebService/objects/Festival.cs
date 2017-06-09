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

        public string InformacionGeneral
        {
            get
            {
                return _informacionGeneral;
            }

            set
            {
                _informacionGeneral = value;
            }
        }

        internal List<Banda> BandasGanadoras
        {
            get
            {
                return _bandasGanadoras;
            }

            set
            {
                _bandasGanadoras = value;
            }
        }

        internal Banda RecomendacionChef
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
