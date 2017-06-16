using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.viewModels
{
    class Voto
    {
        private int _id;
        private string _fanatico;
        private int _cantidad;
        private string _banda;
        private string _categoria;
        private  int _cartelera;

        public Voto(int _id, string _fanatico, int _cantidad, string _banda, string _categoria, int _cartelera)
        {
            this._id = _id;
            this._fanatico = _fanatico;
            this._cantidad = _cantidad;
            this._banda = _banda;
            this._categoria = _categoria;
            this._cartelera = _cartelera;
        }

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                Id = json.id;
                Fanatico = json.user;
                Cantidad = json.amount;
                Banda = json.band;
                Categoria = json.category;
                Id = json.event_;
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

        public int Cartelera
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
