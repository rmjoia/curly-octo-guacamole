import axios from 'axios';
import React, { Component } from 'react';

export class HouseLoanCalculator extends Component {

  constructor(props) {
    super(props);

    this.onChangeLoanAmount = this.onChangeLoanAmount.bind(this);
    this.onChangePaybackTimeInYears = this.onChangePaybackTimeInYears.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      loanAmount: 0,
      paybackTimeInYears: 0,
      monthlyRepaymentSummary: null,
      loading: true
    };
  }

  onChangeLoanAmount(e) {
    this.setState({
      loanAmount: e.target.value
    });
  }

  onChangePaybackTimeInYears(e) {
    this.setState({
      paybackTimeInYears: e.target.value
    });
  }

  onSubmit(e) {
    e.preventDefault();

    let homeLoanInput = {
      amount: this.state.loanAmount,
      paybackTimeInYears: this.state.paybackTimeInYears
    }

    axios.post('calculate', homeLoanInput).then(result => {
      this.setState({
        monthlyRepaymentSummary: result.data
      });
    });
  }

  render() {
    return (
      <div className="container">
        <form onSubmit={this.onSubmit}>
          <div className="row align-items-center">
            <div className="col-8 mb-3">
              <label htmlFor="loanAmount" className="form-label">How much would you like to borrow?</label>
              <input type="range" className="form-range" value={this.state.loanAmount} onChange={this.onChangeLoanAmount} id="loanAmount" min="0" max="500000" />
              <div id="loanAmountHelp" className="form-text">Minimum borrowing amount is €1,000</div>
            </div>
            <div className="col-4">
              <h1 className='text-center'>{this.state.loanAmount}</h1>
            </div>
          </div>
          <div className="row align-items-center">
            <div className="col-8 mb-3">
              <label htmlFor="paybackTimeInYears" className="form-label">Over how many years would you like to repay your loan?</label>
              <input type="range" className="form-range" value={this.state.paybackTimeInYears} onChange={this.onChangePaybackTimeInYears} id="paybackTimeInYears" min="1" max="35" />
              <div id="paybackTimeInYearsHelp" className="form-text">Mortgages of up to 35 years are available to first-time buyers,
                Movers and Switchers.</div>
            </div>
            <div className="col-4">
              <h1 className='text-center'>{this.state.paybackTimeInYears}</h1>
            </div>
          </div>
          <div className="row justify-content-start">
            <div className="col-12">
              <button type="submit" className="btn btn-primary">Submit</button>
            </div>
          </div>
        </form>

        <div className="row justify-content-start">
          <div className="col-12">

            {

              this.state.monthlyRepaymentSummary == null ?
                '' :
                <div><p>Monthly Fee: {this.state.monthlyRepaymentSummary.loanMonthlyFee}</p>
                  <table className="table table-striped">
                    <thead>
                      <tr>
                        <th>Year</th>
                        <th>Monthly Fee</th>
                        <th>Monthly Interest</th>
                      </tr>
                    </thead>
                    <tbody>
                      {
                        this.state.monthlyRepaymentSummary.monthlyRepaymentPlan
                          .map(repayment => (
                            <tr key={Math.random()}>
                              <td>{repayment.year}</td>
                              <td>{repayment.monthlyTotalAmount}</td>
                              <td>{repayment.monthlyInterestAmount}</td>
                            </tr>
                          ))
                      }
                    </tbody>
                  </table>
                </div>
            }
          </div>
        </div>
      </div>
    );
  }
}
