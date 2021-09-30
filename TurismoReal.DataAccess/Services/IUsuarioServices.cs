using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DataAccess.Entities;

namespace TurismoReal.DataAccess.Services
{
    public interface IUsuarioServices
    {
        List<UsuarioDTO> GetAllUsuario();

    }
}
