using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Thesis_project_Repository
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                div4.Visible = true;
                div5.Visible = false;
                DetailsView1.Visible = true;
                DetailsView2.Visible = true;
                TextBox2.Text = "";
                TextBox3.Text = "";
                Label5.Text = "";
                RadioButtonList1.ClearSelection();
                RadioButtonList2.ClearSelection();
                RadioButtonList3.ClearSelection();
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                DropDownList2.Visible = false;
                Label1.Text = "";
                Label2.Text = "";
                Label4.Text = "";
                Label3.Text = "";
                Label6.Text = "";

            }
            else
            {
                Label6.Text = "Please enter a keyword";
                div4.Visible = false;

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
            Label6.Text = "";
            div4.Visible = false;
            div5.Visible = true;
            DetailsView1.Visible = false;
            DetailsView2.Visible = false;
            TextBox1.Text = "";
            string criterion = DropDownList1.Text;
            int choice;
            string userInput;
            string keyword = "";
            if (DropDownList1.SelectedIndex != 0)
            {
                if (RadioButtonList1.SelectedItem != null || RadioButtonList2.SelectedItem != null || RadioButtonList3.SelectedItem != null)
                {
                    if (criterion.Equals("account type"))
                    {
                        choice = RadioButtonList2.SelectedIndex;
                        if (choice != 0)
                        {

                            if (DropDownList2.SelectedIndex != 0)
                            {
                                userInput = DropDownList2.Text;
                                keyword = string.Format("{0}", userInput);
                            }
                            else
                            {
                                Label2.Text = "Please select a type.";
                                keyword = "0";
                            }

                        }
                    }
                    else if (criterion.Equals("username"))
                    {
                        choice = RadioButtonList1.SelectedIndex;
                        userInput = TextBox3.Text.ToLower();
                        if (!string.IsNullOrWhiteSpace(userInput))
                        {
                            keyword = string.Format("%{0}%", userInput);
                        }
                        else
                        {
                            Label3.Text = "Please enter a keyword into the textbox.";
                            keyword = "0";
                        }
                    }
                    else
                    {
                        choice = RadioButtonList1.SelectedIndex;
                        if (choice != 0)
                        {
                            userInput = TextBox2.Text.ToLower();
                            if (!string.IsNullOrWhiteSpace(userInput))
                            {
                                keyword = string.Format("%{0}%", userInput);
                            }
                            else
                            {
                                Label1.Text = "Please enter a keyword into the textbox.";
                                keyword = "0";

                            }

                        }

                    }
                    GetResultsByCriterion(criterion, keyword);
                }

                else
                {
                    Label4.Text = "Please select an option";
                }
            }
            else
            {
                Label4.Text = "Please select a search criterion";
            }
        }
        public void GetResultsByCriterion(string criterion, string keyword)
        {
            LoginDSTableAdapters.LOGININFOTableAdapter loginInfoTableAdapter = new LoginDSTableAdapters.LOGININFOTableAdapter();
            UserDSTableAdapters.USERINFOTableAdapter userInfoTableAdapter = new UserDSTableAdapters.USERINFOTableAdapter();
            if (criterion.Equals("username"))
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    GridView2.DataSource = userInfoTableAdapter.GetDataByUsername(keyword);
                }


            }
            else if (criterion.Equals("first name"))
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    if (!keyword.Equals("0"))
                    {

                        GridView2.DataSource = userInfoTableAdapter.GetDataByFirstName(keyword);
                    }
                }
                else
                {
                    GridView2.DataSource = userInfoTableAdapter.GetDataByAllFirstName();
                }
            }
            else if (criterion == "last name")
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    if (!keyword.Equals("0"))
                    {

                        GridView2.DataSource = userInfoTableAdapter.GetDataByLastName(keyword);
                    }
                }
                else
                {
                    GridView2.DataSource = userInfoTableAdapter.GetDataByAllLastName();
                }
            }
            else if (criterion == "email")
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    if (!keyword.Equals("0"))
                    {
                        GridView2.DataSource = userInfoTableAdapter.GetDataByEmail(keyword);
                    }
                }
                else
                {
                    GridView2.DataSource = userInfoTableAdapter.GetDataByAllEmail();
                }
            }
            else if (criterion == "phone number")
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    if (!keyword.Equals("0"))
                    {
                        GridView2.DataSource = userInfoTableAdapter.GetDataByPhone(keyword);
                    }
                }
                else
                {
                    GridView2.DataSource = userInfoTableAdapter.GetDataByAllPhone();
                }
            }
            else if (criterion == "account type")
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    if (!keyword.Equals("0"))
                    {
                        GridView2.DataSource = loginInfoTableAdapter.GetDataByAccountType(keyword);
                    }
                }
                else
                {
                    GridView2.DataSource = loginInfoTableAdapter.GetDataByAllAccountType();
                }
            }
            GridView2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Equals("account type"))
            {
                div1.Visible = false;
                div2.Visible = true;
                div3.Visible = false;
            }
            else if (DropDownList1.SelectedValue.Equals("username"))
            {
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = true;
            }
            else
            {
                div1.Visible = true;
                div2.Visible = false;
                div3.Visible = false;
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            if (RadioButtonList1.SelectedIndex == 1)
            {
                TextBox2.Visible = true;
            }
            else
            {
                TextBox2.Visible = false;
            }
        }
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            if (RadioButtonList2.SelectedIndex == 1)
            {
                DropDownList2.Visible = true;
            }
            else
            {
                DropDownList2.Visible = false;
            }
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            if (RadioButtonList3.SelectedIndex == 0)
            {
                TextBox3.Visible = true;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedLink = GridView2.SelectedRow.Cells[3].Text;
            string result = GetDetailsForAdvancedSearch(selectedLink);
            Label5.Text = result;
        }

        public string GetDetailsForAdvancedSearch(string userInput)
        {
            // string connectionString = "Data Source=itksqlexp8;Initial Catalog=AJAIN5_ConservationSchool;"
            //                            + "Integrated Security=true";
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                         + "Integrated Security=true";

            string queryString = "SELECT * from userinfo "
                          + "WHERE username = '" + userInput + "';";

            string result = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result += "First name:" + reader[0].ToString() + "<br />";
                        result += "Last name is :" + reader[1].ToString() + "<br />";
                        result += "Username:" + reader[2].ToString() + "<br />";
                        result += "Email :" + reader[3].ToString() + "<br />";
                        result += "Phone Number :" + reader[5].ToString() + "<br />";

                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            connectionString = "Data Source=itksqlexp8;Initial Catalog=it485project;"
                                         + "Integrated Security=true";

            queryString = "SELECT acctype from logininfo "
                          + "WHERE username = '" + userInput + "';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result += "Account Type:" + reader[0].ToString() + "<br />";

                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
    }
}