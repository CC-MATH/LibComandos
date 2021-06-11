using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    public class CmdTABLASESelect : Comando
    {
        public CmdTABLASESelect(TABLAS expe)
        {
            TABLAS = expe;
        }

        public override void execute()
        {
            TABLAS.set_nameBD(new BaseDatosSQL(name_bd));
            error=TABLAS.obtenerDatos();
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
