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
            if (amount.IsValid<Decimal>() && amount.InValidRange(1000, 500000.0))
            {
                Amount = amount;
            }

            if (paybackTimeInYears.IsValid<byte>() && paybackTimeInYears.InValidRange(1, 35))
            {
                PaybackTimeInYears = paybackTimeInYears;
            }
        }

        public decimal Amount { get; }
        public byte PaybackTimeInYears { get; }
        public bool IsValid => Amount != 0 && PaybackTimeInYears != 0;
    }
}

