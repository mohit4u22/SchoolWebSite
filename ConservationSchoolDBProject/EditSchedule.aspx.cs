using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

public partial class EditSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["class"] == null)
        {
            Response.Redirect("ReviewSchedule2.aspx");
        }
        if (!IsPostBack)
        {
            SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");
            try
            {
                dbConnection.Open();
             //   dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
                string classInfo = "SELECT * FROM registration WHERE studentID=" + HttpContext.Current.User.Identity.Name + " and class='" + Request.QueryString["class"].ToString() + "'";
                SqlCommand studentSchedule = new SqlCommand(
                    classInfo, dbConnection);
                SqlDataReader scheduleRecords =
                    studentSchedule.ExecuteReader();
                if (scheduleRecords.Read())
                {
                    className.SelectedValue = scheduleRecords["class"].ToString();
                    days.SelectedValue = scheduleRecords["day"].ToString();
                    time.SelectedValue = scheduleRecords["time"].ToString();
                }
            }
            catch (Exception ex)
            { }
        }
    }


    protected void noButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


    protected void register_Click(object sender, EventArgs e)
    {

        if (Page.IsPostBack)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                editscheduleForm.Visible = false;
                results.Visible = true;
                string studentID = HttpContext.Current.User.Identity.Name;
                string selectedClass = "";
                string selectedDays = "";
                string selectedTime = "";
                for (int i = 0; i < className.Items.Count; ++i)
                {
                    if (className.Items[i].Selected)
                        selectedClass = className.Items[i].Value;
                }
                for (int i = 0; i < days.Items.Count; ++i)
                {
                    if (days.Items[i].Selected)
                        selectedDays = days.Items[i].Value;
                }
                for (int i = 0; i < time.Items.Count; ++i)
                {
                    if (time.Items[i].Selected)
                        selectedTime = time.Items[i].Value;
                }
                //                SqlConnection dbConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Integrated Security=true");
                //                SqlConnection dbConnection = new SqlConnection("Data Source=BLLIM-LT;Integrated Security=true");
                SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");
                try
                {
                    dbConnection.Open();
                   // dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool"); // change itk368XXXX to your ID here
                    //                        dbConnection.ChangeDatabase("368SQLDB");

                }
                catch (SqlException exception)
                {
                    if (exception.Number == 911) // non-existent DB
                    {
                        SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE it3680115Fall13_ConservationSchool", dbConnection);
                        sqlCommand.ExecuteNonQuery();
                       // results.Text = "<p>Successfully created the database.</p>";
                      //  dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
                    }
                    else
                        Response.Write("<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>");
                }
                finally
                {
                    
                }
                try
                {
                    string SQLString = "SELECT * FROM registration";
                    SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
                    SqlDataReader idRecords = checkIDTable.ExecuteReader();
                    idRecords.Close();
                }
                catch (SqlException exception)
                {
                    if (exception.Number == 208) // object/table does not exist
                    {
                        SqlCommand sqlCommand = new SqlCommand("CREATE TABLE registration (studentID SMALLINT, class VARCHAR(50), day VARCHAR(50), time VARCHAR(50))", dbConnection);
                        sqlCommand.ExecuteNonQuery();
                        results.Text += "<p>Successfully created the table.</p>";
                        Console.Write("Successfully created the table");
                    }
                    else
                        results.Text += "<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>";
                }

                try
                {
                    //dbConnection.Open(); already opened above
                  //  dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
                    string classInfo = "UPDATE registration SET  class= '" + selectedClass + "',day= '" + selectedDays + "',time= '" + selectedTime + "' WHERE studentID='" + studentID + "' and class='" + Request.QueryString["class"] + "'";
                    SqlCommand sqlCommand = new SqlCommand(
                        classInfo, dbConnection);
                    sqlCommand.ExecuteNonQuery();
                    results.Text = "<p>You are registered for "
                        + selectedClass + " on " + selectedDays + ", " + selectedTime;
                    results.Text += "<p><a href='ReviewSchedule2.aspx'>Click here </a> to register for more classes.</p>";
                }
                catch (SqlException exception)
                {
                    if (exception.Number == 2627)
                    {
                        results.Text = "you are already registered for this class. Please change the class or <a href='REviewSchedule2.aspx'>click here</a> to review your current schedule.";
                    }
                }
                dbConnection.Close();
            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Clear();
        FormsAuthentication.SignOut();
        //  Response.Redirect("Default.aspx");
    }
}

