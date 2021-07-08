using OverViewCalculator.Common;
using OverViewCalculator.DTOs;
using System;

namespace OverViewCalculator.Fee
{
    public class AdministrationFeeCalculator : IFeeCalculator<OverviewQueryDto>
    {
        private const double _maxFixedFee=10000;
        
        public double CalculateFee(OverviewQueryDto overviewQuery)
        {
            if (overviewQuery ==null)
                throw new ArgumentNullException(Errors.INVALID_QUERY_OBJECT);

            if (overviewQuery.LoanAmount==0)
                throw new ArgumentException(Errors.INVALID_LOAN_AMOUNT);

            return Math.Min(overviewQuery.LoanAmount / 100, _maxFixedFee);
        }
    }
}
