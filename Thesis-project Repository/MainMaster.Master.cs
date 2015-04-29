using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Thesis_project_Repository.Models;
using Thesis_project_Repository.ServiceReference1;

namespace Thesis_project_Repository
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        private const string ConnectionString =
           "Data Source=itksqlexp8;Initial Catalog=it485project;MultipleActiveResultSets=true;"
           + "Integrated Security=true";

        private readonly DatabaseMethods _databaseMethods = new DatabaseMethods();
        protected void Page_Load(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(Request.QueryString["ia"]);

            if (page == 1)
            {
                MultiView1.ActiveViewIndex = 1;
            }
            else if (page == 2)
            {
                MultiView1.ActiveViewIndex = 2;
            }

        }

        protected void Login(object sender, EventArgs e)
        {
            const string queryString1 = "SELECT * FROM LOGININFO WHERE USERNAME = @username AND PASSWORD = @password;";

            using (var connection = new SqlConnection(ConnectionString))
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
                                loginResult.Text =
                                    "Admin has not approved your account yet. Please try after sometime. Sorry for the inconvinience.";
                            }
                            //satisfied email and admin approval
                            //now redirect to appropriate page
                            else
                            {
                                loginResult.Text = "Successful login";
                                var acctype = reader.GetString(2);
                                if (acctype.Equals("P"))
                                {
                                  //  Response.Redirect("ProfessorFiles/ProfessorHome.aspx", false);
                                   Response.Redirect("http://iis.it.ilstu.edu/485spr15/it4850105/App9/ProfessorFiles/ProfessorHome.aspx", false);
                                }
                                else if (acctype.Equals("S"))
                                {
                                   // Response.Redirect("StudentFiles/StudentHomePage.aspx", false);
                                    Response.Redirect("http://iis.it.ilstu.edu/485spr15/it4850105/App9/StudentFiles/StudentHomePage.aspx", false);
                                }
                                else if (acctype.Equals("V"))
                                {
                               //     Response.Redirect("Viewer/ViewerHome.aspx", false);
                                   Response.Redirect("http://iis.it.ilstu.edu/485spr15/it4850105/App9/Viewer/ViewerHome.aspx", false);
                                }
                            }
                        }
                        else
                        {
                            //What is the use of false here?
                            Response.Redirect("http://iis.it.ilstu.edu/485spr15/it4850105/App9/Admin/AdminHomePage.aspx", false);
                          //  Response.Redirect("Admin/AdminHomePage.aspx", false);
                        }
                        Session["username"] = loginUserName.Text;
                    }
                    else {
                        loginResult.Text = "Invalid Login!!";
                    }
                }
                catch (Exception ex)
                {
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
            var username = signUpUsername.Text;
            var password = signUpPassword.Text;
            var accountType = Convert.ToChar(accType.SelectedValue);
            const string adminApproval = "N";
            var secQuestion = secques.Text;
            var secAnswer = secans.Text;
            var firstName = fname.Text;
            var lastName = lname.Text;
            var phnNumber = phoneNumber.Text;
            var carrier = ntwrkprovider.SelectedValue;

            var userinfoModels = new UserModels(username, password, accountType, randomString, adminApproval,
                secQuestion, secAnswer, firstName, lastName, phnNumber, carrier);

            var result = _databaseMethods.SignUp(userinfoModels);

            if (result == 2 || result == 5)
            {
                SignUpReply.Text = SendEmail(username, "Welcome", EmailBody(randomString))
                    ? "Thank you for sigining up. you will receive an email shortly Sent. Please Check your inbox."
                    : "Something went wrong. Retry";
                var message = "Thank you for siging up with us!!";
                SendSms(carrier, phnNumber, message);
            }
            else
            {
                SignUpReply.Text = "Something went wrong while signing you up!!";
            }
        }

        protected string EmailBody(string rdmString)
        {
            var message = "<html> <img src=\"http://www.cwu.edu/~jacobsend/book-green.jpg\" width=\"90\" height=\"90\" /> "
                          +
                          " <h2>Thank you for signing up. </h2> <br /><p>Please click on the link to verify the email id</p><br />"
                          + "<a href='http://iis.it.ilstu.edu/485spr15/it4850105/App9/VerificationLink.aspx?verify=" + rdmString +
                          "' >Click Here</a>"
                          + "<h3>Thank you</h3>";
            return message;
        }
    //    http://iis.it.ilstu.edu/485spr15/it4850105/App3/VerificationLink.aspx?verify=
        protected string EmailBodyForChangePassword(string rdmString)
        {
            var message = "<html> <img src=\"http://www.cwu.edu/~jacobsend/book-green.jpg\" width=\"90\" height=\"90\" /> "
                          +
                          " <h2><p>Please click on the link to verify the email id</p></h2><br />"
                          + "<a href='http://iis.it.ilstu.edu/485spr15/it4850105/App9/ChangePassword.aspx?verify=" + rdmString +
                          "' >Click Here</a>"
                          + "<h3>Thank you</h3>";
            return message;
        }

        protected Boolean SendEmail(string receiver, string subject, string message)
        {
            var messageFrom = new MailAddress("hgindra@ilstu.edu", "ITDepartment");
            var emailMessage = new MailMessage { From = messageFrom };

            var messageTo = new MailAddress(receiver);
            emailMessage.To.Add(messageTo.Address);

            var messageSubject = subject;
            var messageBody = message;
            emailMessage.Subject = messageSubject;
            emailMessage.Body = messageBody;
            emailMessage.IsBodyHtml = true;
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

        //protected void SignUpLink(object sender, EventArgs e)
        //{
        //    CLearSignUpPage();
        //    Response.Redirect("Default.aspx?ia=2");
        //}

        //need to use this method
        protected void CLearSignUpPage()
        {
            signUpUsername.Text = "";
            signUpPassword.Text = "";
            signUpPassword2.Text = "";
            accType.SelectedIndex = -1;
            secques.Text = "";
            secans.Text = "";
            fname.Text = "";
            lname.Text = "";
            phoneNumber.Text = "";
            ntwrkprovider.SelectedIndex = 0;

        }
        protected void ForgotPassword(object sender, EventArgs e)
        {

            MultiView1.ActiveViewIndex = 3;
        }

        //protected void LoginLink(object sender, EventArgs e)
        //{
        //    //signUpUsername.Text = "a@a.com";
        //    //signUpPassword.Text = "aaaaa";
        //    //signUpPassword2.Text = "aaaaa";
        //    //accType.SelectedIndex = 1;
        //    //secques.Text = "aaaaa";
        //    //secans.Text = "aaaaa";
        //    //fname.Text = "aaaaa";
        //    //lname.Text = "aaaaa";
        //    //phoneNumber.Text = "123456789";
        //    //ntwrkprovider.SelectedIndex = 1;
        //    Response.Redirect("Default.aspx?ia=1");
        //    // MultiView1.ActiveViewIndex = 1;
        //}

        protected void SendSms(string provider, string number, string message)
        {
            var sms = new SUSMSClient();
            sms.sendSMS(provider, number, message);
        }

        protected void RetrieveForgotPassword(object sender, EventArgs e)
        {
            //    const string query = "SELECT * FROM logininfo WHERE username = @username;";
            var Carrier = "";
            var randomString = "";
            var query1 = "";
            using (var connection = new SqlConnection(ConnectionString))
            {
                if (FpAccntType.SelectedValue.Equals("S"))
                {
                    query1 =
                        "SELECT * FROM LOGININFO INNER JOIN STUDENTPROFILE ON LOGININFO.USERNAME = STUDENTPROFILE.USERNAME WHERE (LOGININFO.USERNAME = @username);";
                }
                else if (FpAccntType.SelectedValue.Equals("P"))
                {
                    query1 =
                        "SELECT * FROM LOGININFO INNER JOIN FACULTYPROFILE ON LOGININFO.USERNAME = FACULTYPROFILE.USERNAME WHERE (LOGININFO.USERNAME = @username);";
                }
                else if (FpAccntType.SelectedValue.Equals("V"))
                {
                    query1 =
                        "SELECT * FROM LOGININFO INNER JOIN VIEWERPROFILE ON LOGININFO.USERNAME = VIEWERPROFILE.USERNAME WHERE (LOGININFO.USERNAME = @username);";
                }
                var command0 = new SqlCommand(query1, connection);
                command0.Parameters.AddWithValue("@username", forgotEmailId.Text);
                try
                {
                    connection.Open();
                    var reader = command0.ExecuteReader();
                    if (reader.Read())
                    {
                        var usernameDb = reader.GetString(0);
                        var phnNumber = reader.GetString(10);
                        Carrier = reader.GetString(11);
                        randomString = Path.GetRandomFileName();
                        randomString = randomString.Replace(".", "");
                        _databaseMethods.UpdateLogininfordmstr(usernameDb, randomString);

                        if (retrievelMethodRadioList.SelectedValue.Equals("E"))
                        {
                            confirationMessage.Text = SendEmail(forgotEmailId.Text, "Retrieve Lost Password",
                                EmailBodyForChangePassword(randomString))
                                ? "Email Sent Successfully. Please check your inbox"
                                : "Something went wront. Please retry.";
                        }
                        else if (retrievelMethodRadioList.SelectedValue.Equals("M"))
                        {
                            var message = "Your Verification code is: " + randomString;
                            SendSms(Carrier, phnNumber, message);
                            UpdatePasswordFromSMSConfirmation.Text = "Verification code has been sent to your mobile.";

                            MultiView1.ActiveViewIndex = 4;
                        }
                    }
                    else
                    {
                        confirationMessage.Text = "Email Id not in DB";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void UpdatePasswordUsingSms(object sender, EventArgs e)
        {
            var randomString = VerificationCode.Text;
            var password = NewPassword.Text;
            var result = 0;
            var methods = new DatabaseMethods();
            if (string.IsNullOrEmpty(randomString) || string.IsNullOrWhiteSpace(randomString))
            {
                UpdatePasswordFromSMSConfirmation.Text = "Please write the verification code.";
            }
            else
            {
                result = methods.UpdatePasswordFromSms(randomString, password);
                if (result == 1)
                {
                    UpdatePasswordFromSMSConfirmation.Text = "Your password has been changed successfully";
                }
                else
                {
                    UpdatePasswordFromSMSConfirmation.Text = "Something went wrong. Please try again later.";
                }
            }
        }


        protected void checkUserNameAvailability(object sender, EventArgs e)
        {
            const string query = "SELECT * FROM LOGININFO WHERE USERNAME = @username";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", signUpUsername.Text);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        usernameerror.Text = "Username already taken.";
                        usernameerror.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        usernameerror.Text = "Username available";
                        usernameerror.ForeColor = System.Drawing.Color.Green;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}