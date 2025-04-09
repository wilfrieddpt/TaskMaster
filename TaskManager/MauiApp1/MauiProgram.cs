using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MauiApp1.Data;
using MauiApp1.Services;


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


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Enregistrer TacheService pour l'injection de dépendances
            builder.Services.AddSingleton<TacheService>();

            return builder.Build();
        }
    }
}
