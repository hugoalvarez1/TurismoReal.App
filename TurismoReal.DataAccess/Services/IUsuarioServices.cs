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
        /// <summary>
        /// Metodo para obtener una lista de todos los usuarios de DB
        /// </summary>
        /// <returns></returns>
        //BaseDTO<List<UsuarioDTO>> GetAllUsuario();
        /// <summary>
        /// Metodo para obtener si el registros existe en DB
        /// </summary>
        /// <param name="userFilter"></param>
        /// <returns></returns>
        BaseDTO<UsuarioDTO> GetUsuarioByCredenciales(UsuarioDTO userFilter);
    }
}
