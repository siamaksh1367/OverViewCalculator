using OverViewCalculator.Common;
using OverViewCalculator.DTOs;
using System;

namespace OverViewCalculator.Interest
{
    public class MonthlyInterestRateCalculator : IInterestRateCalculator<OverviewQueryDto>
    {
        private int _numberFoMonthsInAYear = 12;
        public double CalculateInterestRate(OverviewQueryDto overviewQuery)
        {
            if (overviewQuery == null)
                throw new ArgumentNullException(Errors.INVALID_QUERY_OBJECT);

            if (overviewQuery.LoanAmount <= 0)
                throw new ArgumentException(Errors.INVALID_LOAN_AMOUNT);
            
            return Util.ConvertToPercentage( overviewQuery.AnnualInterestRate)/_numberFoMonthsInAYear;
        }

        public int GetNumberOfPayment(OverviewQueryDto overviewQuery)
        {
            if (overviewQuery == null)
                throw new ArgumentNullException(Errors.INVALID_QUERY_OBJECT);

            if (overviewQuery.DurationOfLoanYear == 0)
                throw new ArgumentNullException(Errors.INVALID_LOAN_DURATION);

            return overviewQuery.DurationOfLoanYear * _numberFoMonthsInAYear;
        }
    }
}
