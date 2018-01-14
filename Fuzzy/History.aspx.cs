using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuzzy
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Console.WriteLine(EntityDataSource1.CommandText);


            heartbaseEntities db = new heartbaseEntities();     // przygotowanie do zapisu do bazy do tabeli Results


            string login = User.Identity.Name;              // wyciaganie aktualnie zalogowanego uzytkownika
    
            var userss = db.Userss.Where(x => x.Username == login);     // to jest login! potrzebujemy id
            Userss[] user = userss.ToArray();

            List<Users_results> ur = null;
            List<Results> r = new List<Results>();

            if (user.Length > 0)        // wiec jesli znajdziemy jakiegos uzytkownika
            {
                int idUser = user[0].Id;            // to pobieramy jego id

                var resul = db.Users_results.Where(x => x.Id_user == idUser);
                
                foreach ( Users_results userresult in resul.ToList())
                {
                    var resul2 = db.Results.Where(x => x.Id == userresult.Id_result);
                    Results[] result =  resul2.ToArray();
                    if (result.Length>0)
                    {
                        r.Add(result[0]);
                    }                    
                }                
            }



            GridView1.DataSource = r;
            GridView1.DataBind();
        }
    }
}