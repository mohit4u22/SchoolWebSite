using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ConservationSchoolDBProject
{
    public partial class NewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    registrationForm.Visible = false;
                    regMessage.Visible = true;
                    string first = firstName.Text;
                    string last = lastName.Text;
                    string phone = telephone.Text;
                    string emailAddress = Request.Form["email"];
                    string password = passbox.Text;
                    SqlConnection dbConnection = new SqlConnection("Server=tcp:t1ypb2k7ie.database.windows.net,1433;Database=illinoisschoolDB;User ID=mohitjain0890@hotmail.com@t1ypb2k7ie;Password=Mahaveer2;Trusted_Connection=False;Encrypt=True;Connection Timeout=90;");
                    //                SqlConnection dbConnection = new SqlConnection("Data Source=BLLIM-LT;Integrated Security=true"); // OK w/ Laptop
                    //                SqlConnection dbConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Integrated Security=true"); // orig
                    try
                    {
                        dbConnection.Open();
                      //  dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool"); // change itk368XXXX to your ID here
//                        dbConnection.ChangeDatabase("368SQLDB");

                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 911) // non-existent DB
                        {
                            SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE it3680115Fall13_ConservationSchool", dbConnection);
                            sqlCommand.ExecuteNonQuery();
                            regMessage.Text = "<p>Successfully created the database.</p>";
                       //     dbConnection.ChangeDatabase("it3680115Fall13_ConservationSchool");
                        }
                        else
                            Response.Write("<p>Error code " + exception.Number
                                + ": " + exception.Message + "</p>");
                    }
                    finally
                    {
                        //regMessage.Text += "<p>Successfully selected the database.</p>";
                        Console.Write("Successfully selected the database");
                    }
                    try
                    {
                        string SQLString = "SELECT * FROM students";
                        SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
                        SqlDataReader idRecords = checkIDTable.ExecuteReader();
                        idRecords.Close();
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 208) // object/table does not exist
                        {
                            SqlCommand sqlCommand = new SqlCommand("CREATE TABLE students (studentID SMALLINT IDENTITY(100,1) PRIMARY KEY, first VARCHAR(25), last VARCHAR(50), phone VARCHAR(16), email VARCHAR(50), password VARCHAR(20))", dbConnection);
                            sqlCommand.ExecuteNonQuery();
                            regMessage.Text += "<p>Successfully created the table.</p>";
                            Console.Write("Successfully created the table");
                        }
                        else
                            regMessage.Text += "<p>Error code " + exception.Number
                                + ": " + exception.Message + "</p>";
                    }
                    finally
                    {
                        string studentInfo = "INSERT INTO students VALUES('"
                            + first + "', '"
                            + last + "', '"
                            + phone + "', '"
                            + emailAddress + "', '"
                        +password + "')";
                        //                    Response.Write("studentInfo INSERT:" + studentInfo);
                        //Console.Write("studentInfo INSERT:" + studentInfo);
                        SqlCommand sqlCommand = new SqlCommand(studentInfo, dbConnection);
                        sqlCommand.ExecuteNonQuery();
                    }
                    string idString = "SELECT IDENT_CURRENT('students') AS studentID";
                    SqlCommand newID = new SqlCommand(idString, dbConnection);
                    SqlDataReader studentRecord = newID.ExecuteReader();
                    studentRecord.Read();
                    string studentID = Convert.ToString(studentRecord["studentID"]);
                    studentRecord.Close();
                    System.Web.Security.FormsAuthentication.SetAuthCookie(studentID, true);
                    regMessage.Text += "<p>Thanks " + first + "! Your new student ID is <strong>" + studentID + "</strong>.</p>";
                    regMessage.Text += "<p><a href='ReturningStudent.aspx?studentID=" + studentID + "'>Register for Classes</a></p>";
                    dbConnection.Close();
                }
            }
        }
        protected void getStudentID_Click(object sender, EventArgs e)
        {

        }
    }
}