using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.viewModels
{
    public class Pais
    {
        private int _id;
        private string _nombre;

        public Pais(int _id, string _nombre)
        {
            this._id = _id;
            this._nombre = _nombre;
        }

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Id = json.id;
                this.Nombre = json.name;
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

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
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
