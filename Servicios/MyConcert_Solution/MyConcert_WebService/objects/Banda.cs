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

        public string Nombre { get => _nombre; set => _nombre = value; }
        public float Calificacion { get => _calificacion; set => _calificacion = value; }
        internal List<Cancion> Canciones { get => _canciones; set => _canciones = value; }
        internal List<MiembroBanda> Miembros { get => _miembros; set => _miembros = value; }
        internal List<GeneroMusical> Generos { get => _generos; set => _generos = value; }
        internal List<Comentario> Comentarios { get => _comentarios; set => _comentarios = value; }
    }
}
