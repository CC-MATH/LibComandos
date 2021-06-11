// Itzel Morales Ramírez
//Fecha: 21 de julio de 2010
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Libreria
{
    public abstract class BaseDatos
    {
        private String errorMessage;
        private String paramOutput;
        protected DataSet ds = null;
        protected SqlDataReader sqldr;
        protected String cadena = "";

        public abstract int execute_storedProcedure(String name_sp);
        public abstract int execute_storedProcedure(String name_sp, List<string> name_paramS, List<string> paramS, String paramOutput, int paramOutput_size);
        public abstract int execute_storedProcedure(String name_sp, List<string> name_paramS, List<string> paramS, String paramOutput);
        public abstract int execute_storedProcedure(String name_sp, List<string> name_paramS, List<string> paramS);
        public abstract int execute_storedProcedure(String name_sp, List<string> name_paramS, List<string> paramS, string paramImg, byte[] imgSize);
        public abstract int get_DataSet(String name_sp, List<string> name_paramS, List<string> paramS);
        public abstract int get_DataReader(String name_sp, List<string> name_paramS, List<string> paramS);
        public abstract int get_DataSet(String name_sp);

        public String get_errorMessage()
        {
            return errorMessage;
        }

        public void set_errorMessage(String errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        public String get_paramOutput()
        {
            return paramOutput;
        }
        public void set_paramOutput(String paramOutput)
        {
            this.paramOutput = paramOutput;
        }
        public DataSet get_ds() {
            return ds;
        }
        public SqlDataReader get_sqldr()
        {
            return sqldr;
        }
    }
}
