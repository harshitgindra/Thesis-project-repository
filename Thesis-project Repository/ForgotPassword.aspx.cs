﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            retrievepassword.ActiveViewIndex = 0;
        }

        protected void forgotpwdemail_Click(object sender, EventArgs e)
        {
            retrievepassword.ActiveViewIndex = 1;
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            string query = "SELECT * FROM USERINFO WHERE EMAILID = '" + forgotEmailId.Text + "';";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string username = reader.GetString(2);
                        string randomString = Path.GetRandomFileName();
                        randomString = randomString.Replace(".", "");
                        updateLogininfowtrdmstr(username, randomString);
                        if (sendEmail(forgotEmailId.Text, "Retrieve Lost Password", emailBody(randomString)))
                        {
                            confimationmsg.Text = "Email Sent Successfully. Please check your inbox";
                        }
                        else
                        {
                            confimationmsg.Text = "Something went wront. Please retry.";
                        }
                    }
                    else
                    {

                        confimationmsg.Text = "Email Id not in DB";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    //in case of duplicate user id
                    confimationmsg.Text = "something went wrong";
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private void updateLogininfowtrdmstr(string username, string randomstring)
        {
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            string query = "UPDATE LOGININFO SET RDM_STR = '" + randomstring + "' WHERE USERNAME = '" + username + "';";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    confimationmsg.Text = "something went wrong";
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        protected string emailBody(string rdmString)
        {
            string message = "<html> <img src=\"http://www.underconsideration.com/brandnew/archives/dropbox_logo_detail.png\" width=\"90\" height=\"90\" /> "
           + " <h2>Thank you for signing up. </h2> <br /><p>Please click on the link to verify the email id</p><br />"
           + "<a href='http://localhost:60443/VerificationLink.aspx?verify=" + rdmString + "' >Click Here</a>"
           + "<h3>Thank you</h3>";
            return message;
        }



        protected Boolean sendEmail(string receiver, string subject, string message)
        {

            MailAddress messageFrom = new MailAddress("hgindra@ilstu.edu", "Harshit Gindra");
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
                return false;
            }
            return true;
        }
    }
}