using System;

namespace MyConcert_WebService.objects
{
    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contrasena;
        private string _email;
        private string _estado;
        private DateTime _fechaInscripcion;
        private string _fotoPerfil;
        private string _tipoUsuario;

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

        public string Contrasena
        {
            get
            {
                return _contrasena;
            }

            set
            {
                _contrasena = value;
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

        public string TipoUsuario { get => _tipoUsuario; set => _tipoUsuario = value; }
    }
}
