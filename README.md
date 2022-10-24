This project was bootstrapped with [Create React App](https://github.com/facebookincubator/create-react-app).
And uses the .Net 6 ASP.NET Core with React.Js Template.
It was developed in a x64 Mac box with intel processor but should work everywhere as .Net 6 is platform independent.

# Requirements
To run this solution you'll need the latest version of .Net 6 (LTS) and at least Node 16.
You can get .Net 6 from https://dotnet.microsoft.com/en-us/download/dotnet/6.0 and Node from https://nodejs.org/en/download/

# Get the project
Clone or download the zip file from the project or from the email.
If you're reading this, you probably already got it, but if you got it zipped and want to clone, the url is https://github.com/rmjoia/curly-octo-guacamole, I suppose you can ask access, It's a private repo.

# Run the project
You can run the following command `dotnet run --project VismaCodeChallenge` or if you navigate to the VismaCodeChallenge folder just by running `dotnet run`.

I've seen some scenarios where the npm packages weren't downloaded, in such case, you might have to navigate to VismaCodeChallenge/VismaCodeChallenge/ClientApp and run `npm install`.
Might be needed, but dotnet might do it for you...

I tried to use yarn, bud bad things happened, I won't advise.

# Testing and Automation
I wrote some unit tests as I was developing the back-end so I could test what I was doing and validate my assumptions.
I would like to write more and add more coverage but I stuck to the cover the most important parts.
I also wanted to add some automation on the front-end, but I opted to use react instead of Angular, and since I'm new to React, I feared I would take much longer to learn about testing and would be a week to deliver the code challenge, I had a lot of fun in the process and for that, I'm already thankful.

## Assumptions and shortcuts
I confess I don't know well this domain, I peeked some loan calculators online, and "stole" some text to make the ui as close and usable as possible.
The range picker is not the most user friendly and maybe I would oppose to use it in production as it makes harder to pick a specific value, but for a proof of concept where we don't need to be precise, it's easy and "fun" to test functionality rather then entering values manually.
I added some validation and sanitization to avoid failures, but might be some yet.
The repayment plan has a flaw, always assumes a full year, doesn't count from the current month, so it's always 12 months.
I wasn't too sure about the detail you wanted on the repayment plan, too much or too little, like, year, month of the year, fee without interest, interest, fee with interest, remaining loan, total etc... I kept it simple.
I used simple Dependency injection, simple logger to the console on two scenarios in the controller and used an API and React front-end because we talked about react.
Also, didn't go with MVC because since we talked about mobile apps and using legacy and other consumers, the future solution will probably be something like this or use some kind of interface like this.
I thought about scenarios to use Abstract classes instead of Interfaces, but I didn't think of a case where I wanted to implement default behavior as I didn't have two loans for instance, so I only used interfaces. I think I kept the abstractions generic enough so that other types of Loans can be created with the existing models and Payment Schemes.