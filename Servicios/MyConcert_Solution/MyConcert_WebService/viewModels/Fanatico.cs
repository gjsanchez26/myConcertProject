using MyConcert.resources.serial;
using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.viewModels
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

        public Fanatico() { }

        public bool deserialize(JObject pObject)
        {
            SerialHelper serial = new SerialHelper();
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Nombre = (string)json.name;
                this.Apellido = (string)json.last_name;
                this.NombreUsuario = (string)json.username;
                this.Contrasena = (string)json.password;
                this.Email = (string)json.email;
                this.Estado = "";
                this.FechaInscripcion = DateTime.Now;
                this.FotoPerfil = "";
                this.FechaNacimiento = (DateTime)json.birth_date;
                this.Telefono = (string)json.phone;
                this.Pais = (string)json.country;
                this.DescripcionPersonal = (string)json.description;
                this.TipoUsuario = "";
                this.Universidad = (string)json.university;
                this.Ubicacion = (string)json.ubication;
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
            Contrasena = "XXXXXXXX";
            return JObject.FromObject(this);
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

        public string Pais
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
