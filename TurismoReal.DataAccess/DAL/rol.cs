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
    
    public partial class rol
    {
        public rol()
        {
            this.usuario = new HashSet<usuario>();
        }
    
        public int Id_rol { get; set; }
        public string Descripcion_rol { get; set; }
    
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
