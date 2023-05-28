using CafeMaya.Models;
using CafeMaya.Services;
using CafeMaya.Services.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connStrings = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<OrderDataProvider>(opt =>
    opt.UseSqlServer(connStrings["Default"]));
builder.Services.AddTransient<IValidator<Order>, OrderValidator>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
