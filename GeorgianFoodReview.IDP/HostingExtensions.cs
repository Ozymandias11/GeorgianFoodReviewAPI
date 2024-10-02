using GeorgianFoodReview.IDP.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace GeorgianFoodReview.IDP;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddRazorPages();

        var migrationsAssembly = typeof(HostingExtensions).Assembly.GetName().Name;
        var connectionString = builder.Configuration.GetConnectionString("sqlConnection");

        builder.Services.AddDbContext<UserContext>(options => options
                          .UseSqlServer(connectionString));

        builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<UserContext>()
            .AddDefaultTokenProviders();


        builder.Services.AddIdentityServer(options =>
        {
            options.EmitStaticAudienceClaim = true;
        })
        .AddConfigurationStore(options =>
        {
            options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                sql => sql.MigrationsAssembly(migrationsAssembly));
        })
        .AddOperationalStore(options =>
        {
            options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                sql => sql.MigrationsAssembly(migrationsAssembly));
        })
        .AddAspNetIdentity<User>();

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();


        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
