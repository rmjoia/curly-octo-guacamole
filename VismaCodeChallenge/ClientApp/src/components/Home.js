import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
            <h1>Welcome to the Housing Loan Calculator</h1>
            <div className="well">

                <form>
                    <div className="mb-3">
                        <label htmlFor="loanAmount" className="form-label">How much would you like to borrow?</label>
                        <input type="range" className="form-range" id="loanAmount" min="0" max="500000" />
                        <div id="loanAmountHelp" className="form-text">Minimum borrowing amount is €1,000</div>
                    </div>
                        <div className="mb-3">
                        <label htmlFor="paybackTimeInYears" className="form-label">Over how many years would you like to repay your loan?</label>
                        <input type="range" className="form-range" id="paybackTimeInYears" min="1" max="35"/>
                        <div id="paybackTimeInYearsHelp" className="form-text">Mortgages of up to 35 years are available to first-time buyers,
                            Movers and Switchers. Irrespective of whether you're a first-time buyer or a mover your mortgage term must not go past age 70</div>
                    </div>
                
                    <button type="submit" className="btn btn-primary">Submit</button>
                </form>

            </div>
      </div>
    );
  }
}
        