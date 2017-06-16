using MyConcert.res.serial;
using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.viewModels
{
    class Colaborador : Usuario
    {
        public Colaborador(string nombre,
                        string apellido,
                        string nombreUsuario,
                        string contrasena,
                        string email,
                        string estado,
                        DateTime fechaInscripcion,
                        string tipoUsuario)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.Estado = estado;
            this.FechaInscripcion = fechaInscripcion;
            this.TipoUsuario = tipoUsuario;
            this.Email = email;
        }

        public Colaborador() { }

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Nombre = (string)json.name;
                this.Apellido = (string)json.last_name;
                this.NombreUsuario = (string)json.username;
                this.Contrasena = (string)json.password;
                this.Estado = "";
                this.FechaInscripcion = DateTime.Now;
                this.TipoUsuario = "";
                this.Email = (string)json.email;
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
    }
}
