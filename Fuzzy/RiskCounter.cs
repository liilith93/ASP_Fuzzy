using MathWorks.MATLAB.ProductionServer.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuzzy
{

    public class RiskCounter
    {
        public double[,] fuzzyRisk(double age, double bloodPressure, double cholesterol, double cigPerWeek, double sugar,
            double restHR, double fat) 
        {
            MWClient client = new MWHttpClient();

            IFindFuzzy fuzzy = client.CreateProxy<IFindFuzzy>
                (new Uri("http://localhost:9910/FuzzyHeartSystem"));

            double[,] result = null;

            try
            {
               result = fuzzy.FindFuzzy(age, bloodPressure, cholesterol, cigPerWeek, sugar, restHR, fat);
            }
            catch(Exception e)
            {
                throw new MatlabProcessingException();
            }
                     
            return result;
        }

        public List<int> addedRisk(double age, int sex, int pain, int sugar, int EKG, int kidneyDis)
        {
            List<int> result = new List<int>();

            if (age > 55 && sex == 1)
            {
                result.Add(8);
            }
            else if (age > 65 && sex == 0)
            {
                result.Add(9);
            }

            switch (pain)
            {
                case 0:
                    break;
                case 1:
                    result.Add(1);
                    break;
                case 2:
                    result.Add(2);
                    break;
                case 3:
                    result.Add(3);
                    break;
                default:
                    break;
            }

            if (sugar == 1)
            {
                result.Add(4);
            }

            switch (EKG)
            {
                case 1:
                    result.Add(5);
                    break;
                case 2:
                    result.Add(6);
                    break;
                default:
                    break;
            }

            if (kidneyDis == 1)
            {
                result.Add(7);
            }

            return result;
        }

    }

    [Serializable()]
    public class MatlabProcessingException : System.Exception
    {
        public MatlabProcessingException() : base() { }
        public MatlabProcessingException(string message) : base(message) { }
        public MatlabProcessingException(string message, System.Exception inner) : base(message, inner) { }

        protected MatlabProcessingException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}