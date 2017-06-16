using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.viewModels
{
    public class CategoriaBanda
    {
        public int _categoriaID;
        public int[] _bandasID;

        public CategoriaBanda(int categoriaID, int[] bandasID)
        {
            _categoriaID = categoriaID;
            _bandasID = bandasID;
        }

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this._categoriaID = json.id;
                this._bandasID = json.bands;
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
    }
}
