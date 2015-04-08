using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Thesis_project_Repository
{
    public class EmailClass
    {
        protected void abc()
        {
        }

        public Boolean sendEmail(string receiver, string subject, string message)
        {

            MailAddress messageFrom = new MailAddress("hgindra@ilstu.edu", "ITDepartment");
            //                    MailAddress messageTo = new MailAddress(to.Text);
            MailMessage emailMessage = new MailMessage();
            emailMessage.From = messageFrom;

            MailAddress messageTo = new MailAddress(receiver);
            emailMessage.To.Add(messageTo.Address);

            string messageSubject = subject;
            string messageBody = message;
            emailMessage.Subject = messageSubject;
            emailMessage.Body = messageBody;
            emailMessage.IsBodyHtml = true;
            //       SmtpClient mailClient = new SmtpClient();
            SmtpClient mailClient = new SmtpClient("smtp.ilstu.edu");
            // Credentials are necessary if the server requires the client 
            // to authenticate before it will send e-mail on the client's behalf.
            // Do this in the web.config file
            try
            {

                mailClient.UseDefaultCredentials = true;// false;
                mailClient.Send(emailMessage);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
            return true;
        }
    }
}