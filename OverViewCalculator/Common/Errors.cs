using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OverViewCalculator.Common
{
    public static class Errors
    {
        public const string INVALID_LOAN_AMOUNT = "The loan amount cannot be zero or negative";
        public const string INVALID_QUERY_OBJECT = "The loan request is not properly defined";
        public const string INVALID_LOAN_DURATION = "The loan duration should be defined";
    }

    public static class Util 
    {
        public static double ConvertToPercentage(double number) 
        {
            return number / 100;
        }
    }
}
