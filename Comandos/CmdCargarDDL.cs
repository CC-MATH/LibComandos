using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libreria
{
    public class CmdCargarDDL : Comando
    {
        private System.Web.UI.WebControls.DropDownList ddl;
  

        public CmdCargarDDL(System.Web.UI.WebControls.DropDownList ddl, TABLAS tabla)
        {
            this.ddl = ddl;
            TABLAS = tabla;
        
        }

       
        public override void execute()
        {
            DataTable dt;
            DataRow fila;
            TABLAS.set_nameBD(new BaseDatosSQL(name_bd));
            dt = TABLAS.dtDDL();
            if (dt != null)
            {
                fila = dt.NewRow();
                fila["ID"] = "-1";
                fila["NOMBRE"] = "Elija";
                dt.Rows.InsertAt(fila, 0);
                ddl.DataSource = dt;
                ddl.DataTextField = dt.Columns["NOMBRE"].ColumnName.ToString();
                ddl.DataValueField = dt.Columns["ID"].ColumnName.ToString();
                ddl.DataBind();
                BindTooltip(ddl);
            }
        }

        private void BindTooltip(ControlCollection cc)
        {
            try
            {
                if (cc == null)
                    return;
                for (int i = 0; i < cc.Count; i++)
                {
                    try
                    {
                        Control c = cc[i];
                        if (c.HasControls())
                        {
                            BindTooltip(c.Controls);
                        }
                        else
                        {
                            if (c.GetType().IsSubclassOf(typeof(ListControl)))
                            {
                                ListControl lc = (ListControl)c;
                                BindTooltip(lc);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                base.mandarExcepcion(ex);
            }

        }

        private void BindTooltip(ListControl lc)
        {
            for (int i = 0; i < lc.Items.Count; i++)
            {
                lc.Items[i].Attributes.Add("title", lc.Items[i].Text);
            }
        }
      
    }
}
