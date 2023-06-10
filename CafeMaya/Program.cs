using Blazored.Toast;
using CafeMaya.Models;
using CafeMaya.Services;
using CafeMaya.Services.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using CafeMaya.Hubs;

var builder = WebApplication.CreateBuilder(args);
var connStrings = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
});
builder.Services.AddDbContextFactory<OrderDataProvider>(opt =>
    opt.UseSqlServer(connStrings["Default"]));
builder.Services.AddTransient<IValidator<Order>, OrderValidator>();
var app = builder.Build();
app.UseResponseCompression();
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<NotificationHub>("/notificationhub");
app.MapFallbackToPage("/_Host");

app.Run();
