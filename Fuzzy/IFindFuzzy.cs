using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{
    public interface IFindFuzzy
    {
        double[,] FindFuzzy(double age, double bloodPressure, double cholesterolTOT, double cigWeek, double sugar,
            double restHR, double fat);
    }
}
