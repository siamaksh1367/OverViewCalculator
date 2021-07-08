using OverViewCalculator.APR;
using OverViewCalculator.Fee;
using OverViewCalculator.Interest;
using OverViewCalculator.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverViewCalculator.Factory
{
    public interface IOverviewCalculatorFactory<Q,R>
    {
        IPaymentCalculator<Q> PaymentCalculatorFactory();
        IInterestRateCalculator<Q> InterestRateCalculatorFactory();
        IFeeCalculator<Q> FeeCalculatorFactory();
        IAPRCalculator<Q> APRCalculatorFactory();
    }
}
