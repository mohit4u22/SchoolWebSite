﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class DeleteSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["studentID"] == "")
            Response.Redirect("Default.aspx");
        else
        {
            SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            //    SqlConnection dbConnection = new SqlConnection("Data Source=BLLIM-LT;Integrated Security=true");

            //    SqlConnection dbConnection = new SqlConnection(
            //        "Data Source=.\\SQLEXPRESS;Integrated Security=true");
//            string studentID = Request.QueryString["studentID"];
//            schedule.Text = "<p>Student ID: " + Request.QueryString["studentID"] + "</p>";
            schedule.Text = "Student ID:" + Request.QueryString["studentID"] + " with schedule: " + Request.QueryString["class"] + " on " + Request.QueryString["day"] + ", " + Request.QueryString["time"] + "<p/>"; 
        }
    }
    protected void yesButton_Click(object sender, EventArgs e)
    {
          scheduleForm.Visible = false;
        results.Visible = true;
        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
        try
        {
            dbConnection.Open();
            dbConnection.ChangeDatabase("itk3680130_ConservationSchool");
//            int studentID = Convert.ToInt16(Request.QueryString["studentID"]);
            string SQLString = "DELETE FROM registration WHERE studentID='" + Request.QueryString["studentID"]
                + "' and class='" + Request.QueryString["class"]
                + "' and day='" + Request.QueryString["day"]
                + "' and time='" + Request.QueryString["time"] + "'";
            SqlCommand deleteString = new SqlCommand(SQLString, dbConnection);
            deleteString.ExecuteNonQuery();
            results.Text = "<p>Schedule deleted successfully.</p>";
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code " + exception.Number
                + ": " + exception.Message + "</p>");
        }
        dbConnection.Close();
    }
    protected void noButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

}
