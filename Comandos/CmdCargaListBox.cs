using System;
using System.Collections.Generic;
using System.Data;
using System.Text;



namespace Libreria
{
    public class CmdCargarListBox : Comando
    {
        private System.Web.UI.WebControls.ListBox listbox1;

       
        public CmdCargarListBox(System.Web.UI.WebControls.ListBox listbox1, TABLAS tabla)
        {
            this.listbox1 = listbox1;
            TABLAS = tabla;
           
        }
        public override void execute()
        {
            
            try
            {
                DataTable dt;
                TABLAS.set_nameBD(new BaseDatosSQL(name_bd));
                dt = TABLAS.dtDDL();
                if (dt != null)
                {
                    listbox1.DataSource = dt;
                    listbox1.DataValueField = dt.Columns["ID"].ColumnName.ToString();
                    listbox1.DataTextField = dt.Columns["NOMBRE"].ColumnName.ToString();
                    listbox1.DataBind();
                }
                else
                {
                    listbox1.Items.Clear();
                    listbox1.ClearSelection();

                }
                
            }
            catch(Exception ex)
            {
                base.mandarExcepcion(ex);
            }
        }
    }
}
