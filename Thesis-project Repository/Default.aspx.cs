using System;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Web.UI;
using Thesis_project_Repository.Modals;


namespace Thesis_project_Repository
{
    public partial class Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Needs to be implement.
        protected void SendSMS()
        {
        }

        protected void Login(object sender, EventArgs e)
        {
            var acctype = "";

            var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                   + "Integrated Security=true";

            //Query for login table
            var queryString1 = "SELECT * FROM LOGININFO WHERE USERNAME = @username AND PASSWORD = @password";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@username", loginUserName.Text);
                command.Parameters.AddWithValue("@password", loginPassword.Text);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        //checking for admin login
                        if (!reader.GetString(2).Equals("A"))
                        {
                            //Checking for email verification
                            if (!reader.GetString(3).Equals(""))
                            {
                                loginResult.Text = "Email not verified. Please verify the account.";
                            }
                            //checking for admin approval
                            else if (reader.GetString(4).Equals("N"))
                            {
                                loginResult.Text = "Admin has not approved your account.";
                            }
                            //satisfied email and admin approval
                            //now redirect to appropriate page
                            else
                            {
                                loginResult.Text = "Successful login";
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
                        Session["username"] = loginUserName.Text;
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

        protected void SignUp(object sender, EventArgs e)
        {
            var randomString = Path.GetRandomFileName();
            randomString = randomString.Replace(".", "");
            string username = signUpUsername.Text;
            string password = signUpPassword.Text;
            char accountType = Convert.ToChar(accType.SelectedValue);
            string adminApproval = "N";
            string secQuestion = secques.Text;
            string secAnswer = secans.Text;
            string firstName = fname.Text;
            string lastName = lname.Text;
            string phnNumber = phoneNumber.Text;
            string carrier = ntwrkprovider.SelectedValue;

            UserModels userinfoModels = new UserModels(username, password, accountType, randomString, adminApproval, secQuestion, secAnswer, firstName, lastName, phnNumber, carrier);

            DatabaseMethods databaseMethods = new DatabaseMethods();
            var result = databaseMethods.SignUp(userinfoModels);

            if (result == 2 || result == 5)
            {
                SignUpReply.Text = SendEmail(username, "Welcome", EmailBody(randomString)) ? "Thank you for sigining up. you will receive an email shortly Sent. Please Check your inbox." : "Something went wrong. Retry";
            }
            else
            {
                SignUpReply.Text = "Something went wrong while signing you up!!";
            }
        }

        protected string EmailBody(string rdmString)
        {
            var message = "<html> <img src=\"http://www.underconsideration.com/brandnew/archives/dropbox_logo_detail.png\" width=\"90\" height=\"90\" /> "
                          +
                          " <h2>Thank you for signing up. </h2> <br /><p>Please click on the link to verify the email id</p><br />"
                          + "<a href='http://localhost:60443/VerificationLink.aspx?verify=" + rdmString +
                          "' >Click Here</a>"
                          + "<h3>Thank you</h3>";
            return message;
        }
        protected Boolean SendEmail(string receiver, string subject, string message)
        {
            var messageFrom = new MailAddress("hgindra@ilstu.edu", "ITDepartment");
            //                    MailAddress messageTo = new MailAddress(to.Text);
            var emailMessage = new MailMessage {From = messageFrom};

            var messageTo = new MailAddress(receiver);
            emailMessage.To.Add(messageTo.Address);

            var messageSubject = subject;
            var messageBody = message;
            emailMessage.Subject = messageSubject;
            emailMessage.Body = messageBody;
            emailMessage.IsBodyHtml = true;
            //       SmtpClient mailClient = new SmtpClient();
            var mailClient = new SmtpClient("smtp.ilstu.edu");
            // Credentials are necessary if the server requires the client 
            // to authenticate before it will send e-mail on the client's behalf.
            // Do this in the web.config file
            try
            {
                mailClient.UseDefaultCredentials = true; // false;
                mailClient.Send(emailMessage);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
            return true;
        }

        protected void SignUpLink(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void ForgotPassword(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void LoginLink(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

    }
}