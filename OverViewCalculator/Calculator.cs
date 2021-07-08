using OverViewCalculator.DTOs;
using OverViewCalculator.Factory;

namespace OverViewCalculator
{

    public class Calculator : AbstractCalculation<OverviewQueryDto, OverviewResultDto>
    {
        public Calculator(IOverviewCalculatorFactory<OverviewQueryDto, OverviewResultDto> factory) :base(factory)
        {

        }
        public override OverviewResultDto CalculateOverView(OverviewQueryDto overviewQuery)
        {
            var monthlyPayment = _paymentCalculator.CalculatePayment(overviewQuery);
            var totalFee = _feeCalculator.CalculateFee(overviewQuery);
            var totalInterest = monthlyPayment * _interestCalculator.GetNumberOfPayment(overviewQuery) - overviewQuery.LoanAmount;
            var apr = _aPRCalculation.CalculateAPR(overviewQuery);
            return new OverviewResultDto()
            {
                MonthlyCost = monthlyPayment,
                TotalPaidFee = totalFee,
                EffectiveAPR = apr,
                TotalPaidInterest = totalInterest
            };
        }
    }
}
