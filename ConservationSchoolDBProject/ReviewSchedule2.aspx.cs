using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ReviewSchedule2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usession"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");
         
            string studentID = Session["usession"].ToString();
            schedule.Text = "<p>Student ID: " + Session["usession"] + "</p>";
            try
            {
                dbConnection.Open();
          //      dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
                string classInfo = "SELECT * FROM registration WHERE studentID=" + Session["usession"];
                SqlCommand studentSchedule = new SqlCommand(
                    classInfo, dbConnection);
                SqlDataReader scheduleRecords =
                    studentSchedule.ExecuteReader();
                if (scheduleRecords.Read())
                {
                    schedule.Text += "<table bgcolor='#DEB887' width='100%' border='1'>";
                    schedule.Text += "<tr bgcolor='#8B7765'><th>Class</th><th>Days</th><th>Time</th><th>Action</th></tr>";
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
                        schedule.Text += "<td><a href='DeleteSchedule.aspx?studentID="
                        + Session["usession"] + "&class="
                       + scheduleRecords["class"] + "&day=" + scheduleRecords["day"] + "&time=" + scheduleRecords["time"]
                       + "'>Delete</a>&nbsp;<a href='EditSchedule.aspx?class="
                       + scheduleRecords["class"] + "'>Edit</a></td>";
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

    protected void edit_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditSchedule.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Clear();
        System.Web.Security.FormsAuthentication.SignOut();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReturningStudent.aspx");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReturningStudent.aspx");
    }
}
