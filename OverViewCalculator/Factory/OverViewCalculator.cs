using OverViewCalculator.APR;
using OverViewCalculator.DTOs;
using OverViewCalculator.Fee;
using OverViewCalculator.Interest;
using OverViewCalculator.Payment;

namespace OverViewCalculator.Factory
{
    public class OverViewCalculator : IOverviewCalculatorFactory<OverviewQueryDto, OverviewResultDto>
    {
        private readonly IInterestRateCalculator<OverviewQueryDto> _monthlyInterestRateCalculator;
        private readonly IFeeCalculator<OverviewQueryDto> _feeCalculator;

        public OverViewCalculator()
        {
            _monthlyInterestRateCalculator = new MonthlyInterestRateCalculator();
            _feeCalculator = new AdministrationFeeCalculator();
        }

        public IAPRCalculator<OverviewQueryDto> APRCalculatorFactory()
        {
            return new APRCalculator(_feeCalculator);
        }

        public IFeeCalculator<OverviewQueryDto> FeeCalculatorFactory()
        {
            return _feeCalculator;
        }

        public IInterestRateCalculator<OverviewQueryDto> InterestRateCalculatorFactory()
        {
            return _monthlyInterestRateCalculator;
        }

        public IPaymentCalculator<OverviewQueryDto> PaymentCalculatorFactory()
        {
            return new MonthlyPaymentCalculator(_monthlyInterestRateCalculator);
        }
    }
}
