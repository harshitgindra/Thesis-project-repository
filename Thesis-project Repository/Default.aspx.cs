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

        //Needs to be implement.
        protected void SendSMS()
        {

        }

        protected void SignUp(object sender, EventArgs e)
        {
            DatabaseMethods asd = new DatabaseMethods();

            //Generating random string for email verification
            string randomString = Path.GetRandomFileName();
            randomString = randomString.Replace(".", "");

            //This method is not parametrized. We need to chage it to paramaterized.

            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            //Query for login table
            string queryString1 = "INSERT INTO LOGININFO (USERNAME, PASSWORD, ACCTYPE, RDM_STR, ADMIN_APPROVAL) VALUES ( '"
                + signUpUsername.Text + "','"
                + signUpPassword.Text + "','"
                + accType.Text + "','"
                + randomString + "','N');";
            //query for userinfo table
            string queryString2 = "Insert into USERINFO(FIRSTNAME, LASTNAME, username, emailid, SECQUES, SECANS)  values ('"
                + fname.Text + "','"
                + lname.Text + "','"
                + signUpUsername.Text + "','"
                + signUpEmail.Text + "','"
                + secques.Text + "','"
                + secans.Text + "');";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command1 = new SqlCommand(queryString1, connection);
                SqlCommand command2 = new SqlCommand(queryString2, connection);
                try
                {
                    connection.Open();
                    int check = command1.ExecuteNonQuery() + command2.ExecuteNonQuery();
                    if (check == 2)
                    {

                        if (email.sendEmail(signUpEmail.Text, "Welcome", emailBody(randomString)))
                        {
                            Response.Write("Mail Successfully Sent. Please Check your inbox.");
                        }
                        else
                        {
                            Response.Write("Something went wrong. Retry");
                        }
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
           + "<a href='http://localhost:60443/VerificationLink.aspx?verify=" + rdmString + "' >Click Here</a>"
           + "<h3>Thank you</h3>";
            return message;
        }

        protected void forgotpassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {

            string acctype = "";

            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";

            //Query for login table
            string queryString1 = "SELECT * FROM LOGININFO WHERE USERNAME = @username AND PASSWORD = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@username", loginusername.Text);
                command.Parameters.AddWithValue("@password", loginPassword.Text);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        //checking for admin login
                        if (!reader.GetString(2).Equals("A"))
                        {
                            //Checking for email verification
                            if (!reader.GetString(3).Equals(""))
                            {
                                accstatus.Text = "Email not verified. Please verify the account.";
                            }
                            //checking for admin approval
                            else if (reader.GetString(4).Equals("N"))
                            {
                                accstatus.Text = "Admin has not approved your account.";
                            }
                            //satisfied email and admin approval
                            //now redirect to appropriate page
                            else
                            {
                                accstatus.Text = "Successful login";
                                acctype = reader.GetString(2);
                                if (acctype.Equals("P"))
                                {

                                    Response.Redirect("/ProfessorFiles/ProfessorHome.aspx", false);
                                }
                                else
                                {

                                    Response.Redirect("/StudentFiles/StudentHomePage.aspx", false);
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("/Admin/AdminHomePage.aspx", false);
                        }
                        Session["username"] = loginusername.Text;
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

        protected Boolean sendEmail(string receiver, string subject, string message)
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