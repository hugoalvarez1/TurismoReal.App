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

        // metodo obneter todos usuarios de la tabla login

        public List<UsuarioDTO> GetAllUsuario()
        {
            List<UsuarioDTO> lstUsuario = null;

            try
            {
                using (this.dbContext = new hostelEntities())
                {

                    var lstResultado = (from us in this.dbContext.admin
                                        select new UsuarioDTO

                                        {
                                            id = us.id,
                                            username = us.username,
                                            email = us.email,
                                            password = us.password,
                                            reg_date = us.reg_date,
                                            updation_date = us.updation_date
                                        }).ToList();

                    lstUsuario = new List<UsuarioDTO>(lstResultado);


                }

            }
            catch (SqlException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return lstUsuario;

        }





    }
}
