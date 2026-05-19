using CurrencyConverter.Web.Core.Interfaces;
using CurrencyConverter.Web.Infrastructure.Adapters;
using CurrencyConverter.Web.UI;
using CurrencyConverter.Web.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var currencyConverterServiceAPI = builder.Configuration["CurrencyConverterServiceAPIBase"] ?? throw new InvalidOperationException("CurrencyConverterServiceAPIBase configuration is missing.");
builder.Services.AddHttpClient<IExchangeRateProvider, FawazAhmedExchangeAdapter>(client =>
{
    client.BaseAddress = new Uri(currencyConverterServiceAPI);
});

var prettyPrintServiceAPI = builder.Configuration["PrettyPrintServiceAPI"] ?? throw new InvalidOperationException("PrettyPrintServiceAPI configuration is missing.");
builder.Services.AddHttpClient<ICurrencyNameProvider, FawazAhmedNameAdapter>(client =>
{
    client.BaseAddress = new Uri(prettyPrintServiceAPI);
});

builder.Services.AddScoped<IPrettyPrintService, PrettyPrintService>();
builder.Services.AddScoped<ICurrencyConverterService, CurrencyConverterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
//app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
