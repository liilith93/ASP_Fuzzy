using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathWorks.MATLAB.ProductionServer.Client;
using Fuzzy;
using System.Collections.Specialized;
using System.Reflection;

namespace MGR_site
{
    
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Console.WriteLine(User.Identity.);
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

                //RiskCounter rc = new RiskCounter();
                //double[,] result = rc.fuzzyRisk(age, bPress, chol, sWeek, sugar, rHR, fat);
                // List<int> addedRisk = rc.addedRisk(age, sex, painC, famSugar, rEkg, kidney);
                double[,] result = new double[2, 2];            // TM TEST!!!
                result[1, 1] = 50;                              // TM TEST!!!
                List<int> addedRisk = new List<int>();
                addedRisk.Add(1);
                string im = name;
                string nz = surname;

                Context.Items["result"] = result;
                Context.Items["addedRisk"] = addedRisk;
                Context.Items["name"] = im;
                Context.Items["surname"] = nz;

                heartbaseEntities db = new heartbaseEntities();     // przygotowanie do zapisu do bazy do tabeli Results

                Results r = new Results         // parsujemy dane z formularza
                {
                    Name = name,
                    Surname = surname,
                    Sex = sex,
                    Age = age,
                    Pain = pain,
                    PainC = painC,
                    BPress = bPress,
                    Cholesterol = chol,
                    Smoker = smoker,
                    CigPerWeek = sWeek,
                    Sugar = sugar,
                    SugarFam = famSugar,
                    restEKG = rEkg,
                    RestHR = rHR,
                    Fat = fat,
                    Kidney = kidney,
                    result = result[0, 0]
                };

                db.Results.Add(r);          // dodajemy do bazy
                db.SaveChanges();


                // zapis wyniku do bazy do tabeli Users_results 
                string login = User.Identity.Name;              // wyciaganie aktualnie zalogowanego uzytkownika
                var userss = db.Userss.Where(x => x.Username == login);     // to jest login! potrzebujemy id
                Userss[] user = userss.ToArray();
                if (user.Length > 0)        // wiec jesli znajdziemy jakiegos uzytkownika
                {
                    int idUser = user[0].Id;            // to pobieramy jego id

                    var maxx = db.Results.ToList().Last();      // i pobieramy id wlasnie dodanego rekordu result
                    int idRes = maxx.Id;

                    Users_results ur = new Users_results        // wiazemy te dwa id
                    {
                        Id_result = idRes,
                        Id_user = idUser
                    };

                    db.Users_results.Add(ur);           // dodajemy i zapisujemy do bazy
                    db.SaveChanges();
                }

                

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
            if(User.Identity.IsAuthenticated)
            {
                heartbaseEntities db = new heartbaseEntities();     // przygotowanie do zapisu do bazy do tabeli Results
 
                string login = User.Identity.Name;              // wyciaganie aktualnie zalogowanego uzytkownika
                var userss = db.Userss.Where(x => x.Username == login);     // to jest login! potrzebujemy id
                Userss[] user = userss.ToArray();
                if (user.Length > 0)        // wiec jesli znajdziemy jakiegos uzytkownika
                {
                    int idUser = user[0].Id;            // to pobieramy jego id

                    // TODO zabezpieczyc przed brakiem elementow w Users_Results

                    if (db.Users_results.Where(x => x.Id_user == idUser).Any())
                    {

                        var maxx = db.Users_results.Where(x => x.Id_user == idUser).ToList().Last();
                        var res = db.Results.Where(x => x.Id == maxx.Id_result).ToList().Last();      // i pobieramy id wlasnie dodanego rekordu result

                       ClientScript.RegisterStartupScript(GetType(), "hwa", "fillValues("
                            + "\"" + res.Name + "\", "
                            + "\"" + res.Surname + "\", "
                            + "\"" + res.Sex + "\", "
                            + "\"" + res.Age + "\", "
                            + "\"" + res.Pain + "\", "
                            + "\"" + res.BPress + "\", "
                            + "\"" + res.Cholesterol + "\", "
                            + "\"" + res.Smoker + "\", "
                            + "\"" + res.CigPerWeek + "\", "
                            + "\"" + res.Sugar + "\", "
                            + "\"" + res.SugarFam + "\", "
                            + "\"" + res.restEKG + "\", "
                            + "\"" + res.RestHR + "\", "
                            + "\"" + res.Fat + "\", "
                            + "\"" + res.Kidney + "\", "
                            + ");", true);
                    }
                }
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "fill();", true);
        }


        public void assignFieldValue(string field, string value)
        {
            NameValueCollection oQuery = Request.QueryString;
            oQuery = (NameValueCollection)Request.GetType().GetField("_queryString", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Request);
            PropertyInfo oReadable = oQuery.GetType().GetProperty("IsReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            oReadable.SetValue(oQuery, false, null);
            oQuery[field] = value;
            oReadable.SetValue(oQuery, true, null);
        }


    }
}