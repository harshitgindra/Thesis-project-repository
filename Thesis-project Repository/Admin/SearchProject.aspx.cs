using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string ConnectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                                + "Integrated Security=true";
        JsonObjects jsonattributes = new JsonObjects();
        List<JsonObjects> j = new List<JsonObjects>();
        // List<string> users;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void jsonoutput_Click(object sender, EventArgs e)
        {
            //checking if there is any result generated
            if (OmniResults.Rows.Count == 0)
            {
                Response.Write("There are no tables to export. Please hit search and generate data.");
            }
            else
            {
                string query1 = " SELECT *  FROM PRELIMINARY_PROJECT_SUBMISSION "
            + " WHERE (USERNAME LIKE '%' + @search + '%') "
            + " OR (PROJECT_TITLE LIKE '%' + @search+ '%') "
            + " OR (KEYWORDS LIKE '%' + @search+ '%')"
            + " OR  (SEMESTER_COMPLETED LIKE '%' + @search+ '%')"
            + " OR  (DATE_UPLOADED LIKE '%' + @search+ '%');";

             //   string query2 = " SELECT *  FROM FINAL_PROJECT_PROPOSAL "
             //+ " WHERE (USERNAME LIKE '%' + @search + '%') "
             //+ " OR (PROJECT_TITLE LIKE '%' + @search+ '%') "
             //+ " OR (KEYWORDS LIKE '%' + @search+ '%')"
             //+ " OR  (SEMESTER_COMPLETED LIKE '%' + @search+ '%')"
             //+ " OR  (DATE_UPLOADED LIKE '%' + @search+ '%');";

                string query3 = " SELECT *  FROM THESIS_SUBMISSION "
            + " WHERE (USERNAME LIKE '%' + @search + '%') "
            + " OR (TITLE LIKE '%' + @search+ '%') "
            + " OR (KEYWORDS LIKE '%' + @search+ '%')"
            + " OR  (SEMESTER_COMPLETED LIKE '%' + @search+ '%')"
            + " OR  (DATE_UPLOADED LIKE '%' + @search+ '%');";

                fetchDataPreliminaryReports(query1);
                //fetchFinalReportDB(query2);
                fetchThesisReportsDB(query3);
                downloadJsonFile(JsonConvert.SerializeObject(j, Formatting.Indented));
            }
        }

        private void fetchDataPreliminaryReports(string query1)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query1, connection);

                command.Parameters.AddWithValue("@search", TextBox1.Text);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jsonattributes.username = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                            jsonattributes.projecttitle = reader.GetString(1);
                        if (!reader.IsDBNull(3))
                            jsonattributes.livelink = reader.GetString(3);
                        if (!reader.IsDBNull(2))
                            jsonattributes.courseno = reader.GetString(2);
                        if (!reader.IsDBNull(12))
                            jsonattributes.committee_chair = reader.GetString(12);
                        if (!reader.IsDBNull(15))
                            jsonattributes.committee_member = reader.GetString(15);
                        if (!reader.IsDBNull(18))
                            jsonattributes.graduateadvisor = reader.GetString(18);
                        jsonattributes.reporttype = "Preliminary Report";
                        if (!reader.IsDBNull(21))
                            jsonattributes.semester = reader.GetString(21);
                        j.Add(jsonattributes);
                        jsonattributes = new JsonObjects();
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

        protected void fetchFinalReportDB(string query)
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@search", TextBox1.Text);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jsonattributes.username = reader.GetString(0);
                        //jsonattributes.projecttitle = reader.GetString(1);
                        //jsonattributes.livelink = reader.GetString(3);
                        //jsonattributes.courseno = reader.GetString(2);
                        if (!reader.IsDBNull(9))
                            jsonattributes.committee_chair = reader.GetString(9);
                        if (!reader.IsDBNull(12))
                            jsonattributes.committee_member = reader.GetString(12);
                        if (!reader.IsDBNull(15))
                            jsonattributes.graduateadvisor = reader.GetString(15);
                        jsonattributes.reporttype = "Preliminary Report";
                        if (!reader.IsDBNull(7))
                            jsonattributes.semester = reader.GetString(7);
                        j.Add(jsonattributes);
                        jsonattributes = new JsonObjects();
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

        protected void fetchThesisReportsDB(string query)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@search", TextBox1.Text);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jsonattributes.username = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                            jsonattributes.projecttitle = reader.GetString(1);
                        //jsonattributes.livelink = reader.GetString(3);
                        if (!reader.IsDBNull(2))
                            jsonattributes.courseno = reader.GetString(2);
                        if (!reader.IsDBNull(11))
                            jsonattributes.committee_chair = reader.GetString(11);
                        if (!reader.IsDBNull(14))
                            jsonattributes.committee_member = reader.GetString(14);
                        if (!reader.IsDBNull(17))
                            jsonattributes.departmenthead = reader.GetString(17);
                        jsonattributes.reporttype = "Thesis";
                        if (!reader.IsDBNull(20))
                            jsonattributes.semester = reader.GetString(20);
                        j.Add(jsonattributes);
                        jsonattributes = new JsonObjects();
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

        protected void downloadJsonFile(string jsonmatter)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(jsonmatter);
            sb.Append("\r\n");
            string text = sb.ToString();
            Response.Clear();
            Response.ClearHeaders();

            Response.AddHeader("Content-Length", text.Length.ToString());
            Response.ContentType = "text/plain";
            Response.AppendHeader("content-disposition", "attachment;filename=\"Json.txt\"");

            Response.Write(text);
            Response.End();

        }
    }


}