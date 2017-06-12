using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.viewModels
{
    class Fanatico : Usuario
    {
        private DateTime _fechaNacimiento;
        private string _telefono;
        private string _pais;
        private string _ubicacion;
        private string _descripcionPersonal;
        private string _universidad;

        public Fanatico(string nombre, string apellido, string nombreUsuario, 
                        string contrasena, string email, string estado, 
                        DateTime fechaInscripcion, string fotoPerfil, DateTime fechaNacimiento,
                        string telefono, string pais, string descripcionPersonal, string universidad,
                        string tipoUsuario, string ubicacion)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.Email = email;
            this.Estado = estado;
            this.FechaInscripcion = fechaInscripcion;
            this.FotoPerfil = fotoPerfil;
            this.FechaNacimiento = fechaNacimiento;
            this.Telefono = telefono;
            this.Pais = pais;
            this.DescripcionPersonal = descripcionPersonal;
            this.TipoUsuario = tipoUsuario;
            this.Universidad = universidad;
            this.Ubicacion = ubicacion;
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }

            set
            {
                _fechaNacimiento = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        internal string Pais
        {
            get
            {
                return _pais;
            }

            set
            {
                _pais = value;
            }
        }

        public string Ubicacion
        {
            get
            {
                return _ubicacion;
            }

            set
            {
                _ubicacion = value;
            }
        }

        public string DescripcionPersonal
        {
            get
            {
                return _descripcionPersonal;
            }

            set
            {
                _descripcionPersonal = value;
            }
        }

        public string Universidad
        {
            get
            {
                return _universidad;
            }

            set
            {
                _universidad = value;
            }
        }
    }
}
