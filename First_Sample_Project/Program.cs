using First_Sample_Project.CustomFilters;
using First_Sample_Project.FileRepository;
using First_Sample_Project.FormsRepository;
using First_Sample_Project.Models;
using First_Sample_Project.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuthenticationRepository,AuthenticationRepository>();

builder.Services.AddDbContext<ApplicationUser>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Myconnection"))); 

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CustomAuthorizationFilterAttribute>();

builder.Services.AddScoped<IFileSystemRepository, FileSystemRepository>();

builder.Services.AddScoped<IHRFormsRepository, HRFormsRepository>();



builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout=TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly=true;
    options.Cookie.IsEssential=true;
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });


// Add NLog to the Dependency Injection container
builder.Services.AddLogging(loggingbuilder =>
{
    loggingbuilder.AddConsole();
    loggingbuilder.ClearProviders();
    loggingbuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    loggingbuilder.AddNLog();
    loggingbuilder.AddDebug();
    loggingbuilder.AddEventSourceLogger();
    loggingbuilder.AddDebug();
});


var app = builder.Build();

LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(),"NLog.config"));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseStatusCodePagesWithRedirects("/Error/StatusCodeResult?statuscode={0}");
    app.UseHsts();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseStatusCodePagesWithRedirects("/Error/StatusCodeResult?statuscode={0}");
    app.UseExceptionHandler("/Error/Exception");
}




app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");



app.Run();


