using Microsoft.AspNetCore.Mvc;
using VismaCodeChallenge.Interfaces;
using VismaCodeChallenge.Models;

namespace VismaCodeChallenge.Controllers;


[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MonthlyRepaymentSummary))]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class CalculateController : ControllerBase
{
    private readonly ILogger<CalculateController> _logger;
    private readonly IHouseLoanCalculatorService _houseLoanCalculatorService;

    public CalculateController(ILogger<CalculateController> logger, IHouseLoanCalculatorService houseLoanCalculatorService)
    {
        _logger = logger;
        _houseLoanCalculatorService = houseLoanCalculatorService;
    }

    [HttpPost]
    public IActionResult CalculateHouseLoan([FromBody] LoanCalculationInput loanCalculationInput)
    {
        if (!loanCalculationInput.IsValid)
        {
            _logger.LogError("Error - Bad Data was sent, Loan Calculation Input was invalid!");

            return BadRequest();
        }

        MonthlyRepaymentSummary? result = null;

        try
        {
            result = _houseLoanCalculatorService.Calculate(loanCalculationInput);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error: {ex.Message}");
            return StatusCode(500);
        }

        return Ok(result);
    }
}

