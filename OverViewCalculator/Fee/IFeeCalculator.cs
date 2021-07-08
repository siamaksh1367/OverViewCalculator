namespace OverViewCalculator.Fee
{
    public interface IFeeCalculator<T>
    {
        double CalculateFee(T t);
    }
}
