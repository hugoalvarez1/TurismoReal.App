using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DataAccess.DAL;
using TurismoReal.DataAccess.Entities;
using TurismoReal.DataAccess.Services;

namespace TurismoReal.DataAccess.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        #region propiedades privadas 
        //instanciar propiedades 
        //db context se llama hostelentities
        private hostelEntities dbContext = null;
        private static UsuarioServices Instance = null;
        #endregion

        #region singleton 
        //contructor sun parametros
        private UsuarioServices()
        {
        }

        //metodo de instanciar la clase para mantener en memoria
        public static UsuarioServices GetInstance()
        {
            if (UsuarioServices.Instance == null)
                UsuarioServices.Instance = new UsuarioServices();

            return UsuarioServices.Instance;
        }
        #endregion

        //#region GetAllUsuario
        //// metodo obneter todos usuarios de la tabla login
        //public BaseDTO<List<UsuarioDTO>> GetAllUsuario()
        //{
        //    BaseDTO<List<UsuarioDTO>> lstUsuario = null;

        //    try
        //    {
        //        using (this.dbContext = new hostelEntities())
        //        {

        //            var lstResultado = (from us in this.dbContext.admin
        //                                select new UsuarioDTO

        //                                {
        //                                    id = us.id,
        //                                    username = us.username,
        //                                    email = us.email,
        //                                    password = us.password,
        //                                    reg_date = us.reg_date,
        //                                    updation_date = us.updation_date
        //                                }).ToList();

        //            lstUsuario = new BaseDTO<List<UsuarioDTO>>(lstResultado);


        //        }
        //    }
        //    catch (SqlException Sqlex)
        //    {
        //        lstUsuario = new BaseDTO<List<UsuarioDTO>>(true, new Exception("Error al intentar obtener listado de Usuarios desde DB", Sqlex));
        //    }
        //    catch (Exception ex)
        //    {
        //        lstUsuario = new BaseDTO<List<UsuarioDTO>>(true, new Exception("Error al intentar obtener listado de Usuarios desde DB", ex));
        //    }

        //    return lstUsuario;

        //}
        //#endregion

        #region GetUsuarioByCredenciales
        // metodo obneter todos usuarios de la tabla login
        public BaseDTO<UsuarioDTO> GetUsuarioByCredenciales(UsuarioDTO userFilter)
        {
            BaseDTO<UsuarioDTO> objUsuario = null;

            try
            {
                using (this.dbContext = new hostelEntities())
                {
                    var objResultado = (from us in this.dbContext.usuario
                                        join rl in this.dbContext.rol on us.Id_rol equals rl.Id_rol
                                        where us.Usuario1 == userFilter.Usuario1
                                        && us.Usuario_password == userFilter.Usuario_password
                                        && us.Vigente == true
                                        select new UsuarioDTO
                                        {
                                            Id_Usuario = us.Id_Usuario,
                                            Usuario1 = us.Usuario1,
                                            Usuario_creacion = us.Usuario_creacion,                                            
                                            Fecha_creacion = us.Fecha_creacion,
                                            Vigente = us.Vigente,
                                            Descripcion_rol = rl.Descripcion_rol
                                        }).FirstOrDefault();
                    //select
                    //        id,
                    //        username, 
                    //        email,                                             
                    //        reg_date,
                    //        updation_date
                    //from admin
                    //where usrname = 'admin'
                    //and password = 'Test@1234'

                    objUsuario = new BaseDTO<UsuarioDTO>(objResultado);
                }
            }
            catch (SqlException Sqlex)
            {
                objUsuario = new BaseDTO<UsuarioDTO>(true, new Exception("Error al intentar obtener Usuarios desde DB", Sqlex));
            }
            catch (Exception ex)
            {
                objUsuario = new BaseDTO<UsuarioDTO>(true, new Exception("Error al intentar obtener  de Usuarios desde DB", ex));
            }

            return objUsuario;

        }
        #endregion
    }
}
