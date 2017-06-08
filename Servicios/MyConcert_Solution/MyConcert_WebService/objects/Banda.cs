using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Banda
    {
        private string _nombre;
        private List<Cancion> _canciones;
        private List<MiembroBanda> _miembros;
        private List<GeneroMusical> _generos; 
        private List<Comentario> _comentarios;
        private float _calificacion;

        public string Nombre { get { return _nombre; }  set { _nombre = value; } }
        public float Calificacion { get { return _calificacion; }  set { _calificacion = value; } }
        internal List<Cancion> Canciones { get { return _canciones; } set { _canciones = value; } }
        internal List<MiembroBanda> Miembros { get { return _miembros; } set { _miembros = value; } }
        internal List<GeneroMusical> Generos { get {return _generos; } set { _generos = value; } }
        internal List<Comentario> Comentarios { get { return _comentarios; } set { _comentarios = value; } }
    }
}
