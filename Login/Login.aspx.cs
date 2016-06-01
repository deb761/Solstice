using CryptSharp;
using System;
using System.Configuration;
using System.Data.SqlClient;
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

        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SolsticeAPI_dbConnectionString"].ConnectionString);
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int userID = GetUserID();
            if (userID != 0)
            {
                //Click on the login to add the user
                Session["UserID"] = userID;

                switch ((UserType)Session["UserType"])
                {
                    //Switch statement to see if the user is a student,admin,or teacher
                    case UserType.Student:
                        Response.Redirect("GameScreen.aspx");
                        break;
                    case UserType.Teacher:
                        Response.Redirect("TeacherHome.aspx");
                        break;
                    case UserType.Administrator:
                        Response.Redirect("AdminHome.aspx");
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

            conn.Open();
            string checkuser = "SELECT UserID, Password, UserType FROM Users WHERE Login=@username";
            SqlCommand com = new SqlCommand(checkuser, conn);
            com.Parameters.AddWithValue("@username", txtUserName.Text);
            SqlDataReader reader = com.ExecuteReader();
            int userID = 0;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string mash = (string)reader.GetValue(1);
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
                        Session["UserType"] = (UserType)reader.GetValue(2);

                        userID = (int)reader.GetValue(0);
                    }
                }
                if (userID == 0)
                    lblVldPassword.Visible = true;
            }
            else
            {
                lblVldPassword.Visible = true;
            }
            conn.Close();
            return userID;
        }
    }
}