using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    public class Banda
    {
        private int _id;
        private string _nombre;
        private float _calificacion;
        private string _estado;

        public Banda(string pNombre, string estado)
        {
            this._id = 0;
            this._nombre = _nombre;
            this._calificacion = 0;
            this._estado = _estado;
        }

        public Banda(int _id, string _nombre, float _calificacion, string _estado)
        {
            this._id = _id;
            this._nombre = _nombre;
            this._calificacion = _calificacion;
            this._estado = _estado;
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
