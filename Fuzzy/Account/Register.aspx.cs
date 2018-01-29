using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Configuration;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Fuzzy.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            using (MD5 md5hash = MD5.Create())
            {
                string hashPass = HashMD5(md5hash, RegisterUser.Password.Trim());       // haslo zahashowane

                heartbaseEntities db = new heartbaseEntities();     // zapis parametrow z formularza
               // string name = Request.Form[6];
                
                Userss us = new Userss
                {
                    Username = RegisterUser.UserName.Trim(),
                    Password = hashPass,
                    Email = RegisterUser.Email.Trim(),
                    Name = Request.Form[6].ToString(), //RegisterUser.Name.Trim(),
                    Surname = Request.Form[7].ToString()
                    //Name = "name",
                    //Surname = "surname"
                };

                db.Userss.Add(us);
                db.SaveChanges();



                /*
                int ID = 0;
                string connStr = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        //using (SqlDataAdapter sda = new SqlDataAdapter())
                        //{
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.Parameters.AddWithValue("@Username", RegisterUser.UserName.Trim());
                        //    cmd.Parameters.AddWithValue("@Password", hashPass);
                        //    cmd.Parameters.AddWithValue("@Email", RegisterUser.Email.Trim());
                        //    cmd.Connection = conn;
                        //    conn.Open();
                        //    ID = Convert.ToInt32(cmd.ExecuteScalar());
                        //    conn.Close();
                        //}

                        cmd.CommandText = "select * from Userss";
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.TableDirect



                    }
                    SendActivationEmail(ID);
                }
                */
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

        private void SendActivationEmail(int ID)
        {
            string activationCode = Guid.NewGuid().ToString();

            using (MailMessage mm = new MailMessage("umoldysz.ib@gmail.com", RegisterUser.Email))
            {
                mm.Subject = "Aktywacja konta";
                string body = "Witaj " + RegisterUser.UserName.Trim() + ",";
                body += "<br /><br />Kliknij poniższy link w celu aktywacji konta";
                body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Account/Register.aspx", "Account/Activation.aspx?ActivationCode=" + activationCode + "&ID=" + ID) + 
                    "'>LINK AKTYWACYJNY.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("umoldysz.ib@gmail.com", "haslo123");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}
