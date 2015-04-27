using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thesis_project_Repository.Admin
{
    public partial class AdminDashBoard : System.Web.UI.Page
    {
        //var ComboChartBarGroups = 5;    //max bars to display

        private const string ConnectionString =
          "Data Source=itksqlexp8;Initial Catalog=it485project;MultipleActiveResultSets=true;"
          + "Integrated Security=true";
        public string fileNamefromDB = "";
        public string fileNamefromDBForBars = "";
        public string dataForBars = "";
        public string countFromDB = "";
        public string dateFromDB = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            const string countString = "SELECT count(*) FROM dashboard;";
            Int32 count = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(countString, connection);

                try
                {
                    connection.Open();
                    count = (Int32)command.ExecuteScalar();


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

            string[] documentName = new string[count];
            int[] downloadCount = new int[count];
            string[] uploadedDates = new string[count];


            System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
            KnownColor[] allColors = new KnownColor[colorsArray.Length];
            Array.Copy(colorsArray, allColors, colorsArray.Length);

            using (var connection = new SqlConnection(ConnectionString))
            {
                string query2 = "select TOP 2 * from dashboard;";
                var command1 = new SqlCommand(query2, connection);
                try
                {
                    connection.Open();
                    var reader = command1.ExecuteReader();
                    var _cntr = 0;
                    while (reader.Read())
                    {
                        documentName[_cntr] = reader["filename"].ToString();
                        downloadCount[_cntr] = Convert.ToInt32(reader["count"]);
                        uploadedDates[_cntr] = reader["date_uploaded"].ToString();
                        _cntr++;
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

            for (int i = 0; i < count; i++)
            {
                fileNamefromDB += "{ name: '" + documentName[i] + "' , y: " + downloadCount[i] +
                    ", color: '" + allColors[(i + 1) * 10] + "' },";
                fileNamefromDBForBars += "'" + documentName[i] + "', ";
                dataForBars += "{ type: 'column', name: '" + documentName[i] + "', data: [" + downloadCount[i] +
                    "]},";
            }
            fileNamefromDB = fileNamefromDB.Substring(0, fileNamefromDB.Length - 1);
            fileNamefromDBForBars = fileNamefromDBForBars.Substring(0, fileNamefromDBForBars.Length - 2);
            dataForBars = dataForBars.Substring(0, dataForBars.Length - 1);
        }
    }
}

