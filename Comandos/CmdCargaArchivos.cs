// Itzel Morales Ramírez
//Fecha: 22 de julio de 2010

namespace Libreria
{
    public class CmdCargaArchivos : Comando
    {

        public CmdCargaArchivos(System.Web.UI.Page pagina, System.Web.UI.WebControls.FileUpload fileUp, string carpeta)
        {
            Mensaje = new Mensaje(pagina);
            CargaArchivos = new CargaArchivo(fileUp, carpeta);

        }

        public override void execute()
        {
            CargaArchivos.set_fileSize(5120);
            CargaArchivos.add_Extensiones("ppt");
            CargaArchivos.add_Extensiones("pptx");
            CargaArchivos.cargar_Archivo();
        }


    }
}
