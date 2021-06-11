using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    public class ServidorMail
    {
        private Mail mail;
        private System.Net.Mail.SmtpClient smtp;
        public string error;

        

        public ServidorMail() {

            smtp = new System.Net.Mail.SmtpClient();

        }

        public Mail Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }

        public int enviar() {
            string usr, pwd;
            usr = System.Configuration.ConfigurationManager.AppSettings["User"];
            pwd = System.Configuration.ConfigurationManager.AppSettings["password"];

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(usr, pwd);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = System.Configuration.ConfigurationManager.AppSettings["ip_host"];
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(Mail.correo);
                return 0; //Éxito
            }
            catch (Exception e)
            {
                error=e.Source + " " + e.Message;
            }
            return 1;//Error
        }
        public int enviar(string usuario,string password, string ip_host)
        {
            string usr, pwd;
            usr = usuario;
            pwd = password;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(usr, pwd);
            smtp.Port = 25;
            smtp.Host = ip_host;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(Mail.correo);
                return 0; //Éxito
            }
            catch (Exception e)
            {
                error = e.Source + " " + e.Message;
            }
            return 1;//Error
        }
    }
}
