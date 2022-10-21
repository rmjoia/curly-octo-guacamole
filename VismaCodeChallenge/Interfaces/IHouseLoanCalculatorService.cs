using System;
using VismaCodeChallenge.Models;

namespace VismaCodeChallenge.Interfaces
{
    public interface IHouseLoanCalculatorService
    {
        public MonthlyRepaymentSummary Calculate(LoanCalculationInput loanCalculationInput);
    }
}

