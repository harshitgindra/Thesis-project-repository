using System;
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
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void loginButton_Click(object sender, EventArgs e)
        //{

        //    //verifying the login in credentials
        //    string connectionString = "Data Source=itksqlexp8;Initial Catalog=hgindraLoginInfo;"
        //                              + "Integrated Security=true";


        //    string queryString = "SELECT * from LoginInfo "
        //                + "WHERE username = @username "
        //                + "and password = @password";

        //    string user = userid.Text;
        //    string pwd = loginpassword.Text;
        //    //string tempOutStr = "";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {

        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Parameters.AddWithValue("@username", user);
        //        command.Parameters.AddWithValue("@password", pwd);

        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                Session["usernameid"] = user;
        //                Response.Redirect("EditProfileSession.aspx");
        //            }
        //            else
        //            {
        //                loginResult.Text = "<h2>Login Unsuccessful</h2>";
        //            }
        //            reader.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}
        //This is a demo.....
        protected void signUpSubmit_Click(object sender, EventArgs e)
        {
            //Generating random string for email verification
            string randomString = Path.GetRandomFileName();
            randomString = randomString.Replace(".", "");


            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            //Query for login table
            string queryString1 = "INSERT INTO LOGININFO VALUES ( '"
                + signUpUsername.Text + "','"
                + signUpPassword.Text + "','"
                + accType.Text + "','"
                + randomString + "');";
            //query for userinfo table
            string queryString2 = "Insert into USERINFO(username, emailid)  values ('"
                + signUpUsername.Text + "','"
                + signUpEmail.Text + "');";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command1 = new SqlCommand(queryString1, connection);
                SqlCommand command2 = new SqlCommand(queryString2, connection);
                try
                {
                    connection.Open();
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    if (sendEmail(signUpEmail.Text, "Welcome", emailBody(randomString)))
                    {
                        Response.Write("Successfull");
                    }
                    else
                    {
                        Response.Write("Unsuccessful");
                    }

                }
                catch (Exception ex)
                {
                    //in case of duplicate user id
                    usernameerror.Text = "Duplicate user id, Please retry";
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
           + "<a href='http://localhost:60443/VerificationLink.aspx?verify="+rdmString+"' >Click Here</a>"
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

        protected void forgotpassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}