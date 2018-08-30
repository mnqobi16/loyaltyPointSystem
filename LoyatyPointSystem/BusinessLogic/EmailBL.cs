using LoyatyPointSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace LoyatyPointSystem.BusinessLogic
{
    public class EmailBL
    {
        public void Email(string subject, string body, string to, string fromdisplayname, string fromemail)
        {

            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(fromemail, fromdisplayname);

                msg.To.Add(to);
                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();

                int Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"].ToString());
                string Host = ConfigurationManager.AppSettings["Host"].ToString();

                smtp.Timeout = Timeout;
                smtp.Host = Host;

                string SendEmail = ConfigurationManager.AppSettings["SendEmail"].ToString();
                string UserName = ConfigurationManager.AppSettings["UserName"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();
                bool UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"].ToString());
                int Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
                bool EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"].ToString());

                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                smtp.UseDefaultCredentials = UseDefaultCredentials;
                NetworkCred.UserName = UserName;
                NetworkCred.Password = Password;
                //smtp.Credentials=new NetworkCredential(UserName, Password);
                smtp.Credentials = NetworkCred;
                smtp.Port = Port;
                smtp.EnableSsl = EnableSsl;

                smtp.EnableSsl = true;

                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(filepath);
                //msg.Attachments.Add(attachment);

                if (SendEmail == "true")
                {
                    try
                    {
                        smtp.Send(msg);

                        string v = msg.ToString();
                    }
                    catch (SmtpFailedRecipientException ex)
                    {
                        SmtpStatusCode statusCode = ex.StatusCode;

                        if (statusCode == SmtpStatusCode.MailboxBusy || statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
                        {
                            // wait 5 seconds, try a second time

                            Thread.Sleep(120000);
                            smtp.Send(msg);
                        }
                        else
                        {
                            throw;
                        }
                    }

                    finally
                    {
                        msg.Dispose();
                    }
                }
            }
            catch
            {

            }

        }
    }
}