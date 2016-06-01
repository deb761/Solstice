using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solstice
{
    public partial class ClassView : ProtectedPage
    {
        /// <summary>
        /// Make sure a user is logged in and that he/she has
        /// permission to be on this page
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            UserType uType = (UserType)Session["UserType"];

            switch (uType)
            {
                case UserType.Student:
                    Response.Redirect("GameScreen.aspx");
                    break;
                case UserType.Teacher:
                    Response.Redirect("TeacherHome.aspx");
                    break;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*using (DataClassesDataContext dc = new DataClassesDataContext()) {

                lblName.Text = dc.classes;

            }*/

        }
    }
}