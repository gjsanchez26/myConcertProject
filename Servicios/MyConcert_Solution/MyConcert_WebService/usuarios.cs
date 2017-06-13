//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyConcert_WebService
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            this.comentarios = new HashSet<comentarios>();
            this.generosusuario = new HashSet<generosusuario>();
            this.votos = new HashSet<votos>();
        }
    
        public string username { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contraseña { get; set; }
        public string correo { get; set; }
        public System.DateTime fechaInscripcion { get; set; }
        public string foto { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string telefono { get; set; }
        public string ubicacion { get; set; }
        public string descripcion { get; set; }
        public int FK_USUARIOS_ESTADOS { get; set; }
        public Nullable<int> FK_USUARIOS_PAISES { get; set; }
        public Nullable<int> FK_USUARIOS_UNIVERSIDADES { get; set; }
        public int FK_USUARIOS_TIPOSUSUARIOS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comentarios> comentarios { get; set; }
        public virtual estados estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<generosusuario> generosusuario { get; set; }
        public virtual paises paises { get; set; }
        public virtual tiposusuarios tiposusuarios { get; set; }
        public virtual universidades universidades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<votos> votos { get; set; }
    }
}
