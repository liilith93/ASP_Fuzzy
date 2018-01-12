using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuzzy
{
    public partial class Result : System.Web.UI.Page
    {
        Dictionary<int, string> textRisk = new Dictionary<int, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                fillDictionary();
                object res = this.Context.Items["result"];
                object risks = this.Context.Items["addedRisk"];
                object name = this.Context.Items["name"];
                object surname = this.Context.Items["surname"];
                
                if (name != "" && name != null && surname != "" && surname != null)
                {
                    txtName.Text = name.ToString() + " " + surname.ToString();
                }
                else
                {
                    txtName.Text = "Jane Doe";
                }
                
                double[,] result = res as double[,];

                // resultTxt.Text = result[0, 0].ToString() + "%";
                resultTxt.Text = String.Format("{0:F0}%", result[0, 0]);
                
                // wyswietlenie zalecenia dot. dalszego postepowania badanego
                String recomendation = "";
                Color recCol = Color.Black;
                
                
                if(result[0,0]<32)
                {
                    recomendation = @"Jesteś w dobrej kondycji fizycznej. <br />
                    Pamiętaj o zdrowym trybie życia i regularnej aktywności fizycznej.";
                    recCol = Color.DarkOliveGreen;
                }
                else if(result[0,0]>=32 && result[0,0]<66)
                {
                    recomendation = @"Zalecamy przeprowadzenie badań kontrolnych pod kątem wymienionych czynników ryzyka.<br />
                    Pamiętaj o zdrowym trybie życia i regularnej aktywności fizycznej.";
                    recCol = Color.OrangeRed;
                }
                else if(result[0,0]>=66)
                {
                    recomendation = @"JESTEŚ W GRUPIE WYSOKIEGO RYZYKA ZACHOROWANIA.<br />
                    Skontaktuj się jak najszybciej z lekarzem i przeprowadź kompletną diagnostykę.";
                    recCol = Color.DarkRed;
                }
                else
                {
                    recomendation = @">>brak zaleceń<<";
                }

                recomendationTxt.Text = recomendation;
                recomendationTxt.ForeColor = recCol;
                List<int> addedRisk = risks as List<int>;
                if (addedRisk.Count != 0)
                {
                    txtRisks.Text = "Dodatkowe czynniki ryzyka, które występują to:";
                    foreach (int risk in addedRisk)
                    {
                        riskList.Items.Add(textRisk[risk]);
                    }
                }
                else
                {
                    txtRisks.Text = "Brak dodatkowych czynników ryzyka!";
                }
            }
            catch(Exception ex)
            {
                resultTxt.Text = "0%";
                addRisktxt.Text = "Brak dodatkowych czynników ryzyka!";
            }
        }

        private void fillDictionary()
        {
            textRisk.Add(0, "Brak objawów bólowych");
            textRisk.Add(1, "Występuje ból niedławicowy");
            textRisk.Add(2, "Występuje nietypowy ból niedławicowy");
            textRisk.Add(3, "Występuje ból dławicowy");
            textRisk.Add(4, "Cukrzyca w rodzinie");
            textRisk.Add(5, "Obecny jest ujemny załamek T");
            textRisk.Add(6, "Występuje kardiomiopatia przerostowa");
            textRisk.Add(7, "Obecność przewlekłej choroby nerek");
            textRisk.Add(8, "Jesteś mężczyzną po 55 roku życia");
            textRisk.Add(9, "Jesteś kobietą po 65 roku życia");
        }
    }
}