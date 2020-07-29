using System.IO;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

using aula4.Entidades;

namespace aula4.Output
{
    public class ExportarEmail : IExportar
    {
        public string NomeArquivo { get; set; }
        private string MailOrigem;
        private string MailSenha;
        private string MailDestino;
        private string MailAssunto;
        private string MailCorpo;

        public string RetornarNomeArquivo() => NomeArquivo;

        public void AtribuirNomeArquivo(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
        }
        public string RetornarMailOrigem() => MailOrigem;

        public void AtribuirMailOrigem(string mailOrigem)
        {
            MailOrigem = mailOrigem;
        }
        public string RetornarMailSenha() => MailSenha;

        public void AtribuirMailSenha(string mailSenha)
        {
            MailSenha = mailSenha;
        }
        public string RetornarMailDestino() => MailDestino;

        public void AtribuirMailDestino(string mailDestino)
        {
            MailDestino = mailDestino;
        }
        public string RetornarMailAssunto() => MailAssunto;

        public void AtribuirMailAssunto(string mailAssunto)
        {
            MailAssunto = mailAssunto;
        }
        public string RetornarMailCorpo() => MailCorpo;

        public void AtribuirMailCorpo(string mailCorpo)
        {
            MailCorpo = mailCorpo;
        }

        public ExportarEmail(string nomeArquivo, string[] emailDados)
        {
            AtribuirNomeArquivo(nomeArquivo);
            AtribuirMailOrigem(emailDados[0]);
            AtribuirMailSenha(emailDados[1]);
            AtribuirMailDestino(emailDados[2]);
            AtribuirMailAssunto(emailDados[3]);
            AtribuirMailCorpo(emailDados[4]);
        }
        public ExportarEmail(string nomeArquivo, string mailOrigem, string mailSenha, string mailDestino, string mailAssunto, string mailCorpo)
        {
            AtribuirNomeArquivo(nomeArquivo);
            AtribuirMailOrigem(mailOrigem);
            AtribuirMailSenha(mailSenha);
            AtribuirMailDestino(mailDestino);
            AtribuirMailAssunto(mailAssunto);
            AtribuirMailCorpo(mailCorpo);
        }

        public void Exportar(List<IExportarDados> dados)
        {
            MailMessage mail = new MailMessage(MailOrigem, MailDestino);
            mail.Subject = MailAssunto;
            mail.Body = MailCorpo;


            using (var file = new StreamWriter($"{NomeArquivo}.csv"))
            {
                foreach (var dado in dados)
                {
                    file.WriteLine(dado.ExportarCsv());
                }
            }

            mail.Attachments.Add(new Attachment($"{NomeArquivo}.csv"));

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Timeout = 10000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(MailOrigem, MailSenha);

            try
            {
                smtp.Send(mail);
            }
            catch
            {
                
            }
        }

    }
}