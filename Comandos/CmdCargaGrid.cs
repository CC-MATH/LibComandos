using System;
using System.Collections.Generic;
using System.Text;



namespace Libreria
{
    public class CmdCargarGrid : Comando
    {
        private System.Web.UI.WebControls.GridView gridview1;

       
        public CmdCargarGrid(System.Web.UI.WebControls.GridView gridview1, TABLAS tabla)
        {
            this.gridview1 = gridview1;
            TABLAS = tabla;
           
        }
        public override void execute()
        {
            try
            {
                TABLAS.set_nameBD(new BaseDatosSQL(name_bd));
                if (TABLAS.dsGrid().Tables.Count != 0)
                    gridview1.DataSource = TABLAS.dsGrid();
                else
                    gridview1.DataSource = null;
                gridview1.DataBind();
                
                
            }
            catch(Exception ex)
            {
                base.mandarExcepcion(ex);
            }
        }
    }
}
