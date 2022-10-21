namespace VismaCodeChallenge.Models
{

    public interface IPaymentScheme
    {
        public void CalculateCost();
        public IEnumerable<MonthlyPlan> RepaymentMonthlyPlan { get; }
    }
}