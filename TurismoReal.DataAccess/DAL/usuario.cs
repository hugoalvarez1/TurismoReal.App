//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurismoReal.DataAccess.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        public int Id_Usuario { get; set; }
        public string Usuario1 { get; set; }
        public string Usuario_password { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
        public string Usuario_creacion { get; set; }
        public Nullable<bool> Vigente { get; set; }
        public Nullable<int> Id_rol { get; set; }
    
        public virtual rol rol { get; set; }
    }
}