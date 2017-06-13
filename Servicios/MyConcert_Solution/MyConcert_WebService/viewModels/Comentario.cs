﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.viewModels
{
    class Comentario
    {
        private int _id;
        private string _fanatico;
        private DateTime _fecha;
        private string _contenido;
        private int _calificacion;
        private string _estado;
        private string _banda;

        public Comentario(int _id, string _fanatico, DateTime _fecha, string _contenido, int _calificacion, string _estado, string _banda)
        {
            this._id = _id;
            this._fanatico = _fanatico;
            this._fecha = _fecha;
            this._contenido = _contenido;
            this._calificacion = _calificacion;
            this._estado = _estado;
            this._banda = _banda;
        }

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Id = json.id;
                this.Fanatico = json.user;
                this.Fecha = json.date;
                this.Contenido = json.content;
                this.Calificacion = json.calification;
                this.Estado = json.state;
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

        public string Fanatico
        {
            get
            {
                return _fanatico;
            }

            set
            {
                _fanatico = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
            }
        }

        public string Contenido
        {
            get
            {
                return _contenido;
            }

            set
            {
                _contenido = value;
            }
        }

        public int Calificacion
        {
            get
            {
                return _calificacion;
            }

            set
            {
                _calificacion = value;
            }
        }

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
    }

   
}