using System.Net.NetworkInformation;
using System;
using System.Buffers;
using System.Collections.Immutable;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Ikigai.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

//using Ikigai.Data.Helper.Seguridad;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString =
    builder.Configuration.GetConnectionString("MariaDb")
    ?? throw new InvalidOperationException("Connection string 'MariaDb' not found.");
builder.Services.AddDbContext<IkigaiDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder
    .Services.AddDefaultIdentity<IdentityUser>(
        options => options.SignIn.RequireConfirmedAccount = true
    )
    .AddEntityFrameworkStores<IkigaiDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "RequireAdminOrStaff",
        policy => policy.RequireRole("Administrador", "Staff")
    );
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly=true;
        options.ExpireTimeSpan=TimeSpan.FromMinutes(60);
        // using Microsoft.AspNetCore.Http;
        options.LoginPath = new PathString("/Account/Login");
        options.LogoutPath = new PathString("/Account/Logout");
        options.AccessDeniedPath = new PathString("/Account/AccessDenied");

        options.ReturnUrlParameter = "ReturnUrl";

        // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-3.1#react-to-back-end-changes                    
        // options.EventsType = typeof(CustomCookieAuthenticationEvents);
    });

//CONFIGURAR SERVICIOS A UTILIZAR
builder.Services.AddTransient<IUserHelp, UserHelp>();


var app = builder.Build();

using (var ambiente = app.Services.CreateScope())
{
    var services = ambiente.ServiceProvider;
    try
    {
        //var _userManager=services.GetRequiredService<UserManager<Usuario>>();
        var context = services.GetRequiredService<IkigaiDbContext>();
        context.Database.Migrate();
        await Seed();
    }
    catch (Exception e)
    {
        var logging = services.GetRequiredService<ILogger<Program>>();
        logging.LogError(e, "Ocurrió un error en la migración");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
