using System;
using System.Collections.Generic;
using System.Data;
using System.Text;



namespace Libreria
{
    public class CmdCargaRadioBtnlist : Comando
    {
        private System.Web.UI.WebControls.RadioButtonList rbtnlist1;

       
        public CmdCargaRadioBtnlist(System.Web.UI.WebControls.RadioButtonList rbtnlist1, TABLAS tabla)
        {
            this.rbtnlist1 = rbtnlist1;
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
                    rbtnlist1.DataSource = dt;
                    rbtnlist1.DataValueField = dt.Columns["ID"].ColumnName.ToString();
                    rbtnlist1.DataTextField = dt.Columns["NOMBRE"].ColumnName.ToString();
                    rbtnlist1.DataBind();
                }
                else
                {
                    rbtnlist1.Items.Clear();
                    rbtnlist1.ClearSelection();

                }
                
            }
            catch(Exception ex)
            {
                base.mandarExcepcion(ex);
            }
        }
    }
}
