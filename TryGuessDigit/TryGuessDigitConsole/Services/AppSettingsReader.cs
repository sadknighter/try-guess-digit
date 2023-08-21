using Microsoft.Extensions.Configuration;

namespace TryGuessDigitConsole.Services
{
    public class AppSettingsReader
    {
        private const string GUESS_TIMES_COUNT = "GuessTimesCount";
        private const string RANGE_START_ITEM = "RangeStartItem";
        private const string RANGE_END_ITEM = "RangeEndItem";

        private readonly IConfiguration _configuration;

        public AppSettingsReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppSettings GetAppSettings()
        {
            var guessTimesCount = Convert.ToInt32(_configuration[GUESS_TIMES_COUNT]);
            var rangeStartItem = Convert.ToInt32(_configuration[RANGE_START_ITEM]);
            var rangeEndItem = Convert.ToInt32(_configuration[RANGE_END_ITEM]);

            return new AppSettings(guessTimesCount, rangeStartItem, rangeEndItem);
        }
    }
}
