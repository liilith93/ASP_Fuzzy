using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Membership.OpenAuth;

namespace Fuzzy.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            

            if (!IsPostBack  )
            {
                // Determine the sections to render
                var hasLocalPassword = User.Identity.IsAuthenticated;
                setPassword.Visible = !hasLocalPassword;
                changePassword.Visible = hasLocalPassword;

                CanRemoveExternalLogins = hasLocalPassword;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The external login was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
            
        }

        
        protected void setPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //using (MD5 md5hash = MD5.Create())
                //{
                //    string hashPass = HashMD5(md5hash, changePassword.);                    
                //    string oldPassword = hashPass;
                //    string newPassword = hashPass;

                //    heartbaseEntities db = new heartbaseEntities();
                   
                //    string login = User.Identity.Name;              // wyciaganie aktualnie zalogowanego uzytkownika
                //    var userss = db.Userss.Where(x => x.Username == login);     // to jest login! potrzebujemy id
                //    Userss[] user = userss.ToArray();
                //    if (user.Length > 0)       
                //    {
                //        string currentPass = user[0].Password;

                //        if (currentPass == oldPassword)
                //        {
                //            user[0].Password = newPassword;
                //        }                        
                        
                //        db.SaveChanges();
                //    }
                    
                //    if (result.IsSuccessful)
                //    {
                //        Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                //    }
                //    else
                //    {

                //        ModelState.AddModelError("NewPassword", result.ErrorMessage);

                //    }
                //}
            }
        }
        
        
        public IEnumerable<OpenAuthAccountData> GetExternalLogins()
        {
            //var accounts = OpenAuth.GetAccountsForUser(User.Identity.Name);
            //CanRemoveExternalLogins = CanRemoveExternalLogins || accounts.Count() > 1;
            //return accounts;
            return null;
        }

        public void RemoveExternalLogin(string providerName, string providerUserId)
        {
            //var m = OpenAuth.DeleteAccount(User.Identity.Name, providerName, providerUserId)
            //    ? "?m=RemoveLoginSuccess"
            //    : String.Empty;
            //Response.Redirect("~/Account/Manage" + m);
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

        protected static string ConvertToDisplayDateTime(DateTime? utcDateTime)
        {
            // You can change this method to convert the UTC date time into the desired display
            // offset and format. Here we're converting it to the server timezone and formatting
            // as a short date and a long time string, using the current thread culture.
            return utcDateTime.HasValue ? utcDateTime.Value.ToLocalTime().ToString("G") : "[never]";
        }
    }
}