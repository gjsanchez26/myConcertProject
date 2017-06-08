using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.objects
{
    class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contraseña;
        private string _email;
        private bool _estado;
        private DateTime _fechaInscripcion;
        private string _fotoPerfil;

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

        public string Apellido
        {
            get
            {
                return _apellido;
            }

            set
            {
                _apellido = value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }

            set
            {
                _nombreUsuario = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return _contraseña;
            }

            set
            {
                _contraseña = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public bool Estado
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

        public DateTime FechaInscripcion
        {
            get
            {
                return _fechaInscripcion;
            }

            set
            {
                _fechaInscripcion = value;
            }
        }

        public string FotoPerfil
        {
            get
            {
                return _fotoPerfil;
            }

            set
            {
                _fotoPerfil = value;
            }
        }
    }
}
