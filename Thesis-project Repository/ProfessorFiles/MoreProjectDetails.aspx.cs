using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.ProfessorFiles
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string username = "";
        int profCommentsColumnNo = 0;
        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                                + "Integrated Security=true";
        string studentusername = "";
        string reporttype = "";
        string profrole = "";
        string profcomments = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["username"].ToString();
            studentusername = Request.QueryString["studentid"];
            string reptype = Request.QueryString["reptype"];
            //
            if (reptype.Equals("P"))
            {
                displayPreliminaryDetails();
                reporttype = "P";
            }
            else if (reptype.Equals("F"))
            {
                displayFinalReportDetails();
                reporttype = "F";
            }
            else if (reptype.Equals("T"))
            {
                displayThesisReportDetails();
                reporttype = "T";
            }
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }

        }



        protected void displayPreliminaryDetails()
        {
            const string query = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE USERNAME = @studentusername";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@studentusername", studentusername);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        stdusername.Text = reader.GetString(0);
                        projecttitle.Text = reader.GetString(1);
                        LiveLink.Text = reader.GetString(3);
                        projectabstract.Text = reader.GetString(5);
                        if (username.Equals(reader.GetString(12)))
                        {
                            //the user is a committee chair
                            profrole = "COMMITTEE_CHAIR";
                            profcomments = "COMMITTEE_CHAIR_COMMENTS";
                            profCommentsColumnNo = 14;
                            if (!reader.IsDBNull(13))
                            {
                                approvalstatus.Text = reader.GetString(13);
                                comments.Text = reader.GetString(14);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }
                        }
                        else if (username.Equals(reader.GetString(15)))
                        {
                            //the user is a committee member
                            profrole = "COMMITTEE_MEMBERS";
                            profcomments = "COMMITTEE_MEMBER_COMMENTS";
                            profCommentsColumnNo = 17;
                            if (!reader.IsDBNull(16))
                            {
                                approvalstatus.Text = reader.GetString(16);
                                comments.Text = reader.GetString(17);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }
                        }
                        else
                        {
                            //the user is a committee Graduate advisor
                            profrole = "GRADUATE_ADVISOR";
                            profcomments = "GRADUATE_ADVISOR_COMMENTS";
                            profCommentsColumnNo = 20;
                            if (!reader.IsDBNull(19))
                            {
                                approvalstatus.Text = reader.GetString(19);
                                comments.Text = reader.GetString(20);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }
                        }
                        var reportName = reader.GetString(8);
                        var hyp = new HyperLink
                        {
                            ID = "hyp1",
                            NavigateUrl = "../DownloadFile.aspx?username=" + studentusername + "&file=P",
                            Text = reportName
                        };
                        downloadfile.Controls.Add(hyp);
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

        protected void displayFinalReportDetails()
        {
            const string query = "SELECT * FROM FINAL_PROJECT_PROPOSAL WHERE USERNAME = @studentusername";
            string query2 = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE USERNAME = @studentusername";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                var command2 = new SqlCommand(query2, connection);
                command.Parameters.AddWithValue("@studentusername", studentusername);
                command2.Parameters.AddWithValue("@studentusername", studentusername);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        stdusername.Text = reader.GetString(0);
                        if (username.Equals(reader.GetString(9)))
                        {
                            //the user is a committee chair    
                            profrole = "COMMITTEE_CHAIR";
                            profcomments = "COMMITTEE_CHAIR_COMMENTS";
                            profCommentsColumnNo = 11;
                            if (!reader.IsDBNull(10))
                            {
                                approvalstatus.Text = reader.GetString(10);
                                comments.Text = reader.GetString(11);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }

                        }
                        else if (username.Equals(reader.GetString(12)))
                        {
                            //the user is a committee member
                            profrole = "COMMITTEE_MEMBERS";
                            profcomments = "COMMITTEE_MEMBER_COMMENTS";
                            profCommentsColumnNo = 14;
                            if (!reader.IsDBNull(13))
                            {
                                approvalstatus.Text = reader.GetString(13);
                                comments.Text = reader.GetString(14);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }
                        }
                        else
                        {
                            //the user is a committee Graduate advisor
                            profrole = "GRADUATE_ADVISOR";
                            profcomments = "GRADUATE_ADVISOR_COMMENTS";
                            profCommentsColumnNo = 17;
                            if (!reader.IsDBNull(16))
                            {
                                approvalstatus.Text = reader.GetString(16);
                                comments.Text = reader.GetString(17);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }
                        }
                        var reportName = reader.GetString(3);
                        var hyp = new HyperLink
                        {
                            ID = "hyp1",
                            NavigateUrl = "../DownloadFile.aspx?username=" + studentusername + "&file=F",
                            Text = reportName
                        };
                        downloadfile.Controls.Add(hyp);
                    }
                    reader.Close();
                    var reader2 = command2.ExecuteReader();
                    if (reader2.Read())
                    {
                        projecttitle.Text = reader2.GetString(1);
                        LiveLink.Text = reader2.GetString(3);
                        projectabstract.Text = reader2.GetString(5);
                    }

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

        protected void displayThesisReportDetails()
        {
            const string query = "SELECT * FROM THESIS_SUBMISSION WHERE USERNAME = @studentusername";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@studentusername", studentusername);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        stdusername.Text = reader.GetString(0);
                        projecttitle.Text = reader.GetString(1);
                        LiveLink.Text = "No Live Link";
                        projectabstract.Text = reader.GetString(4);
                        if (username.Equals(reader.GetString(11)))
                        {
                            //the user is a committee chair
                            profrole = "COMMITTEE_CHAIR";
                            profcomments = "COMMITTEE_CHAIR_COMMENTS";
                            profCommentsColumnNo = 13;
                            if (!reader.IsDBNull(12))
                            {
                                approvalstatus.Text = reader.GetString(12);
                                comments.Text = reader.GetString(13);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }
                        }
                        if (username.Equals(reader.GetString(14)))
                        {
                            //the user is a committee member
                            profrole = "COMMITTEE_MEMBERS";
                            profcomments = "COMMITTEE_MEMBER_COMMENTS";
                            profCommentsColumnNo = 16;
                            if (!reader.IsDBNull(15))
                            {
                                approvalstatus.Text = reader.GetString(15);
                                comments.Text = reader.GetString(16);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }
                        }
                        else
                        {
                            //the user is a committee Department Chair
                            profrole = "DEPARTMENT_CHAIR";
                            profcomments = "DEPARTMENT_CHAIR_COMMENTS";
                            profCommentsColumnNo = 19;
                            if (!reader.IsDBNull(18))
                            {
                                approvalstatus.Text = reader.GetString(18);
                                comments.Text = reader.GetString(19);
                            }
                            else
                            {
                                approvalstatus.Text = "N";
                            }
                        }
                        var reportName = reader.GetString(8);
                        var hyp = new HyperLink
                        {
                            ID = "hyp1",
                            NavigateUrl = "../DownloadFile.aspx?username=" + studentusername + "&file=T",
                            Text = reportName
                        };
                        downloadfile.Controls.Add(hyp);
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

        protected void addComments_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            string query = "";
            if (reporttype.Equals("P"))
            {
                query = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE USERNAME = @stdusername";
            }
            else if (reporttype.Equals("F"))
            {
                query = "SELECT * FROM FINAL_PROJECT_PROPOSAL WHERE USERNAME = @stdusername";
            }
            else
            {
                query = "SELECT * FROM THESIS_SUBMISSION WHERE USERNAME = @stdusername";
            }

            fetchingCommentsFromDB(query);

        }

        protected void fetchingCommentsFromDB(string query)
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@stdusername", studentusername);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(profCommentsColumnNo))
                        {
                            addingcomments.Text = reader.GetString(profCommentsColumnNo);
                        }
                    }
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


        protected void grantapproval_Click(object sender, EventArgs e)
        {
            string query = "";

            string profApprovalColumnName = profcomments.Replace("COMMENTS", "APPROVAL");
            if (reporttype.Equals("P"))
            {

                query = "UPDATE PRELIMINARY_PROJECT_SUBMISSION SET " + profApprovalColumnName + "='Y' where USERNAME = @stdusername";
            }
            else if (reporttype.Equals("F"))
            {
                query = "UPDATE FINAL_PROJECT_PROPOSAL SET " + profApprovalColumnName + "='Y' where USERNAME = @stdusername";
            }
            else
            {
                query = "UPDATE THESIS_SUBMISSION SET " + profApprovalColumnName + "='Y' where USERNAME = @stdusername";
            }
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@stdusername", studentusername);
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        approvalstatusupdates.Text = "Account Approved";
                    }
                    else
                    {
                        approvalstatusupdates.Text = "Something went wrong. Retry";
                    }

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

        protected void savecomments_Click(object sender, EventArgs e)
        {
            string query = "";

            if (reporttype.Equals("P"))
            {
                query = "UPDATE PRELIMINARY_PROJECT_SUBMISSION SET " + profcomments + "=@profcomments where USERNAME = @stdusername";
            }
            else if (reporttype.Equals("F"))
            {
                query = "UPDATE FINAL_PROJECT_PROPOSAL SET " + profcomments + "=@profcomments where USERNAME = @stdusername";
            }
            else
            {
                query = "UPDATE THESIS_SUBMISSION SET " + profcomments + "=@profcomments where USERNAME = @stdusername";
            }
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@stdusername", studentusername);
                command.Parameters.AddWithValue("@profcomments", addingcomments.Text);
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        savecommentsupdates.Text = "Comments saved";
                    }
                    else
                    {
                        savecommentsupdates.Text = "Something went wrong. Retry";
                    }

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

        protected void goback_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}