﻿using VismaCodeChallenge.Interfaces;
using VismaCodeChallenge.Services;
using VismaCodeChallenge.Validators;

var builder = WebApplication.CreateBuilder(args);

//  Logging to the console for this sandbox app
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// DI / IoC
builder.Services.AddTransient<IHouseLoanCalculatorService, HouseLoanCalculatorService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();

