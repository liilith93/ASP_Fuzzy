using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuzzy.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }

        }

        private string HashMD5(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hashPass = HashMD5(md5Hash, loginForm1.Password);
                
                heartbaseEntities db = new heartbaseEntities();

                string Username = loginForm1.UserName.Trim();
                string Password = hashPass;              

                var userss =  db.Userss.Where(x => x.Username == Username);
                Userss[] user = userss.ToArray();
                if (user.Length>0)
                {
                    if(user[0].Password == Password)
                    {
                        FormsAuthentication.RedirectFromLoginPage(loginForm1.UserName, loginForm1.RememberMeSet);
                    }
                    else
                    {
                        loginForm1.FailureText = "Username and/or password is incorrect.";
                    }
                }
                else
                {
                    loginForm1.FailureText = "Username and/or password is incorrect.";
                }

                
                /*
                int ID = 0;
                string constr = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Validate_User"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", loginForm1.UserName);
                        cmd.Parameters.AddWithValue("@Password", hashPass);
                        cmd.Connection = con;
                        con.Open();
                        ID = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                    switch (ID)
                    {
                        case -1:
                            loginForm1.FailureText = "Username and/or password is incorrect.";
                            break;
                        case -2:
                            loginForm1.FailureText = "Account has not been activated.";
                            break;
                        default:
                            FormsAuthentication.RedirectFromLoginPage(loginForm1.UserName, loginForm1.RememberMeSet);
                            break;
                    }
                }
                */
            }
        }
    }

}
