using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ReviewSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["studentID"] == "")
            Response.Redirect("Default.aspx");
else
{
    SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");
//    SqlConnection dbConnection = new SqlConnection("Data Source=BLLIM-LT;Integrated Security=true");

//    SqlConnection dbConnection = new SqlConnection(
//        "Data Source=.\\SQLEXPRESS;Integrated Security=true");
    string studentID = Request.QueryString["studentID"];
    schedule.Text = "<p>Student ID: " + Request.QueryString["studentID"] + "</p>";
    try
    {
        dbConnection.Open();
       // dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
        string classInfo = "SELECT * FROM registration WHERE studentID=" + studentID;
        SqlCommand studentSchedule = new SqlCommand(
            classInfo, dbConnection);
        SqlDataReader scheduleRecords =
            studentSchedule.ExecuteReader();
        if (scheduleRecords.Read())
        {
            schedule.Text += "<table width='100%' border='1'>";
            schedule.Text += "<tr><th>Class</th><th>Days</th><th>Time</th></tr>";
            do
            {
                schedule.Text += "<tr>";
                schedule.Text += "<td>"
                    + scheduleRecords["class"]
                    + "</td>";
                schedule.Text += "<td>"
                    + scheduleRecords["day"]
                    + "</td>";
                schedule.Text += "<td>"
                    + scheduleRecords["time"]
                    + "</td>";
                schedule.Text += "</tr>";
            } while (scheduleRecords.Read());
            schedule.Text += "</table>";
        }
        else
            schedule.Text += "<p>You have not registered for any classes! Click your browser's Back button to return to the previous page.</p>";
        scheduleRecords.Close();
    }
    catch (SqlException exception)
    {
        Response.Write("<p>Error code " + exception.Number
            + ": " + exception.Message + "</p>");
    }
    dbConnection.Close();
}
    }
}
