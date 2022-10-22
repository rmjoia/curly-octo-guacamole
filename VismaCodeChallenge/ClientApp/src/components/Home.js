import React, { Component } from 'react';

import { HouseLoanCalculator } from './HouseLoanCalculator';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
            <h1>Welcome to the Housing Loan Calculator</h1>
            
            <HouseLoanCalculator></HouseLoanCalculator>
      </div>
    );
  }
}
        