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

        public string Username { get => username; set => username = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Correo { get => correo; set => correo = value; }
        public DateTime FechaInscripcion { get => fechaInscripcion; set => fechaInscripcion = value; }
        public string Foto { get => foto; set => foto = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int FK_USUARIOS_ESTADOS1 { get => FK_USUARIOS_ESTADOS; set => FK_USUARIOS_ESTADOS = value; }
        public int FK_USUARIOS_PAISES1 { get => FK_USUARIOS_PAISES; set => FK_USUARIOS_PAISES = value; }
        public int FK_USUARIOS_UNIVERSIDADES1 { get => FK_USUARIOS_UNIVERSIDADES; set => FK_USUARIOS_UNIVERSIDADES = value; }
        public int FK_USUARIOS_TIPOSUSUARIOS1 { get => FK_USUARIOS_TIPOSUSUARIOS; set => FK_USUARIOS_TIPOSUSUARIOS = value; }
    }
}
