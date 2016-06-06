using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProtectedPage
/// </summary>
public class ProtectedPage : System.Web.UI.Page
{
    public ProtectedPage() : base()
    {
    }
    /// <summary>
    /// Redirect to the page for the current user type if
    /// it is not the allowed type.  Super user can go anywhere.
    /// </summary>
    /// <param name="allowed"></param>
    /// <returns></returns>
    protected bool Redirect(UserTypeEnum allowed)
    {
        if (Session["UserType"] == null)
        {
            Response.Redirect("Login.aspx");
            return true;
        }
        UserTypeEnum uType = (UserTypeEnum)Session["UserType"];

        if ((uType == allowed) || (uType == UserTypeEnum.Super))
            return false;

        switch (uType)
        {
            case UserTypeEnum.Student:
                Response.Redirect("GameScreen.aspx");
                break;
            case UserTypeEnum.Teacher:
                Response.Redirect("TeacherHome.aspx");
                break;
            case UserTypeEnum.Administrator:
                Response.Redirect("AdminHome.aspx");
                break;
        }
        return true;
    }
}