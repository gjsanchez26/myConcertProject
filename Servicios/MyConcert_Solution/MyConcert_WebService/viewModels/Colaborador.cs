using Newtonsoft.Json.Linq;
using System;

namespace MyConcert_WebService.viewModels
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

        public bool deserialize(JObject pObject)
        {
            bool estado = true;
            dynamic json = pObject;
            try
            {
                this.Nombre = json.name;
                this.Apellido = json.last_name;
                this.NombreUsuario = json.username;
                this.Contrasena = json.password;
                this.Estado = json.state;
                this.FechaInscripcion = json.inscription_date;
                this.TipoUsuario = json.user_type;
                this.Email = json.email;
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
    }
}
