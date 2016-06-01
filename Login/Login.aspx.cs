using CryptSharp;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Solstice
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Validate();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int userID = GetUserID();
            if (userID != 0)
            {
                //Click on the login to add the user
                Session["UserID"] = userID;

                switch ((UserTypeEnum)Session["UserType"])
                {
                    //Switch statement to see if the user is a student,admin,or teacher
                    case UserTypeEnum.Student:
                        Response.Redirect("GameScreen.aspx");
                        break;
                    case UserTypeEnum.Teacher:
                        Response.Redirect("TeacherHome.aspx");
                        break;
                    case UserTypeEnum.Administrator:
                        Response.Redirect("AdminHome.aspx");
                        break;
                    case UserTypeEnum.Super:
                        Response.Redirect("SecretSeedDatabase.aspx");
                        break;
                }
            }
        }
        /// <summary>
        /// Length of the hash string from Blowfish encryption
        /// </summary>
        public const int HashLength = 60;
        /// <summary>
        /// Check to see if the user is in the database and the passwords match.
        /// Notify the user if the username or password are invalid.
        /// </summary>
        /// <returns>userID if username and password are valid, 0 otherwise</returns>
        private int GetUserID()
        {
            lblVldPassword.Visible = false;

            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var userq = db.Users.Where(x => x.Login == txtUserName.Text);
                int userID = 0;

                if (userq.Count() > 0)
                {
                    User user = userq.First();
                    string mash = user.Password;
                    string hash = mash.Substring(startIndex: 0, length: HashLength);
                    string salt = mash.Substring(startIndex: HashLength);
                    string crypted = String.Empty;
                    if (!String.IsNullOrWhiteSpace(salt))
                    {
                        crypted = Crypter.Blowfish.Crypt(key: Encoding.ASCII.GetBytes(txtPassword.Text),
                        salt: salt);
                    }
                    if (hash == crypted)
                    {
                        Session["UserType"] = user.UserType;
                        userID = user.UserID;
                    }
                    if (userID == 0)
                        lblVldPassword.Visible = true;
                }
                else
                {
                    lblVldPassword.Visible = true;
                }
                return userID;
            }
        }
    }
}