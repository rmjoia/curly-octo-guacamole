using System;
namespace VismaCodeChallenge.Models
{
    /// <summary>
    /// MonthlyPlan represents the repayment conditions for a given month of a year, each year will have 12 of these
    /// </summary>
    public class MonthlyPlan
    {
        public MonthlyPlan(int year, decimal monthlyAmount, decimal monthlyInterestRate)
        {
            Year = year;
            MonthlyTotalAmount = monthlyAmount;
            MonthlyInterestAmount = monthlyInterestRate;
        }

        public int Year { get; }
        public decimal MonthlyTotalAmount { get; }
        public decimal MonthlyInterestAmount { get; }
    }
}

