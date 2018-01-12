using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuzzy.Account
{
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string connStr = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
                string ID = !string.IsNullOrEmpty(Request.QueryString["ID"]) ?
                    Request.QueryString["ID"] : string.Empty;
                string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ?
                    Request.QueryString["ActivationCode"] : Guid.Empty.ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Login SET emailConf = 1 WHERE ID = @ID"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Connection = conn;
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            conn.Close();
                            if (rowsAffected == 1)
                            {
                                ltMessage.Text = "Konto zostało aktywowane.";
                            }
                            else
                            {
                                ltMessage.Text = "Błędny kod aktywacji.";
                            }
                        }
                    }
                }
            }
        }
    }
}