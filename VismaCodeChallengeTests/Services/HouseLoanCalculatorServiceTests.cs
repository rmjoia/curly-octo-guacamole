using VismaCodeChallenge.Models;
using VismaCodeChallenge.Services;

namespace VismaCodeChallengeTests;

public class HouseLoanCalculatorServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(160000, 25, 552)]
    [TestCase(220000, 15, 1265)]
    [TestCase(500000, 30, 1438)]
    public void CalculateCosts_Returns_MonthlyFeeWithInterests_WithDefaultInterestRate(decimal loanAmountInEur, byte paybackTimeInYears, decimal expectedResult)
    {
        //  Arrange
        var houseLoanCalculatorService = new HouseLoanCalculatorService();

        //  Act
        var monthlyRepaymentSummary = houseLoanCalculatorService.Calculate(new LoanCalculationInput(loanAmountInEur, paybackTimeInYears));

        //  Assert
        Assert.That(monthlyRepaymentSummary.LoanMonthlyFee, Is.EqualTo(expectedResult));
    }

    [TestCase(1200, 1, 0, 100)]
    [TestCase(12000, 2, 0, 500)]
    [TestCase(50000, 5, 0, 833)]
    [TestCase(1200, 1, 2, 102)]
    [TestCase(12000, 2, 7, 535)]
    [TestCase(50000, 5, 5, 875)]
    public void CalculateCosts_Returns_MonthlyFeeWithInterests_WithCustomInterestRate(decimal loanAmountInEur, byte paybackTimeInYears, double interest_rate, decimal expectedResult)
    {
        //  Arrange
        var houseLoanCalculatorService = new HouseLoanCalculatorService(interest_rate);

        //  Act
        var monthlyRepaymentSummary = houseLoanCalculatorService.Calculate(new LoanCalculationInput(loanAmountInEur, paybackTimeInYears));

        //  Assert
        Assert.That(monthlyRepaymentSummary.LoanMonthlyFee, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CalculateCosts_Generates_RepaymentsMonthlyPlan_For_One_Year()
    {
        //  Arrange
        const byte paybackTimeInYears = 1;
        const decimal loanAmountInEur = 1200;

        var houseLoanCalculatorService = new HouseLoanCalculatorService(0);

        //  Act
        var monthlyRepaymentSummary = houseLoanCalculatorService.Calculate(new LoanCalculationInput(loanAmountInEur, paybackTimeInYears));

        //  Assert
        Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.FirstOrDefault(), Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.FirstOrDefault().Year, Is.EqualTo(1));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.FirstOrDefault().MonthlyInterestAmount, Is.EqualTo(0));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.FirstOrDefault().MonthlyTotalAmount, Is.EqualTo(100));
        });

        Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(11), Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(11).Year, Is.EqualTo(1));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(11).MonthlyInterestAmount, Is.EqualTo(0));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(11).MonthlyTotalAmount, Is.EqualTo(100));
        });
    }

    [Test]
    public void CalculateCosts_Generates_RepaymentsMonthlyPlan_For_TwentyFive_Years()
    {
        //  Arrange
        const byte paybackTimeInYears = 25;
        const decimal loanAmountInEur = 160000;

        var houseLoanCalculatorService = new HouseLoanCalculatorService();

        //  Act
        var monthlyRepaymentSummary = houseLoanCalculatorService.Calculate(new LoanCalculationInput(loanAmountInEur, paybackTimeInYears));

        //  Assert
        Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.FirstOrDefault(), Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.FirstOrDefault().Year, Is.EqualTo(1));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.FirstOrDefault().MonthlyInterestAmount, Is.EqualTo(18.655m));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.FirstOrDefault().MonthlyTotalAmount, Is.EqualTo(533m));
        });

        Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(225), Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(225).Year, Is.EqualTo(19));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(225).MonthlyInterestAmount, Is.EqualTo(18.655m));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(225).MonthlyTotalAmount, Is.EqualTo(533m));
        });
        Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(299), Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(299).Year, Is.EqualTo(25));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(299).MonthlyInterestAmount, Is.EqualTo(18.655m));
            Assert.That(monthlyRepaymentSummary.MonthlyRepaymentPlan.ElementAt(299).MonthlyTotalAmount, Is.EqualTo(533m));
        });
    }
}
