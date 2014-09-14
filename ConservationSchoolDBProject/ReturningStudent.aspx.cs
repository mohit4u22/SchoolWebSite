using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ReturningStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usession"] == null)
            Response.Redirect("Default.aspx");
        else
        {
            Button1.Visible = true;
            Button4.Visible = true;
        }
     

        string sessionobj = Session["usession"].ToString();
      
        SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");
        try
        {
            dbConnection.Open();
     //       dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
        }
        finally
        {
            Console.Write("Successfully selected the database");
        }
        try
        {

            string SQLString = "SELECT * FROM students WHERE studentID='" + Session["usession"] + "'";
            SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
            SqlDataReader userdata = checkIDTable.ExecuteReader();

            if (userdata.Read())
            {
                lblwelcome.Text = "<h3>Welcome to your Profile " + userdata["last"] + ", " + userdata["first"] + " </h3>";
              

            }
            userdata.Close();
            dbConnection.Close();
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
        }
  
       

    }

    protected void register_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                panel1.Visible = false;
                regMessage.Visible = true;
                string studentID = Session["usession"].ToString();
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
                        //regMessage.Text = "<p>Successfully created the database.</p>";
                     //   dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
                    }
                    else
                        Response.Write("<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>");
                }
                finally
                {
                    //regMessage.Text += "<p>Successfully selected the database.</p>";
                    //Console.Write("Successfully selected the database");
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
                        //regMessage.Text += "<p>Successfully created the table.</p>";
                        //Console.Write("Successfully created the table");
                    }
                    //else
                    //    regMessage.Text += "<p>Error code " + exception.Number
                    //        + ": " + exception.Message + "</p>";
                }

                try
                {
                    //dbConnection.Open(); already opened above
              //      dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
                    string classInfo = "INSERT INTO registration VALUES('"
                        + studentID + "', '" + selectedClass
                        + "', '" + selectedDays + "', '" + selectedTime + "')";
                    SqlCommand sqlCommand = new SqlCommand(
                        classInfo, dbConnection);
                    sqlCommand.ExecuteNonQuery();
                    regMessage.Text = "<p> Congrats !! You are now registered for "
                        + selectedClass + " on " + selectedDays + ", " + selectedTime;
                    //regMessage.Text += "<p>Register for more classes !</p>";
                }
                catch (SqlException exception)
                {
                    regMessage.Text += "<p> You already registered for this course! <br/>Choose another Course! ";
                }
                dbConnection.Close();


            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Clear();
        System.Web.Security.FormsAuthentication.SignOut();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReviewSchedule2.aspx");
    }
}
