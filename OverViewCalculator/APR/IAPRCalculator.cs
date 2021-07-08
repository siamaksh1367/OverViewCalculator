using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverViewCalculator.APR
{
    public interface IAPRCalculator<T>
    {
        double CalculateAPR(T t);
    }
}
