using Microsoft.EntityFrameworkCore;
using uwierzytelnianie;
using uwierzytelnianie.Data;
using Microsoft.AspNetCore.Identity;
using uwierzytelnianie.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("PeopleContextConnection");;

//builder.Services.AddDbContext<PeopleContext>(options =>
//    options.UseSqlServer(connectionString));;



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PeopleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PeopleDatabase")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PeopleContext>().AddDefaultUI().AddDefaultTokenProviders(); 
builder.Services.AddProjectService();

builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
app.UseAuthentication();;

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
