using System;
using VismaCodeChallenge.Interfaces;
using VismaCodeChallenge.Models;

namespace VismaCodeChallenge.Services
{
    /// <summary>
    /// HouseLoanCalculatorService abstracts the complexity of the House Loan calculation
    /// By default as per requirement it has an interest rate of 3.5% but it can be overriden by using the overload constructor with any interest rate for special offers or any other conditions
    /// </summary>
    public class HouseLoanCalculatorService : IHouseLoanCalculatorService
    {
        private readonly double _interestRate;

        public HouseLoanCalculatorService()
        {
            _interestRate = 3.5;
        }

        public HouseLoanCalculatorService(double interestRate)
        {
            _interestRate = interestRate;
        }

        /// <summary>
        /// Calculate takes the input from the customer and orchestrates the calculation for an House Loan returning a Monthly Payment Summary to the customer
        /// </summary>
        /// <param name="loanAmountInEur"></param>
        /// <param name="paybackTimeInYears"></param>
        /// <returns></returns>
        public MonthlyRepaymentSummary Calculate(LoanCalculationInput loanCalculationInput)
        {
            var houseLoanCalculator = new HouseLoan(loanCalculationInput, _interestRate);

            houseLoanCalculator.PaymentScheme.CalculateCost();

            return new MonthlyRepaymentSummary(houseLoanCalculator.PaymentScheme);
        }
    }
}

