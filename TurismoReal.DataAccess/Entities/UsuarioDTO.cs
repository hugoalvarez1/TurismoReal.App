using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.DataAccess.Entities
{
   public class UsuarioDTO
    {
        public int Id_Usuario { get; set; }
        public string Usuario1 { get; set; }
        public string Usuario_password { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
        public string Usuario_creacion { get; set; }
        public Nullable<bool> Vigente { get; set; }
        public Nullable<int> Id_rol { get; set; }
        public string Descripcion_rol { get; set; }

    }
}
