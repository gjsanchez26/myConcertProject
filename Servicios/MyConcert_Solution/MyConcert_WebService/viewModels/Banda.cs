using Newtonsoft.Json.Linq;
using System;

namespace MyConcert_WebService.viewModels
{
    public class Banda
    {
        private int _id;
        private string _nombre;
        private float _calificacion;
        private string _estado;
        public string url_image;

        public Banda(int id, string nombre, float calificacion, string estado)
        {
            _id = id;
            _nombre = nombre;
            _calificacion = calificacion;
            _estado = estado;
        }

        public Banda(string nombre, string estado)
        {
            _id = 0;
            _nombre = nombre;
            _calificacion = 0;
            _estado = estado;
        }

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                Id = json.id;
                Nombre = json.name;
                Calificacion = json.calification;
                Estado = json.state;
            } catch(Exception e)
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

        public string Nombre { get { return _nombre; }  set { _nombre = value; } }
        public float Calificacion { get { return _calificacion; }  set { _calificacion = value; } }

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
    }
}
