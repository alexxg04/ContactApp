using ContactApp.Data;
using ContactApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ContactApp.Services;
using ContactApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using ContactApp.Helpers;



        var builder = WebApplication.CreateBuilder(args);

        //var connectionString = builder.Configuration.GetSection("pgSettings")["pgConnection"];
        var connectionString = ConnectionHelper.GetConnectionString(builder.Configuration);
        

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();

        //custom services
        builder.Services.AddScoped<IImageService, ImageService>();
        builder.Services.AddScoped<IAddressBookService, AddressBookService>();
        builder.Services.AddScoped<IEmailSender, EmailService>();

        builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

        var app = builder.Build();

        var scope = app.Services.CreateScope();
        await DataHelper.ManageDataAsync(scope.ServiceProvider);

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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
//Updated