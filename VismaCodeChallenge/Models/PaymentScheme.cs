using System;

namespace VismaCodeChallenge.Models
{
    /// <summary>
    /// This class is responsible for generating the Payment Scheme for the customer for a any loan given it's provided the amount, interest rate and the payback time in Years.
    /// It generates a Monthly Repayment Plan so that the user can plan and organize the best way to repay the loan back.
    /// </summary>
    public class PaymentScheme: IPaymentScheme
    {
        private readonly decimal _amount;

        private readonly double _interestRate;

        private readonly byte _paybackTimeInYears;

        public PaymentScheme(LoanCalculationInput loanCalculationInput, double interestRate)
        {
            _amount = loanCalculationInput.Amount;
            _paybackTimeInYears =loanCalculationInput.PaybackTimeInYears;
            _interestRate = interestRate;
            RepaymentMonthlyPlan = Enumerable.Empty<MonthlyPlan>();
        }

        public IEnumerable<MonthlyPlan> RepaymentMonthlyPlan { get; private set; }

        /// <summary>
        /// Calculates the cost of the loan and generates the Monthly repaymet plan by using the data provided by the customer such as the
        /// payback time in years converting to months; the loan amount and calculating the interest rate applicable to the loan type.
        /// </summary>
        public void CalculateCost()
        {
            var paybackTimeInMonths = _paybackTimeInYears * 12;

            var monthlyLoanFee = Math.Round((_amount / paybackTimeInMonths), MidpointRounding.ToEven);
            var monthlyLoanInterest = monthlyLoanFee * ((decimal)_interestRate / 100);

            GenerateMonthlyRepaymentPlan(paybackTimeInMonths, monthlyLoanFee, monthlyLoanInterest);
        }

        /// <summary>
        /// Generates the Monthly Repayment plan so that the customer can see how much they're going to pay for each month
        /// Each year a break down of amount of loan and interest to pay
        /// </summary>
        /// <param name="paybackTimeInMonths"></param>
        /// <param name="monthlyLoanFee"></param>
        /// <param name="monthlyLoanInterest"></param>
        private void GenerateMonthlyRepaymentPlan(int paybackTimeInMonths, decimal monthlyLoanFee, decimal monthlyLoanInterest)
        {
            var monthlyRepaymentPlan = new List<MonthlyPlan>();

            for (int i = 1; i <= _paybackTimeInYears; i++)
            {
                for (int j = 1; j <= paybackTimeInMonths; j++)
                {
                    monthlyRepaymentPlan.Add(new MonthlyPlan(i, monthlyLoanFee, monthlyLoanInterest));
                    if(j == 12)
                    {
                        break;
                    }
                }
            }

            RepaymentMonthlyPlan = monthlyRepaymentPlan;
        }
    }
}

