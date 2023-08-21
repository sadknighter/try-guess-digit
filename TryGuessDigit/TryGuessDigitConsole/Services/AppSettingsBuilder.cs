using Microsoft.Extensions.Configuration;

namespace TryGuessDigitConsole.Services
{
    public static class AppSettingsBuilder
    {
        private static AppSettings? _appSettings;

        public static AppSettings GetAppSettings()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            var guessTimesCount = Convert.ToInt32(config["GuessTimesCount"]);
            var rangeStartItem = Convert.ToInt32(config["RangeStartItem"]);
            var rangeEndItem = Convert.ToInt32(config["RangeEndItem"]);

            _appSettings ??= new AppSettings(guessTimesCount, rangeStartItem, rangeEndItem);

            return _appSettings;
        }
    }
}
