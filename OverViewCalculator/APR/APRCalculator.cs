using OverViewCalculator.Common;
using OverViewCalculator.DTOs;
using OverViewCalculator.Fee;
using OverViewCalculator.Interest;
using System;
using System.Collections.Generic;

namespace OverViewCalculator.APR
{
    public class APRCalculator : IAPRCalculator<OverviewQueryDto>
    {

        private readonly IFeeCalculator<OverviewQueryDto> _feecalculator;

        public APRCalculator(IFeeCalculator<OverviewQueryDto> feecalculator)
        {
            this._feecalculator = feecalculator;
        }
        public double CalculateAPR(OverviewQueryDto overviewQuery)
        {
            if (overviewQuery == null)
                throw new ArgumentNullException(Errors.INVALID_QUERY_OBJECT);

            if (overviewQuery.LoanAmount == 0)
                throw new ArgumentException(Errors.INVALID_LOAN_AMOUNT);

            if (overviewQuery.DurationOfLoanYear== 0)
                throw new ArgumentException(Errors.INVALID_LOAN_DURATION);

            var fee = _feecalculator.CalculateFee(overviewQuery);
            var interest = overviewQuery.LoanAmount * (1 + overviewQuery.DurationOfLoanYear * Util.ConvertToPercentage( overviewQuery.AnnualInterestRate)) - overviewQuery.LoanAmount;
            var apr = ((interest + fee) / overviewQuery.LoanAmount)/overviewQuery.DurationOfLoanYear * 100;
            return apr;
        }
    }
}
