using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConservationSchoolDBProject
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            liReturningStudent.Visible = true;
            liNewStudent.Visible = true;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                liNewStudent.Visible = false;
            }
            else {
                liReturningStudent.Visible = false;
            }
        }
    }
}