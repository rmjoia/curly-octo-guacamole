using VismaCodeChallenge.Models;
using VismaCodeChallenge.Services;
using VismaCodeChallenge.Validators;

namespace VismaCodeChallengeTests;

public class InputValidatorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IsValid_Validates_Decimal_Values()
    {
        //  Arrange
        var expectedResult = 1200m;

        //  Act
        var loanCalculationInput = new LoanCalculationInput(1200, 1);

        //  Assert
        Assert.That(loanCalculationInput.Amount, Is.EqualTo(expectedResult));
    }

    [Test]
    public void IsValid_Validates_byte_Values()
    {
        //  Arrange
        var expectedResult = 25;

        //  Act
        var loanCalculationInput = new LoanCalculationInput(1200, 25);

        //  Assert
        Assert.That(loanCalculationInput.PaybackTimeInYears, Is.EqualTo(expectedResult));
    }
}

