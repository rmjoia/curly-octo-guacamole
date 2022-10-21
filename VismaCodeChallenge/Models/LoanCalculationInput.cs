using System;
using VismaCodeChallenge.Validators;

namespace VismaCodeChallenge.Models
{
    /// <summary>
    /// LoanCalculatorInput - ViewModel gets the user input, holds the sanitization and validation logic before sending to the business layer
    /// </summary>
    public class LoanCalculationInput
    {
        public LoanCalculationInput(decimal amount, byte paybackTimeInYears)
        {
            if (InputValidator.IsValid<decimal>(amount))
            {
                Amount = amount;
            }

            if (InputValidator.IsValid<byte>(paybackTimeInYears))
            {
                PaybackTimeInYears = paybackTimeInYears;
            }
        }

        public decimal Amount { get; }
        public byte PaybackTimeInYears { get; }
    }
}

