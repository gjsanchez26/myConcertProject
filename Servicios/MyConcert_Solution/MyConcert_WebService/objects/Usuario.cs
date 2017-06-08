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

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Email { get => _email; set => _email = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public DateTime FechaInscripcion { get => _fechaInscripcion; set => _fechaInscripcion = value; }
        public string FotoPerfil { get => _fotoPerfil; set => _fotoPerfil = value; }
    }
}
