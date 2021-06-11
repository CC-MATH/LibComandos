using System;
using System.Collections.Generic;
using System.Data;
using System.Text;



namespace Libreria
{
    public class CmdCargaCheckBoxList : Comando
    {
        private System.Web.UI.WebControls.CheckBoxList checklistbox1;

       
        public CmdCargaCheckBoxList(System.Web.UI.WebControls.CheckBoxList checklistbox1, TABLAS tabla)
        {
            this.checklistbox1 = checklistbox1;
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
                    checklistbox1.DataSource = dt;
                    checklistbox1.DataValueField = dt.Columns["ID"].ColumnName.ToString();
                    checklistbox1.DataTextField = dt.Columns["NOMBRE"].ColumnName.ToString();
                    checklistbox1.DataBind();
                }
                else
                {
                    checklistbox1.Items.Clear();
                    checklistbox1.ClearSelection();

                }
                
            }
            catch(Exception ex)
            {
                base.mandarExcepcion(ex);
            }
        }
    }
}
