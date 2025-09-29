using Microsoft.Extensions.Logging;

namespace Figma_zadanie_z_zadaniami
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
                    fonts.AddFont("Manrope-Bold.otf", "ManropeBold");
                    fonts.AddFont("Manrope-ExrtaBold.otf", "ManropeExtraBold");
                    fonts.AddFont("Manrope-Light.otf", "ManropeLight");
                    fonts.AddFont("Manrope-ExtraLight.otf", "ManropeExtraLight");
                    fonts.AddFont("Manrope-Medium.otf", "ManropeMedium");
                    fonts.AddFont("Manrope-Regular.otf", "ManropeRegular");
                    fonts.AddFont("Manrope-Semibold.otf", "ManropeSemiBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
