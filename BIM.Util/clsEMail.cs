using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Text;

namespace ACE.Util
{
    /// <summary>
    /// Utility for sending SMTP e-Mail
    /// </summary>
    public static class clsEMail
    {
        /// <summary>
        /// Sends Mail from SMTP Default Server - Use web.config to set Server and Port or use the function parameters. 
        /// Only parameters "To", "From", "Subject" and "Message" are necessary, others are optional.
        /// </summary>
        /// <param name="To"></param>
        /// <param name="From"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="Server"></param>
        /// <param name="Port"></param>
        /// <param name="User"></param>
        /// <param name="Pwd"></param>
        /// <param name="Ssl"></param>
        /// <param name="defaultCredential"></param>
        /// <returns></returns>
        public static bool SendMail(string To, string From, string Subject, string Message, 
                             string Server, string Port, string User, string Pwd, bool Ssl, bool defaultCredential)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            NetworkCredential nc = null;

            try
            {

                message.To.Add(new MailAddress(To));
                message.From = new MailAddress(From);

                // Attachment attachment = new Attachment(FileUpload1.PostedFile.FileName);
                message.Subject = Subject;
                message.Body = Message;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                //message.Attachments.Add(attachment);

                SmtpClient client = new SmtpClient();

                /* definido no web.config */
                if (!string.IsNullOrEmpty(Port))
                    client.Port = Convert.ToInt32(Port); // Gmail works on this port

                if (!string.IsNullOrEmpty(Server))
                    client.Host = Server; // "smtp.gmail.com";

                if (!string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Pwd))
                    nc = new NetworkCredential(User, Pwd);

                if (nc != null)
                    client.Credentials = nc;

                client.EnableSsl = Ssl;
                client.UseDefaultCredentials = defaultCredential;


                client.Send(message);

                return true;


            }
            catch (Exception )
            {
                return false;
            }
        }



        /// <summary>
        /// Sends Mail from SMTP Default Server - Use web.config to set Server and Port or use the function parameters. 
        /// Only parameters "To", "From", "Subject" and "Message" are necessary, others are optional.
        /// </summary>
        /// <param name="To"></param>
        /// <param name="From"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="Server"></param>
        /// <param name="Port"></param>
        /// <param name="User"></param>
        /// <param name="Pwd"></param>
        /// <param name="Ssl"></param>
        /// <param name="defaultCredential"></param>
        /// <returns></returns>
        public static bool SendMail(List<string> ListTo, string From, string Subject, string Message,
                             string Server, string Port, string User, string Pwd, bool Ssl, bool defaultCredential)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            NetworkCredential nc = null;

            try
            {
                //Vários Destinatários
                foreach (string _elem in ListTo)
                    message.To.Add(new MailAddress(_elem));

                message.From = new MailAddress(From);

                // Attachment attachment = new Attachment(FileUpload1.PostedFile.FileName);
                message.Subject = Subject;
                message.Body = Message;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                //message.Attachments.Add(attachment);

                SmtpClient client = new SmtpClient();

                /* definido no web.config */
                if (!string.IsNullOrEmpty(Port))
                    client.Port = Convert.ToInt32(Port); // Gmail works on this port

                if (!string.IsNullOrEmpty(Server))
                    client.Host = Server; // "smtp.gmail.com";

                if (!string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Pwd))
                    nc = new NetworkCredential(User, Pwd);

                if (nc != null)
                    client.Credentials = nc;

                client.EnableSsl = Ssl;
                client.UseDefaultCredentials = defaultCredential;


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
        /// <param name="To"></param>
        /// <param name="From"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <example>clsEmail.SendMail("teste@mail.com", "me@mail.com", "Teste Mail", "This is a e-mail Test");</example>
        public static bool SendMail(string To, string From, string Subject, string Message)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            
            try
            {

                message.To.Add(new MailAddress(To));
                message.From = new MailAddress(From);

                // Attachment attachment = new Attachment(FileUpload1.PostedFile.FileName);
                message.Subject = Subject;
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
        /// <returns></returns>
        public static bool SendMail(List<string> ListTo, string From, string Subject, string Message)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                //Vários Destinatários
                foreach(string _elem in ListTo)
                {
                    message.To.Add(new MailAddress(_elem));
                }

                message.From = new MailAddress(From);

                // Attachment attachment = new Attachment(FileUpload1.PostedFile.FileName);
                message.Subject = Subject;
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
        /// 
        /// </summary>
        /// <param name="ListTo"></param>
        /// <param name="From"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="IsBodyHtml">Indica se o corpo do e-mail está em Html</param>
        /// <returns></returns>
        public static bool SendMail(List<string> ListTo, string From, string Subject, string Message, bool IsBodyHtml=true)
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
        /// <param name="To"></param>
        /// <param name="From"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="AttachmentFileName">Attachment Path (Full path and file name)</param>
        /// <example>clsEmail.SendMail("teste@mail.com", "me@mail.com", "Teste Mail", "This is a e-mail Test");</example>
        public static bool SendMail(string To, string From, string Subject, string Message, string AttachmentFileName)
        {

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {

                message.To.Add(new MailAddress(To));
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

        /// <summary>
        /// Gera Tabela Html de um DataTable
        /// http://stackoverflow.com/questions/9792882/creating-html-from-a-datatable-using-c-sharp
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>String</returns>
        public static string TableToHTML(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return "";

            StringBuilder builder = new StringBuilder();
            int iLine = 0;
            //builder.Append("<html>");
            //builder.Append("<head>");
            //builder.Append("<title>");
            //builder.Append("Page-");
            //builder.Append(Guid.NewGuid().ToString());
            //builder.Append("</title>");
            //builder.Append("</head>");
            //builder.Append("<body>");

            builder.Append("<table cellpadding='5' cellspacing='2' ");
            builder.Append("style='border: solid 1px 1px 1px 1px Silver; font-family:Courier New; font-size: x-small;'>");
            
            builder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn c in dt.Columns)
            {
                builder.Append("<th align='left' valign='top'><b>");
                builder.Append(c.ColumnName);
                builder.Append("</b></th>");
            }
            builder.Append("</tr>");

            foreach (DataRow r in dt.Rows)
            {
                iLine++;
                String bgColor = (iLine % 2 == 0 ? "#000000" : "#D8DCDC");
                builder.Append("<tr align='left' valign='top'>");
                foreach (DataColumn c in dt.Columns)
                {
                    builder.Append(String.Format("<td align='left' valign='top' backgroundcolor='{0}'>", bgColor));
                    builder.Append(r[c.ColumnName].ToString());
                    builder.Append("</td>");
                }
                builder.Append("</tr>");
            }
            builder.Append("</table>");
            //builder.Append("</body>");
            //builder.Append("</html>");

            return builder.ToString();
        }
    }
}
