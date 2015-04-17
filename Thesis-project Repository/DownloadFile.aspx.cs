using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace Thesis_project_Repository
{
    public partial class DownloadFile : Page
    {
        private int fileLength;
        private string fileName = "";
        int fileLenghtColumnNo = 0;
        int fileNameColumnNo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = Request.QueryString["username"];
            var fileNameFromSearch = Request.QueryString["document_name"];
            var fileTypeFromSearch = fileNameFromSearch.Substring(0, 1);
            var type = "";
            type = Request.QueryString["file"];
            var fileToDownload = GetAFile(username, type, fileTypeFromSearch);
            Response.Clear();
            var ms = new MemoryStream(fileToDownload);
            var newFileName = fileName.Substring(1);
            Response.AddHeader("content-disposition", "attachment;filename=" + newFileName);
            Response.BinaryWrite(fileToDownload);
            Response.Flush();
            Response.End();
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "ClosePage", "window.close();", true);
        }

        public byte[] GetAFile(string username, string type, string fileTypeFromSearch)
        {
            var connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                   + "Integrated Security=true";
            var query = "";
            var query2 = "";

            if (type == "P" || fileTypeFromSearch.Equals("P"))
            {
                query = "SELECT document FROM PRELIMINARY_PROJECT_SUBMISSION "
                        + "WHERE username=@username";
                query2 = "SELECT * FROM PRELIMINARY_PROJECT_SUBMISSION WHERE username = @username";
                fileLenghtColumnNo = 7;
                fileNameColumnNo = 8;
            }
            else if (type == "F" || fileTypeFromSearch.Equals("F"))
            {
                query = "SELECT document FROM FINAL_PROJECT_PROPOSAL "
                        + "WHERE username=@username";
                query2 = "SELECT * FROM FINAL_PROJECT_PROPOSAL WHERE username = @username";
                fileLenghtColumnNo = 2;
                fileNameColumnNo = 3;
            }
            else if (type == "T" || fileTypeFromSearch.Equals("T"))
            {
                query = "SELECT document FROM THESIS_SUBMISSION "
                        + "WHERE username=@username";
                query2 = "SELECT * FROM THESIS_SUBMISSION WHERE username = @username";
                fileLenghtColumnNo = 6;
                fileNameColumnNo = 7;
            }
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(query, connection);
                var cmd2 = new SqlCommand(query2, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd2.Parameters.AddWithValue("@username", username);
                var z = cmd.ExecuteScalar() as byte[];
                var reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    fileLength = reader.GetInt32(fileLenghtColumnNo);
                    fileName = reader.GetString(fileNameColumnNo);
                }
                reader.Close();
                return z;
            }
        }
    }
}