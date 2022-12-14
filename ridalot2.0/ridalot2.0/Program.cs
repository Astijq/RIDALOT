using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ridalot2._0.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ridalot2._0.Pages.PageSupport;
using Microsoft.AspNetCore.Mvc;
using ridalot2._0.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

// Google Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthentication().AddGoogle(options =>
{
    var Clientid = builder.Configuration["Google:ClientId"];
    options.ClientId = builder.Configuration["Google:ClientId"];
    options.ClientSecret = builder.Configuration["Google:ClientSecret"];
    options.ClaimActions.MapJsonKey("urn:google:profile", "link");
    options.ClaimActions.MapJsonKey("urn:google:image", "picture");
});
// Adds HttpContextAccessor Used to determine if a user is logged in and what their username is
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();
// Required for HttpClient support in the Blazor Client project
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();

// Read the connection string from the appsettings.json file
// Set the database connection for the EndtoEndContext
builder.Services.AddDbContext<ridalot2._0.Data.RIDALOT.RIDALOTContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DBService>();
builder.Services.AddScoped<PageService>();
builder.Services.AddScoped<FilterDimensions>();
builder.Services.AddScoped<CustomerMail>();
builder.Services.AddBlazorise(options => { options.Immediate = true; }).AddBootstrapProviders().AddFontAwesomeIcons();

var app = builder.Build();
//middleware after here


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseMiddleware<StatisticsMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
