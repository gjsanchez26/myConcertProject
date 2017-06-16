using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.viewModels
{
    public class Comentario
    {
        private int _id;
        private string _fanatico;
        private DateTime _fecha;
        private string _contenido;
        private float _calificacion;
        private string _estado;
        private string _banda;

        public Comentario(int _id, string _fanatico, DateTime _fecha, string _contenido, float _calificacion, string _estado, string _banda)
        {
            this._id = _id;
            this._fanatico = _fanatico;
            this._fecha = _fecha;
            this._contenido = _contenido;
            this._calificacion = _calificacion;
            this._estado = _estado;
            this._banda = _banda;
        }

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Id = (int)json.id;
                this.Fanatico = (string)json.user;
                this.Fecha = json.date; //colocar metodo para datetime
                this.Contenido = (string)json.content;
                this.Calificacion = (float)json.calification;
                this.Estado = (string)json.state;
                this.Banda = (string)json.band;
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

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
            }
        }

        public string Contenido
        {
            get
            {
                return _contenido;
            }

            set
            {
                _contenido = value;
            }
        }

        public float Calificacion
        {
            get
            {
                return _calificacion;
            }

            set
            {
                _calificacion = value;
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
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
    }

   
}
