using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.viewModels
{
    public class MiembroBanda
    {
        private int _id;
        private string _nombre;
        private string _banda;

        public MiembroBanda(int _id, string _nombre, string _banda)
        {
            this._id = _id;
            this._nombre = _nombre;
            this._banda = _banda;
        }

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Id = json.id;
                this.Nombre = json.name;
                this.Banda = json.band;
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
