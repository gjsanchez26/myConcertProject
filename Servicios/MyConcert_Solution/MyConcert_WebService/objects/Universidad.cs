using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    public class Universidad
    {
        private int _id;
        private string _nombre;

        public Universidad(int _id, string _nombre)
        {
            this._id = _id;
            this._nombre = _nombre;
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
    }
}
