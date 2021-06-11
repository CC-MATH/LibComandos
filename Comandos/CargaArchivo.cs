using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Libreria
{
    public class CargaArchivo : CargaArchivos
    {
        public CargaArchivo(System.Web.UI.WebControls.FileUpload fileUp, string carpeta):base(fileUp, carpeta)
        {       
    }

        public override void cargar_Archivo() {
            if ((fileUp.PostedFile != null) && (fileUp.PostedFile.ContentLength > 0))
            {
                bool size = valida_Size();
                bool ext = valida_Ext();
                if (size && ext)
                {
                    string SaveLocation = HttpContext.Current.Server.MapPath(carpeta) + "\\" + fn;
                    try
                    {
                        fileUp.PostedFile.SaveAs(SaveLocation);
                        mensaje = "El archivo se ha cargado.";
                        upload = true;
                    }
                    catch (Exception ex)
                    {
                        mensaje = ex.Message;
                        mensaje = "El archivo no puede ser cargado, favor de intentar más tarde.";

                    }
                }
                else
                {
                    if (size == false)
                    {
                        mensaje = "El tamaño del archivo es muy grande.";
                    }
                    else
                    {
                        if (ext == false)
                        {

                            mensaje = "El archivo debe ser de tipo: " + listaExt.ToArray().ToString().Split(',');
                        }

                    }
                }
            }
            else
            {
                mensaje = "Seleccione un archivo que cargar.";
            }
        }
    }
}
