using OverViewCalculator.APR;
using OverViewCalculator.Factory;
using OverViewCalculator.Fee;
using OverViewCalculator.Interest;
using OverViewCalculator.Payment;

namespace OverViewCalculator
{
    public abstract class AbstractCalculation<Q, R>
    {
        protected IFeeCalculator<Q> _feeCalculator { get; set; }
        protected IPaymentCalculator<Q> _paymentCalculator { get; set; }
        protected IInterestRateCalculator<Q> _interestCalculator { get; set; }
        protected IAPRCalculator<Q> _aPRCalculation { get; set; }
        public AbstractCalculation(IOverviewCalculatorFactory<Q, R> factory)
        {
            _feeCalculator = factory.FeeCalculatorFactory();
            _paymentCalculator = factory.PaymentCalculatorFactory();
            _interestCalculator = factory.InterestRateCalculatorFactory();
            _aPRCalculation = factory.APRCalculatorFactory();
        }
        public abstract R CalculateOverView(Q overviewQuery);

    }
}
