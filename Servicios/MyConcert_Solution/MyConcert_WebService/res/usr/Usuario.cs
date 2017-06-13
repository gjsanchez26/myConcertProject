using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.res.usr
{
    public class Usuario
    {
        private string username;
        private string nombre;
        private string apellido;
        private string contrasena;
        private string correo;
        private DateTime fechaInscripcion;
        private string foto;
        private DateTime fechaNacimiento;
        private string telefono;
        private string ubicacion;
        private string descripcion;
        private int FK_USUARIOS_ESTADOS;
        private int FK_USUARIOS_PAISES;
        private int FK_USUARIOS_UNIVERSIDADES;
        private int FK_USUARIOS_TIPOSUSUARIOS;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return contrasena;
            }

            set
            {
                contrasena = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public DateTime FechaInscripcion
        {
            get
            {
                return fechaInscripcion;
            }

            set
            {
                fechaInscripcion = value;
            }
        }

        public string Foto
        {
            get
            {
                return foto;
            }

            set
            {
                foto = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Ubicacion
        {
            get
            {
                return ubicacion;
            }

            set
            {
                ubicacion = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public int FK_USUARIOS_ESTADOS1
        {
            get
            {
                return FK_USUARIOS_ESTADOS;
            }

            set
            {
                FK_USUARIOS_ESTADOS = value;
            }
        }

        public int FK_USUARIOS_PAISES1
        {
            get
            {
                return FK_USUARIOS_PAISES;
            }

            set
            {
                FK_USUARIOS_PAISES = value;
            }
        }

        public int FK_USUARIOS_UNIVERSIDADES1
        {
            get
            {
                return FK_USUARIOS_UNIVERSIDADES;
            }

            set
            {
                FK_USUARIOS_UNIVERSIDADES = value;
            }
        }

        public int FK_USUARIOS_TIPOSUSUARIOS1
        {
            get
            {
                return FK_USUARIOS_TIPOSUSUARIOS;
            }

            set
            {
                FK_USUARIOS_TIPOSUSUARIOS = value;
            }
        }
    }
}
