// Itzel Morales Ramírez
//Fecha: 21 de julio de 2010
using System.Configuration;

namespace Libreria
{
    public abstract class Comando
    {
        private Mensaje msg;
        private CargaArchivos cargaA;
        private Ventana popUp;
        private ServidorMail servmail;
        private BaseDatos bd;
        private TABLAS tabla;
        public int error;
        protected string name_bd = "DBMatsuriMaki";
    

        public Mensaje Mensaje
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }

        public CargaArchivos CargaArchivos
        {
            get
            {
                return cargaA;
            }
            set
            {
                cargaA = value;
            }
        }

        public Ventana Ventana
        {
            get
            {
                return popUp;
            }
            set
            {
                popUp = value;
            }
        }

        public ServidorMail ServidorMail
        {
            get
            {
                return servmail;
            }
            set
            {
                servmail = value;
            }
        }



        public BaseDatos BaseDatos
        {
            get
            {
                return bd;
            }
            set
            {
                bd = value;
            }
        }

        public TABLAS TABLAS
        {
            get
            {
                return tabla;
            }
            set
            {
                tabla = value;
            }
        }

       


                     
        public abstract void execute();

        protected void mandarExcepcion(System.Exception ex)
        {
            Comando cmd = new CmdEnvioMail(ConfigurationManager.AppSettings["Admin1_mail"] , ConfigurationManager.AppSettings["Admin1_mail"], "Error", ex.TargetSite + " " + ex.Source + " " + ex.Message);
            cmd.execute(); 
        }
    }
}
