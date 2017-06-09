using System;

namespace MyConcert_WebService.objects
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
                        string fotoPerfil)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.Estado = estado;
            this.FechaInscripcion = fechaInscripcion;
            this.FotoPerfil = fotoPerfil;
        }
    }
}
