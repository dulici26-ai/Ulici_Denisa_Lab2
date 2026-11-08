using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Ulici_Denisa_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Ulici_Denisa_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Ulici_Denisa_Lab2Context' not found.");

builder.Services.AddRazorPages();
builder.Services.AddDbContext<Ulici_Denisa_Lab2Context>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LibraryIdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<Microsoft.AspNetCore.Identity.UI.Services.IEmailSender, EmailSender>();

// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
public class EmailSender : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
}
