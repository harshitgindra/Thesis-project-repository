using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository
{
    public partial class DownloadFile : System.Web.UI.Page
    {

        int fileLength = 0;
        string fileName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.QueryString["username"];
            string type = Request.QueryString["file"];
            byte[] fileToDownload = GetAFile(username, type);
            Response.Clear();
            MemoryStream ms = new MemoryStream(fileToDownload);
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.BinaryWrite(fileToDownload);
            Response.Flush();
            Response.End();
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "ClosePage", "window.close();", true);
        }

        public byte[] GetAFile(string username, string type)
        {
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                      + "Integrated Security=true";
            string query = "";
            string query2 = "";

            if (type.Equals("P"))
            {
                query = "SELECT document FROM PRELIMINARY_PROJECT_SUBMISSION "
                            + "WHERE username=@username";
                query2 = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE username = @username";
            }
            else if (type.Equals("F"))
            {
                //project final
            }
            else
            {
                //thesis
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlCommand cmd2 = new SqlCommand(query2, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd2.Parameters.AddWithValue("@username", username);
                byte[] z = cmd.ExecuteScalar() as byte[];
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    fileLength = reader.GetInt32(7);
                    fileName = reader.GetString(8);
                }
                reader.Close();
                return z;
            }
        }
    }
}