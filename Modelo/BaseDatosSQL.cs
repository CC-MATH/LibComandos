//Fecha: 21 de julio de 2010

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace Libreria
{
    public class BaseDatosSQL : BaseDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        Comando cmd;
        string remitente = ConfigurationManager.AppSettings["Admin1_mail"];
        string destinos = ConfigurationManager.AppSettings["Admin1_mail"];

        public BaseDatosSQL(string name_bd) { 
            cadena = ConfigurationManager.ConnectionStrings[name_bd].ConnectionString;
            //cadena2 = ConfigurationManager.ConnectionStrings.
            conexion = new SqlConnection(cadena);
            
        }

        //Crea los parámetros del procedimiento
        //Parámetros
        //name_sp: nombre del procedimiento almacenado
        //name_paramS: recibe una lista de nombre de parámetros de tipo String
        //paramS: Recibe una lista del valor de los parámetros de tipo String
        private void crear_Parametros(string name_sp, List<string> name_paramS, List<string> paramS) {

            comando = new SqlCommand(name_sp, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < name_paramS.Count; i++)
            {
                comando.Parameters.AddWithValue(name_paramS[i], paramS[i]);
            }
        }

        //Crea los parámetros del procedimiento
        //Parámetros
        //name_sp: nombre del procedimiento almacenado
        private void crear_Parametros(string name_sp)
        {

            comando = new SqlCommand(name_sp, conexion);
            comando.CommandType = CommandType.StoredProcedure;

        }

         //Ejecuta procedimiento almacenado con un parámetro de salida VARCHAR
        //Regresa 0 si fue exitosa la ejecución
        //Regresa 1 si hubo error en la ejecución

        public override int execute_storedProcedure(String name_sp)
        {
            try
            {
                comando = new SqlCommand(name_sp, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                comando.CommandTimeout = 5000;
                comando.ExecuteNonQuery();
                return 0; //Regresa 0, fue exitoso

            }
            catch (SqlException ex)
            {
                set_errorMessage(ex.ErrorCode.ToString() + " " + ex.Message);
                cmd = new CmdEnvioMail(remitente, destinos, "Error", ex.Message);
                cmd.execute();
            }
            finally
            {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
            return 1; //Hubo erro

        }

        //Ejecuta procedimiento almacenado con un parámetro de salida VARCHAR
        //Parámetros
        //name_sp: nombre del procedimiento almacenado
        //name_paramS: recibe una lista de nombre de parámetros de tipo String
        //paramS: Recibe una lista del valor de los parámetros de tipo String
        //paramOutput: Recibe el nombre del parámetro de salida
        //Regresa 0 si fue exitosa la ejecución
        //Regresa 1 si hubo error en la ejecución

        public override int execute_storedProcedure(String name_sp, List<string> name_paramS, List<string> paramS,String paramOutput, int paramOutput_size)
        {
            try
            {
                crear_Parametros(name_sp, name_paramS, paramS);

                SqlParameter pOutput = new SqlParameter(paramOutput, SqlDbType.VarChar, paramOutput_size);
                pOutput.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pOutput);

                conexion.Open();
                comando.CommandTimeout = 5000;

                comando.ExecuteNonQuery();
                set_paramOutput(comando.Parameters[paramOutput].Value.ToString());
                return 0; //Regresa 0, fue exitoso

            }
            catch (SqlException ex)
            {
                set_errorMessage(ex.ErrorCode.ToString() + " " + ex.Message);
                cmd = new CmdEnvioMail(remitente, destinos, "Error", ex.Message);
                cmd.execute();
            }
            finally {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
            return  1; //Hubo error
        }

        //Ejecuta procedimiento almacenado con un parámetro de salida ENTERO
        //Parámetros
        //name_sp: nombre del procedimiento almacenado
        //name_paramS: recibe una lista de nombre de parámetros de tipo String
        //paramS: Recibe una lista del valor de los parámetros de tipo String
        //paramOutput: Recibe el nombre del parámetro de salida
        //Regresa 0 si fue exitosa la ejecución
        //Regresa 1 si hubo error en la ejecución

        public override int execute_storedProcedure(String name_sp, List<string> name_paramS, List<string> paramS, String paramOutput)
        {
            try
            {
                crear_Parametros(name_sp, name_paramS, paramS);

                SqlParameter pOutput = new SqlParameter(paramOutput, SqlDbType.Int);
                pOutput.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pOutput);

                conexion.Open();
                comando.CommandTimeout = 5000;

                comando.ExecuteNonQuery();
                set_paramOutput(comando.Parameters[paramOutput].Value.ToString());
                return 0; //Regresa 0, fue exitoso

            }
            catch (SqlException ex)
            {
                set_errorMessage(ex.ErrorCode.ToString() + " " + ex.Message);
                cmd = new CmdEnvioMail(remitente, destinos, "Error", ex.Message);
                cmd.execute();
            }
            finally
            {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
            return 1; //Hubo error
        }


        //Ejecuta procedimiento almacenado
        //Parámetros
        //name_sp: nombre del procedimiento almacenado
        //name_paramS: recibe una lista de nombre de parámetros de tipo String
        //paramS: Recibe una lista del valor de los parámetros de tipo String
        //Regresa 0 si fue exitosa la ejecución
        //Regresa 1 si hubo error en la ejecución
        public override int execute_storedProcedure(String name_sp, List<string> name_paramS, List<string> paramS)
        {
            try
            {
                crear_Parametros(name_sp, name_paramS, paramS);
               
                conexion.Open();
                comando.CommandTimeout = 5000;

                comando.ExecuteNonQuery();
                return 0; //Regresa 0, fue exitoso

            }
            catch (SqlException ex)
            {
                set_errorMessage(ex.ErrorCode.ToString() + " " + ex.Message);
                cmd = new CmdEnvioMail(remitente, destinos, "Error", ex.Message);
                cmd.execute();
            }
            finally
            {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
            return 1; //Hubo error
        }

        //Ejecuta procedimiento almacenado
        //Parámetros
        //name_sp: nombre del procedimiento almacenado
        //name_paramS: recibe una lista de nombre de parámetros de tipo String
        //paramS: Recibe una lista del valor de los parámetros de tipo String
        //paramImg: nombre de la imagen
        //imgSize: tamaño de la imagen
        //Regresa 0 si fue exitosa la ejecución
        //Regresa 1 si hubo error en la ejecución
        public override int execute_storedProcedure(String name_sp, List<string> name_paramS, List<string> paramS, string paramImg, byte[] imgSize)
        {
            try
            {
                crear_Parametros(name_sp, name_paramS, paramS);
                SqlParameter UploadedImage = new SqlParameter(paramImg, SqlDbType.Image, imgSize.Length);
                UploadedImage.Value = imgSize;
                comando.Parameters.Add(UploadedImage);
                conexion.Open();
                comando.CommandTimeout = 5000;

                comando.ExecuteNonQuery();
                return 0; //Regresa 0, fue exitoso

            }
            catch (SqlException ex)
            {
                set_errorMessage(ex.ErrorCode.ToString() + " " + ex.Message);
                cmd = new CmdEnvioMail(remitente, destinos, "Error", ex.Message);
                cmd.execute();
            }
            finally
            {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
            return 1; //Hubo error
        }

        //Ejecuta procedimiento almacenado y llena un DataSet
        //Parámetros
        //name_sp: nombre del procedimiento almacenado
        //name_paramS: recibe una lista de nombre de parámetros de tipo String
        //paramS: Recibe una lista del valor de los parámetros de tipo String
        public override int get_DataSet(String name_sp, List<string> name_paramS, List<string> paramS)
        {
            try
            {
                crear_Parametros(name_sp, name_paramS, paramS);

                conexion.Open();
                comando.CommandTimeout = 5000;

                SqlDataAdapter dataA = new SqlDataAdapter(comando);
                ds = new DataSet();
                dataA.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    ds = new DataSet(); 
                }
             
                return 0; //Regresa 0, fue exitoso

            }
            catch (SqlException ex)
            {
                set_errorMessage(ex.ErrorCode.ToString() + " " + ex.Message);
                cmd = new CmdEnvioMail(remitente, destinos, "Error", ex.Message);
                cmd.execute();
            }
            finally
            {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
            return 1; //Hubo error
        }

        public override int get_DataReader(String name_sp, List<string> name_paramS, List<string> paramS)
        {
            try
            {
                crear_Parametros(name_sp, name_paramS, paramS);

                conexion.Open();
                comando.CommandTimeout = 5000;

                sqldr = comando.ExecuteReader();
                return 0; //Regresa 0, fue exitoso

            }
            catch (SqlException ex)
            {
                set_errorMessage(ex.ErrorCode.ToString() + " " + ex.Message);
                cmd = new CmdEnvioMail(remitente, destinos, "Error", ex.Message);
                cmd.execute();
            }
            finally
            {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
            return 1; //Hubo error
        }


        //Ejecuta procedimiento almacenado y llena un DataSet
        //name_sp: nombre del procedimiento almacenado
        public override int get_DataSet(String name_sp)
        {
            try
            {
                crear_Parametros(name_sp);

                conexion.Open();
                comando.CommandTimeout = 5000;

                SqlDataAdapter dataA = new SqlDataAdapter(comando);
                ds = new DataSet();
                dataA.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    ds = new DataSet(); 
                }
                return 0; //Regresa 0, fue exitoso

            }
            catch (SqlException ex)
            {
                set_errorMessage(ex.ErrorCode.ToString() + " " + ex.Message);
                cmd = new CmdEnvioMail(remitente, destinos, "Error", ex.Message);
                cmd.execute();
            }
            finally
            {
                conexion.Close();
            
            }
            return 1; //Hubo error
        }
    }
}
