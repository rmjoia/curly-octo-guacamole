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
    public void IsValid_Returns_True_When_byte_Value()
    {
        //  Arrange
        byte paybackTimeInYears = 25;

        //  Act
        var result = paybackTimeInYears.IsValid<byte>();

        //  Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsValid_Returns_False_When_Not_byte_Value()
    {
        //  Arrange
        var paybackTimeInYears = 25;

        //  Act
        var result = paybackTimeInYears.IsValid<Decimal>();

        //  Assert
        Assert.That(result, Is.False);
    }


    [TestCase(1, 1, 35, true)]
    [TestCase(35, 1, 35, true)]
    [TestCase(36, 1, 35, false)]
    [TestCase(35.1, 1, 35, false)]
    [TestCase(0, 1, 35, false)]
    [TestCase(-2, 1, 35, false)]
    [TestCase(0, 1, 1000, false)]
    [TestCase(-100, 1, 1000, false)]
    [TestCase(1000, 1, 1000, true)]
    [TestCase(1000.00001, 1, 1000, false)]
    public void LoanAmount_InRange_Validates_Value_In_Range(object value, double min, double max, bool expectedResult)
    {
        //  Arrange
        //  Act
        var result = value.InValidRange(min, max);

        //  Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}

