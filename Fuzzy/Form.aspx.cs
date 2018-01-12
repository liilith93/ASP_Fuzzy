using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathWorks.MATLAB.ProductionServer.Client;
using Fuzzy;

namespace MGR_site
{
    
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Request.Form["Name"];
                string surname = Request.Form["Surname"];
                int sex = Convert.ToInt32(Request.Form["Sex"]);
                double age = Convert.ToDouble(Request.Form["Age"]);
                string pain = Request.Form["Pain"];
                int painC = 0;
                if (pain != null)
                {
                    string[] split = pain.Split(',');
                    for (int i = 0; i < split.Length; i++)
                    {
                        int variable = Convert.ToInt32(split[i]);
                        painC += variable;
                    }
                }
                double bPress = Convert.ToDouble(Request.Form["BPress"]);
                double chol = Convert.ToDouble(Request.Form["Cholesterol"]);
                int smoker = Convert.ToInt32(Request.Form["Smoker"]);
                double sWeek = 0;
                //double sYear = 0;
                if (smoker == 0)
                {
                    sWeek = Convert.ToDouble(Request.Form["CigPerWeek"]);
                }
                double sugar = Convert.ToDouble(Request.Form["Sugar"]);
                int famSugar = Convert.ToInt32(Request.Form["SugarFam"]);
                int rEkg = Convert.ToInt32(Request.Form["restEKG"]);
                //double mHR = Convert.ToDouble(Request.Form["MaxHR"]);
                double rHR = Convert.ToDouble(Request.Form["RestHR"]);
                double fat = Convert.ToDouble(Request.Form["Fat"]);
                int kidney = Convert.ToInt32(Request.Form["Kidney"]);

                RiskCounter rc = new RiskCounter();
                double[,] result = rc.fuzzyRisk(age, bPress, chol, sWeek, sugar, rHR, fat);
                List<int> addedRisk = rc.addedRisk(age, sex, painC, famSugar, rEkg, kidney);
                string im = name;
                string nz = surname;

                Context.Items["result"] = result;
                Context.Items["addedRisk"] = addedRisk;
                Context.Items["name"] = im;
                Context.Items["surname"] = nz;

                Server.Transfer("Result.aspx", true);
            }
            catch (NullReferenceException ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + "Uzupełnij wszystkie pola!" + "');", true);
            }
            catch (SystemException ex)
            {                
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
            catch (MatlabProcessingException ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + "Błąd przetwarzania danych (brak połączenia z serwerem?)" + "');", true);
            }
            

        }

        protected void Autofill_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "hwa", "fill();", true);
        }
    }
}