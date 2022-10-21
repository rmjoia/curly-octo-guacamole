using System;
namespace VismaCodeChallenge.Models
{
    /// <summary>
    /// MonthlyRepaymentsSummary is a simple representation or report of the values the customer might want to see as a description of what to repay to the institution lending the money
    /// </summary>
    public class MonthlyRepaymentSummary
    {
        private readonly IPaymentScheme _paymentScheme;

        public MonthlyRepaymentSummary(IPaymentScheme paymentScheme)
        {
            _paymentScheme = paymentScheme;
        }

        public decimal LoanMonthlyFee
        {
            get
            {
                return Math.Round
                    (
                        (_paymentScheme.RepaymentMonthlyPlan?.FirstOrDefault()?.MonthlyTotalAmount +
                        _paymentScheme.RepaymentMonthlyPlan?.FirstOrDefault()?.MonthlyInterestAmount)
                        ?? 0.0m,
                        MidpointRounding.ToEven
                    );
            }
        }

        public IEnumerable<MonthlyPlan> MonthlyRepaymentPlan => _paymentScheme.RepaymentMonthlyPlan;
    }
}

