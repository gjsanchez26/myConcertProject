using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Voto
    {
        private int _id;
        private string _fanatico;
        private int _cantidad;
        private string _banda;
        private string _categoria;
        private  string _cartelera;

        public Voto(int _id, string _fanatico, int _cantidad, string _banda, string _categoria, string _cartelera)
        {
            this._id = _id;
            this._fanatico = _fanatico;
            this._cantidad = _cantidad;
            this._banda = _banda;
            this._categoria = _categoria;
            this._cartelera = _cartelera;
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Fanatico
        {
            get
            {
                return _fanatico;
            }

            set
            {
                _fanatico = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }

            set
            {
                _cantidad = value;
            }
        }

        public string Banda
        {
            get
            {
                return _banda;
            }

            set
            {
                _banda = value;
            }
        }

        public string Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
            }
        }

        public string Cartelera
        {
            get
            {
                return _cartelera;
            }

            set
            {
                _cartelera = value;
            }
        }
    }
}
