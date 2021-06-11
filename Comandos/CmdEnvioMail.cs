
namespace Libreria
{
    public class CmdEnvioMail : Comando
    {

        private string remitente;
        private string destinatario;
        private string asunto;
        private string texto;
        private string usuario;
        private string password;
        private string ip_host;

        public CmdEnvioMail(string remitente,string destinatario,string asunto, string texto)
        {
            ServidorMail= new ServidorMail();
            this.remitente = remitente;
            this.destinatario = destinatario;
            this.asunto = asunto;
            this.texto = texto;
            this.usuario = "";
            this.password = "";
            this.ip_host = "";
             
        }
        public CmdEnvioMail(string remitente, string destinatario, string asunto, string texto,string usuario,string password, string ip_host)
        {
            ServidorMail = new ServidorMail();
            this.remitente = remitente;
            this.destinatario = destinatario;
            this.asunto = asunto;
            this.texto = texto;
            this.usuario = usuario;
            this.password = password;
            this.ip_host = ip_host;

        }

        public CmdEnvioMail(System.Web.UI.Page pagina, string remitente, string destinatario, string asunto, string texto)
        {
            ServidorMail = new ServidorMail();
            this.remitente = remitente;
            this.destinatario = destinatario;
            this.asunto = asunto;
            this.texto = texto;
            Mensaje = new Mensaje(pagina);
            this.usuario = "";
            this.password = "";
            this.ip_host = "";

        }

        public override void execute()
        {
            ServidorMail.Mail = new Mail();
            ServidorMail.Mail.usarHtml(true);
            ServidorMail.Mail.crear(remitente, destinatario, asunto, texto);
            /*if (ip_host == "")
                error = ServidorMail.enviar();
            else
                error = ServidorMail.enviar(usuario, password, ip_host);*/
            //Mensaje.show_MensajeAlerta(asunto);
            if (error == 0)
            {
                //Mensaje.show_MensajeAlerta("Mensaje enviado");
            }
            else 
            {
                //Mensaje.show_MensajeAlerta("El mail no pudo ser enviado");
            }
        }
    }
}
