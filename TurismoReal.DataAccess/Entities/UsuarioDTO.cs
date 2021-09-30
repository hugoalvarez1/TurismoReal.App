using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.DataAccess.Entities
{
   public class UsuarioDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public System.DateTime reg_date { get; set; }
        public System.DateTime updation_date { get; set; }

    }
}
