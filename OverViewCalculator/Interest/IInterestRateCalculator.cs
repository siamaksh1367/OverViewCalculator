namespace OverViewCalculator.Interest
{
    public interface IInterestRateCalculator<T>
    {
        double CalculateInterestRate(T t);

        int GetNumberOfPayment(T t);
    }
}
