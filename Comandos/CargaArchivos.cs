// Itzel Morales Ramírez
//Fecha: 21 de julio de 2010

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Libreria
{
    public abstract class CargaArchivos
    {
        protected System.Web.UI.WebControls.FileUpload fileUp;
        protected string carpeta="";
        public string mensaje="";
        protected List<string> listaExt;
        protected bool upload = false;
        protected int filesize=0;
        protected string fn="";

        public CargaArchivos(System.Web.UI.WebControls.FileUpload fileUp, string carpeta)
        {
            this.fileUp = fileUp;
            this.carpeta = carpeta;
            listaExt = new List<string>();
            this.fn = System.IO.Path.GetFileName(this.fileUp.PostedFile.FileName);
        }

        public abstract void cargar_Archivo();

        protected bool valida_Size()
        {

            if (fileUp.PostedFile.ContentLength < filesize * 1024)
            {
                return true; //Éxito
            }
            return false;
        }

        protected bool valida_Ext()
        {
            bool valida=false;
            string[] cadena = fileUp.FileName.Split('.');
            string extension = cadena[cadena.Length - 1];
            foreach (string ext in listaExt)
            {
                if (extension.ToLower() == ext.ToLower())
                {
                    valida= true; 
                }
            }
            return valida;//Es un archivo diferente a los permitidos
        }

        public void add_Extensiones(string ext) { 
           listaExt.Add(ext);
        }

        public void set_fileSize(int filesize) {
            this.filesize = filesize;
        }

        public bool is_upLoad() {
            return upload;
        }

        public string get_fileName() {
            return fn;
        }

    }
}
