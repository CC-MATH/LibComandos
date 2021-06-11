// Itzel Morales Ramírez
//Fecha: 21 de julio de 2010
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Libreria
{
    public class Mensaje
    {
        private System.Web.UI.Page pagina;
        public string errorMensaje;

        public Mensaje(System.Web.UI.Page pagina)
        {
            this.pagina = pagina;
        }

        public void show_MensajeAlerta(string msg)
        {
            try
            {
                string script = "<script language='JavaScript'>";
                script += "alert('";
                script += msg.Replace("'", "");
                script += "');</script>";

                if (!pagina.ClientScript.IsStartupScriptRegistered("Alerta"))
                {
                    pagina.ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script);
                }
            }

            catch (Exception ex)
            {
                errorMensaje = ex.Message;
            }
        }

        public void show_MensajeConfirmar(string evento,System.Web.UI.WebControls.Button boton,string msg,string funcion, string hConfirm)
        {
            try
            {
                string script = "<script language='JavaScript'>";
                script += " function " + funcion + "(){ ";
                script += " document.getElementById('" + hConfirm + "').value = ";
                script += " confirm('";
                script += msg.Replace("'", "");
                script += "'); return true }</script>";

                if (!pagina.ClientScript.IsClientScriptBlockRegistered(funcion))
                {
                    pagina.ClientScript.RegisterClientScriptBlock(typeof(Page), funcion, script);
                }
                boton.Attributes.Add(evento, "javascript:" + funcion + "();"); 
            }

            catch (Exception ex)
            {
                errorMensaje = ex.Message;
            }
        }

        public void show_MensajeConfirmar(string evento, System.Web.UI.WebControls.LinkButton boton, string msg, string funcion, string hConfirm)
        {
            try
            {
                string script = "<script language='JavaScript'>";
                script += " function " + funcion + "(){ ";
                script += " document.getElementById('" + hConfirm + "').value = ";
                script += " confirm('";
                script += msg.Replace("'", "");
                script += "'); return true }</script>";

                if (!pagina.ClientScript.IsClientScriptBlockRegistered(funcion))
                {
                    pagina.ClientScript.RegisterClientScriptBlock(typeof(Page), funcion, script);
                }
                boton.Attributes.Add(evento, "javascript:" + funcion + "();");
            }

            catch (Exception ex)
            {
                errorMensaje = ex.Message;
            }
        }
    }
}
