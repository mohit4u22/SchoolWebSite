using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Page.IsPostBack)
        //{
        //    Page.Validate();
        //    if (Page.IsValid)
        //    {

        //        //String Uname = "";
        //        //   String Passw = "";

        //        SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");
        //        //                SqlConnection dbConnection = new SqlConnection("Data Source=BLLIM-LT;Integrated Security=true");
        //        //                SqlConnection dbConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Integrated Security=true");
        //        try
        //        {
        //            dbConnection.Open();
        //            dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
        //            string SQLString = "SELECT * FROM students WHERE studentID=" + Session["usession"];
        //            //  String SqlString = "SELECT * from LoginInfo where  username = '" + Uname + " and PAssword = '" + Passw + "'";

        //            SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
        //            SqlDataReader idRecords = checkIDTable.ExecuteReader();
        //            if (idRecords.Read())
        //            {
        //                //  Response.Write("Login Successful"); remove underline
        //                Response.Redirect("ReturningStudent.aspx?studentID=" + studentID.Text);
        //                idRecords.Close();
        //            }
        //            else
        //            {
        //                //respone Inva;lid username password, remove under
        //                validateMessage.Text = "<p>**Invalid student ID**</p>";
        //                idRecords.Close();
        //            }
        //        }
        //        catch (SqlException exception)
        //        {
        //            Response.Write("<p>Error code " + exception.Number
        //                + ": " + exception.Message + "</p>");
        //        }

        //    }
        //}
        Panel1.Visible = true;
        if (Session["usession"] != null)
        {
            
            Panel1.Visible = false;

            SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");

            try
            {
                dbConnection.Open();
             //   dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
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
                    Label1.Text = "<h2>You are already Logged in to your Profile " + userdata["last"] + ", " + userdata["first"] + "! </h2>";


                }
                userdata.Close();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }


        }
        else
        {
            Button4.Visible = false;
            Panel1.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");

        try
        {
            dbConnection.Open();
          //  dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
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

            string SQLString = "SELECT * FROM students WHERE studentID='" + studentID.Text + "'";
            SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
            SqlDataReader userdata = checkIDTable.ExecuteReader();
            if (userdata.Read())
            {
                if (userdata["studentID"].ToString().Equals(studentID.Text) && userdata["password"].Equals(password.Text))
                {
                    Session["usession"] = studentID.Text;
                    FormsAuthentication.RedirectFromLoginPage(studentID.Text, true);
                    Response.Redirect("ReturningStudent.aspx");
                }
                else
                {

                    Label2.Text= "You have entered Wrong Credentials. Please Try Again!!!!";

                }
            }
            else
            {
                Response.Write("You have entered Wrong Credentials. Please Try Again!!!!");
            }
            userdata.Close();
            dbConnection.Close();
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code " + exception.Number
            + ": " + exception.Message + "</p>");
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewStudent.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["usession"] = null;
        Response.Redirect("Default.aspx");
    }

}