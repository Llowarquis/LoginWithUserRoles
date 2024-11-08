using LoginWithUserRoles.Components;
using LoginWithUserRoles.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

// Adding authentication service
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(o =>
	{
		o.Cookie.Name = "auth_token";
		o.LoginPath = "/login";
		o.Cookie.MaxAge = TimeSpan.FromMinutes(30);
		o.AccessDeniedPath = "/access-denied";
	});
builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();

// Getting DbConnection
var DbConnection = builder.Configuration.GetConnectionString("DbConnection");

// Injecting ConnectionString
builder.Services.AddDbContext<Contexto>(o =>
	o.UseSqlServer(DbConnection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Middlewares
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
