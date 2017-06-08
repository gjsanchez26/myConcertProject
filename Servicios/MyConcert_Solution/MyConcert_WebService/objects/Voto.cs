using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Voto
    {
        private int _id;
        private Fanatico _autor;
        private int _cantidadDolares;
        private Banda _banda;
        private Categoria _categoria;
        private Cartelera _cartelera;

        public int Id { get => _id; set => _id = value; }
        public int CantidadDolares { get => _cantidadDolares; set => _cantidadDolares = value; }
        internal Fanatico Autor { get => _autor; set => _autor = value; }
        internal Banda Banda { get => _banda; set => _banda = value; }
        internal Categoria Categoria { get => _categoria; set => _categoria = value; }
        internal Cartelera Cartelera { get => _cartelera; set => _cartelera = value; }
    }
}
