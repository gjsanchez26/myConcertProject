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

        internal Fanatico Autor
        {
            get
            {
                return _autor;
            }

            set
            {
                _autor = value;
            }
        }

        public int CantidadDolares
        {
            get
            {
                return _cantidadDolares;
            }

            set
            {
                _cantidadDolares = value;
            }
        }

        internal Banda Banda
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

        internal Categoria Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
            }
        }

        internal Cartelera Cartelera
        {
            get
            {
                return _cartelera;
            }

            set
            {
                _cartelera = value;
            }
        }
    }
}
