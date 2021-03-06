﻿using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.viewModels
{
    public class Cancion
    {
        private int _id;
        private string _nombre;
        private string _banda;

        public Cancion(int _id, string _nombre, string _banda)
        {
            this._id = _id;
            this._nombre = _nombre;
            this._banda = _banda;
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
