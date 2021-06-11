using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Libreria
{
    public class Mail
    {
     
        public System.Net.Mail.MailMessage correo;

        public Mail() {
            this.correo = new System.Net.Mail.MailMessage();
            this.correo.IsBodyHtml = false;
            this.correo.Priority = System.Net.Mail.MailPriority.Normal;
        }

        
        public void crear(string De, string Para, string Asunto, string Texto) {

           
            string[] mail = Para.Split(';');

            this.correo.From = new System.Net.Mail.MailAddress(De);

            foreach (string _mail in mail){
                if (_mail != "") {
                    this.correo.To.Add(_mail);
                }
            }

            this.correo.Subject = Asunto;
            this.correo.Body = Texto;
        
        }

        public void usarHtml(Boolean bodyhtml) {

            this.correo.IsBodyHtml = bodyhtml;
        }

        public void prioridadMail(System.Net.Mail.MailPriority prioridad ) {

            this.correo.Priority = prioridad;
        }

    }
}
