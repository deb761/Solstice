using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeacherHome : ProtectedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Redirect(UserTypeEnum.Teacher))
            return;
    }

    protected void btnLogoff_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Server.Transfer("Logout.aspx");
    }
}