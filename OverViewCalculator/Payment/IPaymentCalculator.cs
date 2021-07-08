using OverViewCalculator.Interest;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverViewCalculator.Payment
{
    public interface IPaymentCalculator<T>
    {
        double CalculatePayment(T t);
    }
}
