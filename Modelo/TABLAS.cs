using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Libreria
{
    public abstract class TABLAS : ITABLAS
    {
        protected BaseDatos bd;
        public string ACCION;
        public string SP;
        public string EXTRA_SP;
       
        public TABLAS() { }

        public void set_nameBD(BaseDatos bd)
        {
            this.bd = bd;
        }

        public abstract int insertarDatos();
        public abstract int eliminarDatos();
        public abstract int actualizarDatos();
        public abstract int obtenerDatos();
      
        public String get_ErrorMessage()
        {
            return bd.get_errorMessage();
        }

        #region ITABLAS Members

        public abstract DataSet dsGrid();

        public abstract DataTable dtDDL();

        #endregion

  }

}
