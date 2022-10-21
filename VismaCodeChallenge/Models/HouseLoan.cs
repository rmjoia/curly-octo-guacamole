using System;
namespace VismaCodeChallenge.Models
{
    public class HouseLoan: ILoan
    {
        public HouseLoan(LoanCalculationInput loanCalculationInput, double interest_rate)
        {
            Id = Guid.NewGuid();
            PaymentScheme = new PaymentScheme(loanCalculationInput, interest_rate);
        }

        public Guid Id { get; }

        public IPaymentScheme PaymentScheme { get; }
    }
}

