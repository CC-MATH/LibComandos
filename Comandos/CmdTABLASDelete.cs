using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    public class CmdTABLASDelete : Comando
    {
        public CmdTABLASDelete(TABLAS tabla)
        {
            TABLAS = tabla;
        }

        public override void execute()
        {
            TABLAS.set_nameBD(new BaseDatosSQL(name_bd));
            error=TABLAS.eliminarDatos();
            if (error == 1)
            {
                //Hubo error al insertar
               
            }
            else
            {
                //Inserto correctamente
               
            }
        }
    }
}
