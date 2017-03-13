using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Collections.Generic;

namespace Framework.Util
{
    public class clsEmailUtil
    {

        /// <summary>
        /// Envia email. Este método necessita dos dados do servidor SMTP, como porta, 
        /// usuário remetente e senha remetente do email que está enviando a mensagem.
        /// </summary>
        /// <param name="emailDestinatario">Email do destinatário</param>
        /// <param name="emailRemetente">Email do remetente</param>
        /// <param name="assunto">Assunto do email</param>
        /// <param name="corpoEmail">Corpo do email</param>
        /// <param name="SmtpServer">Servidor SMTP</param>
        /// <param name="portaSmtp">Porta do Servidor SMTP</param>
        /// <param name="senhaEmailRemetente">Senha Email Remetente</param>
        /// <param name="prioridade">Prioridade: High(alta),Low(baixo) e Nomal</param>
        /// <param name="IsBodyHtml">IsBodyHtml: caso o corpo do email contenha HTML</param>
        /// <param name="anexos">Anexo do email. Não é obrigatório</param>
        /// <returns>true= email enviado, false= erro ao enviar</returns>
        public static bool SendEmail(string emailDestinatario, string emailRemetente, string assunto,
            string corpoEmail, string SmtpServer, int portaSmtp, string senhaEmailRemetente,
            MailPriority prioridade, bool IsBodyHtml, ArrayList anexos)
        {
            bool _ret = false;
            try
            {
                //Cria mensagem
                MailMessage mensagemEmail = new MailMessage(emailRemetente, emailDestinatario, assunto, corpoEmail);
                mensagemEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.Priority = prioridade;
                mensagemEmail.IsBodyHtml = IsBodyHtml;

                if (anexos != null)
                {
                    foreach (string anexo in anexos)
                    {
                        Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        mensagemEmail.Attachments.Add(anexado);
                    }
                }


                NetworkCredential _cred = new NetworkCredential(emailRemetente, senhaEmailRemetente);
                SmtpClient _client = new SmtpClient();
                _client.Host = SmtpServer;
                _client.Port = portaSmtp;
                _client.UseDefaultCredentials = false;
                _client.Credentials = _cred;
                _client.EnableSsl = true;

                //Envia mensagem
                _client.Send(mensagemEmail);
                _ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ret;
        }



        /// <summary>
        /// Método envio de email. Não utiliza informações de credenciais de um servidor SMTP.
        /// Só é necessário passar o servidor SMTP
        /// </summary>
        /// <param name="emailDestinatario">Email do destinatário</param>
        /// <param name="emailRemetente">Email do remetente</param>
        /// <param name="assunto">Assunto do email</param>
        /// <param name="corpoEmail">Corpo do email</param>
        /// <param name="SmtpServer">Servidor SMTP</param>
        /// <param name="prioridade">Prioridade: High(alta),Low(baixo) e Nomal</param>
        /// <param name="IsBodyHtml">IsBodyHtml: caso o corpo do email contenha HTML</param>
        /// <param name="anexos">Anexo do email. Não é obrigatório</param>
        /// <returns>true= email enviado, false= erro ao enviar</returns>
        public static bool SendEmail(string emailDestinatario, string emailRemetente, string assunto,
           string corpoEmail, string SmtpServer, MailPriority prioridade, bool IsBodyHtml,
            ArrayList anexos)
        {
            bool _ret = false;
            try
            {
                //Cria mensagem
                MailMessage mensagemEmail = new MailMessage(emailRemetente, emailDestinatario, assunto, corpoEmail);
                mensagemEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.Priority = prioridade;
                mensagemEmail.IsBodyHtml = IsBodyHtml;

                if (anexos != null)
                {
                    foreach (string anexo in anexos)
                    {
                        Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        mensagemEmail.Attachments.Add(anexado);
                    }
                }

                SmtpClient _client = new SmtpClient();
                _client.Host = SmtpServer;
                _client.UseDefaultCredentials = true;
                _client.EnableSsl = false;

                //Envia email
                _client.Send(mensagemEmail);
                _ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ret;
        }

        /// <summary>
        /// Método envio de email com anexos em Byte. Não utiliza informações de credenciais de um servidor SMTP.
        /// Só é necessário passar o servidor SMTP
        /// </summary>
        /// <param name="emailDestinatario">Email do destinatário</param>
        /// <param name="emailRemetente">Email do remetente</param>
        /// <param name="assunto">Assunto do email</param>
        /// <param name="corpoEmail">Corpo do email</param>
        /// <param name="SmtpServer">Servidor SMTP</param>
        /// <param name="prioridade">Prioridade: High(alta),Low(baixo) e Nomal</param>
        /// <param name="IsBodyHtml">IsBodyHtml: caso o corpo do email contenha HTML</param>
        /// <param name="anexos">Anexo do email. Não é obrigatório</param>
        /// <returns>true= email enviado, false= erro ao enviar</returns>
        public static bool SendEmailAnexoByte(string emailDestinatario, string emailRemetente, string assunto,
           string corpoEmail, string SmtpServer, MailPriority prioridade, bool IsBodyHtml, string nomeArquivo,
            ArrayList anexos)
        {
            bool _ret = false;
            try
            {
                //Cria mensagem
                MailMessage mensagemEmail = new MailMessage(emailRemetente, emailDestinatario, assunto, corpoEmail);
                mensagemEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.Priority = prioridade;
                mensagemEmail.IsBodyHtml = IsBodyHtml;

                if (anexos != null)
                {
                    foreach (string anexo in anexos)
                    {
                        string _fileName = nomeArquivo;
                        byte _bt = Convert.ToByte(anexo);
                        MemoryStream _ms = new MemoryStream(_bt);
                        Attachment anexado = new Attachment(_ms, _fileName);
                        mensagemEmail.Attachments.Add(anexado);
                    }
                }

                SmtpClient _client = new SmtpClient();
                _client.Host = SmtpServer;
                _client.UseDefaultCredentials = true;
                _client.EnableSsl = false;

                //Envia email
                _client.Send(mensagemEmail);
                _ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ret;
        }

        /// <summary>
        /// Método envio de email. Não é necessário definir credenciais, servidor ou porta (Usa configuracoes do IIS - Default SMTP Server [localhost]).
        /// </summary>
        /// <param name="emailDestinatario">Email do destinatário</param>
        /// <param name="emailRemetente">Email do remetente</param>
        /// <param name="assunto">Assunto do email</param>
        /// <param name="corpoEmail">Corpo do email</param>
        /// <param name="anexos">Array de Anexos</param>
        /// <returns></returns>
        public static bool SendMail(string emailDestinatario, string emailRemetente, string assunto, string corpoEmail, ArrayList anexos)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {

                message.To.Add(new MailAddress(emailDestinatario));
                message.From = new MailAddress(emailRemetente);


                message.Subject = assunto;
                message.Body = corpoEmail;
                message.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); //System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); //System.Text.Encoding.UTF8;

                if (anexos != null)
                {
                    foreach (string anexo in anexos)
                    {
                        Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        message.Attachments.Add(anexado);
                    }
                }

                SmtpClient client = new SmtpClient();
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método envio de email. Não é necessário definir credenciais, servidor ou porta (Usa configuracoes do IIS - Default SMTP Server [localhost]).
        /// </summary>
        /// <param name="emailDestinatario">Email do destinatário</param>
        /// <param name="emailRemetente">Email do remetente</param>
        /// <param name="assunto">Assunto do email</param>
        /// <param name="corpoEmail">Corpo do email</param>
        /// <returns></returns>
        public static bool SendMail(string emailDestinatario, string emailRemetente, string assunto, string corpoEmail)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {

                message.To.Add(new MailAddress(emailDestinatario));
                message.From = new MailAddress(emailRemetente);


                message.Subject = assunto;
                message.Body = corpoEmail;
                message.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); //System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); //System.Text.Encoding.UTF8;


                SmtpClient client = new SmtpClient();

                client.Send(message);

                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }


        public static bool SendEmailAnexoBytePDF(string emailDestinatario, string emailRemetente, string assunto,
         string corpoEmail, string SmtpServer, MailPriority prioridade, bool IsBodyHtml, byte[] anexo,
            string nomeArquivo, string diretorioArquivo)
        {
            bool _ret = false;
            try
            {
                //Cria mensagem
                MailMessage mensagemEmail = new MailMessage(emailRemetente, emailDestinatario, assunto, corpoEmail);
                mensagemEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.Priority = prioridade;
                mensagemEmail.IsBodyHtml = IsBodyHtml;

                if (anexo != null)
                {
                    //Crio array com os dados
                    string _fileName = nomeArquivo;

                    //Inicializa o writer.    
                    FileStream fs = File.Create(HttpContext.Current.Server.MapPath("~\\" + diretorioArquivo + "\\" + _fileName ));
                    fs.Write(anexo, 0, anexo.Length);
                    fs.Close();

                    Attachment anexado = new Attachment(HttpContext.Current.Server.MapPath("~\\" + diretorioArquivo + "\\" + _fileName));
                    mensagemEmail.Attachments.Add(anexado);
                }

                SmtpClient _client = new SmtpClient();
                _client.Host = SmtpServer;
                _client.UseDefaultCredentials = true;
                _client.EnableSsl = false;

                //Envia email
                _client.Send(mensagemEmail);
                _ret = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ret;
        }



        public static bool SendEmailAnexoBytePDF(string emailDestinatario, string emailRemetente, string assunto,
       string corpoEmail, string SmtpServer, MailPriority prioridade, bool IsBodyHtml, List<byte[]> lsitAnexo,
       string nomeArquivo, string diretorioArquivo)
        {
            bool _ret = false;
            try
            {
                //Cria mensagem
                MailMessage mensagemEmail = new MailMessage(emailRemetente, emailDestinatario, assunto, corpoEmail);
                mensagemEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.Priority = prioridade;
                mensagemEmail.IsBodyHtml = IsBodyHtml;

                if (lsitAnexo != null)
                {

                    foreach (var anexo in lsitAnexo)
                    {
                        //Crio array com os dados
                        string _fileName = nomeArquivo;

                        //Inicializa o writer.    
                        FileStream fs = File.Create(HttpContext.Current.Server.MapPath("~\\" + diretorioArquivo + "\\" + _fileName ));
                        fs.Write(anexo, 0, anexo.Length);
                        fs.Close();
                        Attachment anexado = new Attachment(HttpContext.Current.Server.MapPath("~\\" + diretorioArquivo + "\\" + _fileName ));
                        mensagemEmail.Attachments.Add(anexado);
                    }
                }

                SmtpClient _client = new SmtpClient();
                _client.Host = SmtpServer;
                _client.UseDefaultCredentials = true;
                _client.EnableSsl = false;

                //Envia email
                _client.Send(mensagemEmail);
                _ret = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ret;
        }

        /// <summary>
        /// Envio de e-mail para vários destinatários.
        /// </summary>
        /// <param name="destinatarios">Lista de destinatários.</param>
        /// <param name="emailRemetente">Remetente</param>
        /// <param name="assunto">Assunto do e-mail</param>
        /// <param name="corpoEmail">Conteúdo do e-mail.</param>
        /// <param name="SmtpServer">Servidor SMTP para envio.</param>
        /// <param name="prioridade">Prioridade do e-mail</param>
        /// <param name="IsBodyHtml">Se o conteúdo é Html ou Texto.</param>
        /// <param name="UsaSSL">Informa se utiliza o SSL.</param>
        /// <param name="anexos">Array de anexos.</param>
        /// <returns></returns>
        public static bool SendMail(MailAddressCollection destinatarios, MailAddress emailRemetente, string assunto,
              string corpoEmail, string SmtpServer, MailPriority prioridade, bool IsBodyHtml, bool UsaSSL, ArrayList anexos)
        {
            bool _ret = false;

            try
            {
                // Objeto mensagem.
                MailMessage mensagemEmail = new MailMessage();
                // Atribuição do remetente.
                mensagemEmail.From = emailRemetente;
                // Atribuição dos destinatários.
                foreach (MailAddress destinatario in destinatarios)
                    mensagemEmail.To.Add(destinatario);

                // Assunto do e-mail.
                mensagemEmail.Subject = assunto;
                // Corpo do e-mail.
                mensagemEmail.Body = corpoEmail;
                // Encoding utilizado.
                mensagemEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                // Prioridade do e-mail.
                mensagemEmail.Priority = prioridade;
                // Formato de exibição do e-mail.
                mensagemEmail.IsBodyHtml = IsBodyHtml;

                // Array com os anexos do e-mail.
                if (anexos != null)
                {
                    foreach (string anexo in anexos)
                    {
                        Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        mensagemEmail.Attachments.Add(anexado);
                    }
                }
                // Objeto de conexão com o servidor SMTP.
                SmtpClient _client = new SmtpClient();
                // Servidor.
                _client.Host = SmtpServer;
                // Uso de credenciais para autenticação.
                _client.UseDefaultCredentials = true;
                // SSL desabilitado.
                _client.EnableSsl = UsaSSL;
                // Envio da mensagem.
                _client.Send(mensagemEmail);

                _ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ret;
        }




        /// <summary>
        /// Envio de e-mail para vários destinatários.
        /// </summary>
        /// <param name="destinatarios">Lista de destinatários.</param>
        /// <param name="emailRemetente">Remetente</param>
        /// <param name="assunto">Assunto do e-mail</param>
        /// <param name="corpoEmail">Conteúdo do e-mail.</param>
        /// <param name="SmtpServer">Servidor SMTP para envio.</param>
        /// <param name="prioridade">Prioridade do e-mail</param>
        /// <param name="IsBodyHtml">Se o conteúdo é Html ou Texto.</param>
        /// <param name="UsaSSL">Informa se utiliza o SSL.</param>
        /// <param name="anexos">Array de anexos.</param>
        /// <returns></returns>
        public static bool SendMailAnexoPdf(MailAddressCollection destinatarios, MailAddress emailRemetente, string assunto,
              string corpoEmail, string SmtpServer, MailPriority prioridade, bool IsBodyHtml,
            bool UsaSSL, MemoryStream anexoEmail, string nomeArquivo)
        {
            bool _ret = false;

            try
            {
                // Objeto mensagem.
                MailMessage mensagemEmail = new MailMessage();
                // Atribuição do remetente.
                mensagemEmail.From = emailRemetente;
                // Atribuição dos destinatários.
                foreach (MailAddress destinatario in destinatarios)
                    mensagemEmail.To.Add(destinatario);

                // Assunto do e-mail.
                mensagemEmail.Subject = assunto;
                // Corpo do e-mail.
                mensagemEmail.Body = corpoEmail;
                // Encoding utilizado.
                mensagemEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                // Prioridade do e-mail.
                mensagemEmail.Priority = prioridade;
                // Formato de exibição do e-mail.
                mensagemEmail.IsBodyHtml = IsBodyHtml;

                // Array com os anexos do e-mail.
                if (anexoEmail.Length > 0)
                {
                    Attachment anexado = new Attachment(anexoEmail, nomeArquivo + ".pdf");
                    mensagemEmail.Attachments.Add(anexado);
                }

                // Objeto de conexão com o servidor SMTP.
                SmtpClient _client = new SmtpClient();
                // Servidor.
                _client.Host = SmtpServer;
                // Uso de credenciais para autenticação.
                _client.UseDefaultCredentials = true;
                // SSL desabilitado.
                _client.EnableSsl = UsaSSL;
                // Envio da mensagem.
                _client.Send(mensagemEmail);

                _ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListTo"></param>
        /// <param name="From"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="IsBodyHtml">Indica se o corpo do e-mail está em Html</param>
        /// <returns></returns>
        public static bool SendMail(List<string> ListTo, string From, string Subject, string Message, bool IsBodyHtml)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                //Vários Destinatários
                foreach (string _elem in ListTo)
                {
                    message.To.Add(new MailAddress(_elem));
                }

                message.From = new MailAddress(From);

                // Attachment attachment = new Attachment(FileUpload1.PostedFile.FileName);
                message.Subject = Subject;
                message.IsBodyHtml = IsBodyHtml;
                message.Body = Message;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                //message.Attachments.Add(attachment);

                SmtpClient client = new SmtpClient();

                client.Send(message);

                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Sends Mail from SMTP Default Server - Use web.config to set Server and Port or use the function parameters. 
        /// Only parameters "To", "From", "Subject" and "Message" are necessary, others are optional.
        /// </summary>
        /// <param name="ListTo">list of e-mail addresses to send to</param>
        /// <param name="From">e-mail address of the sender</param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="AttachmentFileName"></param>
        /// <returns></returns>
        public static bool SendMail(List<string> ListTo, string From, string Subject, string Message, string AttachmentFileName)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                foreach (string _elem in ListTo)
                    message.To.Add(new MailAddress(_elem));

                message.From = new MailAddress(From);

                Attachment attachment = new Attachment(AttachmentFileName);
                message.Subject = Subject;
                message.Body = Message;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Attachments.Add(attachment);

                SmtpClient client = new SmtpClient();

                client.Send(message);

                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SendMailAnexoPdf(MailAddressCollection destinatarios, MailAddress emailRemetente, string assunto,
             string corpoEmail, string SmtpServer, MailPriority prioridade, bool IsBodyHtml,
           bool UsaSSL, List<MemoryStream> listAnexoEmail, List<string> ListNomeArquivo, int porta)
        {
            bool _ret = false;

            try
            {
                // Objeto mensagem.
                MailMessage mensagemEmail = new MailMessage();
                // Atribuição do remetente.
                mensagemEmail.From = emailRemetente;
                // Atribuição dos destinatários.
                foreach (MailAddress destinatario in destinatarios)
                    mensagemEmail.To.Add(destinatario);

                // Assunto do e-mail.
                mensagemEmail.Subject = assunto;
                // Corpo do e-mail.
                mensagemEmail.Body = corpoEmail;
                // Encoding utilizado.
                mensagemEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mensagemEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                // Prioridade do e-mail.
                mensagemEmail.Priority = prioridade;
                // Formato de exibição do e-mail.
                mensagemEmail.IsBodyHtml = IsBodyHtml;

                for (int i = 0; i < listAnexoEmail.Count; i++)
                {
                    // Array com os anexos do e-mail.
                    if (listAnexoEmail.Count > 0)
                    {
                        Attachment anexado = new Attachment(listAnexoEmail[i], ListNomeArquivo[i] + ".pdf");
                        mensagemEmail.Attachments.Add(anexado);
                    }
                }

                // Objeto de conexão com o servidor SMTP.
                SmtpClient _client = new SmtpClient();
                // Servidor.
                _client.Host = SmtpServer;
                // Uso de credenciais para autenticação.
                _client.UseDefaultCredentials = true;
                // SSL desabilitado.
                _client.EnableSsl = UsaSSL;

                // Porta..
                _client.Port = porta;

                // Envio da mensagem.
                _client.Send(mensagemEmail);

                _ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ret;
        }

        /// <summary>
        /// Envia e-mail com header como imagem, com alternativa de envio como texto
        /// </summary>
        /// <param name="ListTo">Lista de Destinatarios</param>
        /// <param name="From">Remetente</param>
        /// <param name="Subject">Assunto</param>
        /// <param name="HtmlMessage">Mensagem (em html). No local da imagem deve haver uma tag <img src='cid:{0}'/></param>
        /// <param name="JpegLogoFileName">Caminho e nome do arquivo jpeg a ser exibido</param>
        /// <example>Exemplo de mensagem html:
        ///   <p>Lorum Ipsum Blah Blah</p>
        ///   <img src='cid:{0}' />
        ///   <p>Lorum Ipsum Blah Blah</p></example>
        /// <returns></returns>
        public static bool SendMailHtml(List<string> ListTo, string From, string Subject, string HtmlMessage, string JpegLogoFileName)
        {

            try
            {
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();

                foreach (string _elem in ListTo)
                    message.To.Add(new MailAddress(_elem));

                message.From = new MailAddress(From);

                LinkedResource inlineLogo = new LinkedResource(JpegLogoFileName, MediaTypeNames.Image.Jpeg);
                inlineLogo.ContentId = Guid.NewGuid().ToString();

                //substitui o nome do arquivo imagen em <img src='cid:{0}' />
                string body = string.Format(HtmlMessage, inlineLogo.ContentId);

                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

                avHtml.LinkedResources.Add(inlineLogo);
                message.AlternateViews.Add(avHtml);

                //Attachment att = new Attachment(JpegLogoFileName);
                //att.ContentDisposition.Inline = true;
                //message.Attachments.Add(att);

                message.Subject = Subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                smtpClient.Send(message);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
