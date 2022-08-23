using MudBlazor.Services;
using Traineeship.BasicTesting.Core.Interfaces.Repositories;
using Traineeship.BasicTesting.Core.Interfaces.Services;
using Traineeship.BasicTesting.Data.Repositories;
using Traineeship.BasicTesting.Data.Services;
using Traineeship_Testing.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddTransient<ICurrencyService, CurrencyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
