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
    
    public partial class integrantes
    {
        public int PK_integrantes { get; set; }
        public string nombreInt { get; set; }
        public int FK_BANDAS_INTEGRANTES { get; set; }
        public int FK_INTEGRANTES_BANDAS { get; set; }
    
        public virtual bandas bandas { get; set; }
    }
}
