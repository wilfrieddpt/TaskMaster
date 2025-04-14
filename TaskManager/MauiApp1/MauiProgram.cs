using MauiApp1.Data;
using MauiApp1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });



            // Chaîne de connexion MySQL (modifie selon ta config locale phpMyAdmin)
            var connectionString = "server=localhost;user=root;database=taskmasterdb";

            // Enregistre AppDbContext avec EF Core + MySQL
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Enregistre le service de gestion des tâches
            builder.Services.AddTransient<TacheService>();

            // Crée la base de données si elle n'existe pas
            using var scope = builder.Services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();


#if DEBUG
            builder.Logging.AddDebug();
#endif



            return builder.Build();
        }
    }
}
