using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.Extensions.Logging;
using RATA.Shared.Services;
using RATA.ViewModel;
using RATA.Views;

namespace RATA
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<TenantsPage>();
            builder.Services.AddTransient<TenantsViewModel>();

            builder.Services.AddTransient<TenantDatabase>((tenant) =>
            {
                return new TenantDatabase(Path.Combine(FileSystem.AppDataDirectory, "SQLite001.db3"));
            });
            builder.Services.AddDbContext<TenantDatabase>();

            return builder.Build();
        }
    }
}
