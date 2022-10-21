using System;
namespace VismaCodeChallenge.Models
{
    public interface ILoan
    {
        public IPaymentScheme PaymentScheme { get; }
    }
}

