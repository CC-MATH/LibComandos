using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    public class CmdTABLASInsert : Comando
    {

        public CmdTABLASInsert(TABLAS expe)
        {
            TABLAS = expe;
        }

        public override void execute()
        {
            TABLAS.set_nameBD(new BaseDatosSQL(name_bd));
            error=TABLAS.insertarDatos();
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
