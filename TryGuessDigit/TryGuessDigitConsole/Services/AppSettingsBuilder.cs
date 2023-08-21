using Microsoft.Extensions.Configuration;

namespace TryGuessDigitConsole.Services
{
    public static class AppSettingsBuilder
    {
        public static void BuildConfig(IConfigurationBuilder builder)
        {
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
        }
    }
}
