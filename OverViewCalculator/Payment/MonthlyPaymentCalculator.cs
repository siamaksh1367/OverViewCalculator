using OverViewCalculator.Common;
using OverViewCalculator.DTOs;
using OverViewCalculator.Interest;
using System;

namespace OverViewCalculator.Payment
{
    public class MonthlyPaymentCalculator : IPaymentCalculator<OverviewQueryDto>
    {
        private readonly IInterestRateCalculator<OverviewQueryDto> _interestratecalculator;

        public MonthlyPaymentCalculator(IInterestRateCalculator<OverviewQueryDto> interestratecalculator)
        {
            this._interestratecalculator = interestratecalculator;
        }
        
        public double CalculatePayment(OverviewQueryDto overviewQuery)
        {

            if (overviewQuery == null)
                throw new ArgumentNullException(Errors.INVALID_QUERY_OBJECT);

            if (overviewQuery.LoanAmount <= 0)
                throw new ArgumentException(Errors.INVALID_LOAN_AMOUNT);

            var monthlyInterestRate = _interestratecalculator.CalculateInterestRate(overviewQuery);

            var firstclause = monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, _interestratecalculator.GetNumberOfPayment(overviewQuery));
            var secondClause =  Math.Pow(1 + monthlyInterestRate, _interestratecalculator.GetNumberOfPayment(overviewQuery))-1;

            //This data ic collected from the link https://www.bankrate.com/calculators/mortgages/mortgage-calculator.aspx
            return overviewQuery.LoanAmount * (double)(firstclause / secondClause);
        }
    }
}
