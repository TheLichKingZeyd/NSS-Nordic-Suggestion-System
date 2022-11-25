using NordicDoorSuggestionSystem.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Repositories;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Hosting;

public class Program
{

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        // builder.Services.AddTransient<ISqlConnector, SqlConnector>();

        builder.Services.AddDbContext<DataContext>(options =>
        {            
            options.UseMySql(builder.Configuration.GetConnectionString("MariaDb"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDb")));   
        });
        
        builder.Services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();
        builder.Services.AddScoped<ITeamRepository, TeamRepository>();
        builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddTransient<ISqlConnector, SqlConnector>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Default Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequireNonAlphanumeric = false;            
        });

        builder.Services
            .AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
            options.AddPolicy("TeamLeder", policy => policy.RequireRole("Administrator"));
            options.AddPolicy("StandardBruker", policy => policy.RequireRole("Administrator"));
            options.AddPolicy("All", policy => policy.RequireRole("Administrator,Team Leder,Standard Bruker"));
            options.AddPolicy("Administrator/TeamLeder", policy => policy.RequireRole("Administrator,Team Leder"));
        });

        builder.Services.AddAuthentication(o =>
        {
            o.DefaultScheme = IdentityConstants.ApplicationScheme;
            o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            
        }).AddIdentityCookies(o => { });

        builder.Services.AddTransient<IEmailSender, AuthMessageSender>();

        builder.Services.AddRazorPages();
            //.AddRazorRuntimeCompilation();

        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.Migrate();
            }
            
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(name: "default", pattern: "{controller=Account}/{action=Login}/{id?}");
        Seed.SeedData(app);
        //Seed.SeedUsersAsync(app);
        app.MapControllers();


        app.Run();



    }
  
    public class AuthMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine(email);
            Console.WriteLine(subject);
            Console.WriteLine(htmlMessage);
            return Task.CompletedTask;
        }
    }
}
