using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Web.Utils
{
    public class EmailSender
    {
        public EmailSender()
        {
        }

        public static Dictionary<bool, string> EnviarEmail(string destinatario, string usuario, string senha)
        {
            try
            {
                SmtpClient cliente = new SmtpClient();
                cliente.Host = ConfigurationManager.AppSettings["HostSmtpEmail"];
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailRemetente"], ConfigurationManager.AppSettings["SenhaEmailRemetente"]);

                MailMessage mensagem = new MailMessage();
                mensagem.Sender = new MailAddress(ConfigurationManager.AppSettings["EmailRemetente"]);
                mensagem.From = new MailAddress(ConfigurationManager.AppSettings["EmailRemetente"]);
                mensagem.To.Add(new MailAddress(destinatario));
                mensagem.Subject = "Recuperação de senha - Fellipe Krein web";

                string corpoMensagem = "Segue abaixo os dados solicitados\n\n";
                corpoMensagem += "Usuário: " + usuario + "\n";
                corpoMensagem += "Senha: " + senha + "\n\n";
                corpoMensagem += "Atenciosamente,";
                corpoMensagem += "Equipe Fellipe Krein;";

                mensagem.Body = corpoMensagem;
                mensagem.IsBodyHtml = false;
                mensagem.Priority = MailPriority.High;

                cliente.Send(mensagem);

                Dictionary<bool, string> dicionario = new Dictionary<bool, string>();
                dicionario.Add(true, "Email enviado com sucesso!");
                return dicionario;
            }
            catch(Exception e)
            {
                Dictionary<bool, string> dicionario = new Dictionary<bool, string>();
                dicionario.Add(false, e.Message);
                return dicionario;
            }
        }
    }
}