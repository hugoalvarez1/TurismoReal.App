using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.DataAccess.Entities
{
    public class BaseDTO<T>
    {
        #region constructores
        public BaseDTO()
        {
            this.Error = null;            
            this.Error = null;
        }

        public BaseDTO(T Value)
        {
            this.HasError = false;
            this.Error = null;
            this.HasValue = (Value != null ? true : false);
            this.Value = Value;            
        }

        public BaseDTO(bool HasError, Exception Error)
        {
            this.HasError = HasError;
            this.Error = Error;
            this.HasValue = false;
            this.Value = default(T);            
        }               
        #endregion

        #region propiedades publicas
        public bool HasError
        {
            get;
            set;
        }

        public Exception Error
        {
            get;
            set;
        }

        public bool HasValue
        {
            get;
            set;
        }

        public T Value
        {
            get;
            set;
        }        
        #endregion
    }
}
