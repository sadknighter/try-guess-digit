using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TryGuessDigitConsole.Exceptions;
using TryGuessDigitConsole.Interfaces;

namespace TryGuessDigitConsole.Services
{
    public class DigitGenerator : IDigitGenerator
    {
        private readonly ILogger<DigitGenerator> _logger;

        private readonly int _digitForGuess;

        private readonly int _rangeStartItem;

        private readonly int _rangeEndItem;

        private readonly int _guessTimesCount;

        private int _guessTime;

        private readonly IGuessValidator _validator;

        public int GuessTime { get => _guessTime; }

        public int LeftGuessAttempts
        {
            get
            {
                var leftAttempts = _guessTimesCount - _guessTime;
                return leftAttempts > 0 ? leftAttempts : 0;
            }
        }

        public DigitGenerator(IGuessValidator validator, ILogger<DigitGenerator> logger, IConfiguration configuration)
        {
            var rnd = new Random();
            var settings = new AppSettingsReader(configuration).GetAppSettings();
            _guessTimesCount = settings.GuessTimesCount;
            _rangeStartItem = settings.RangeStartItem;
            _rangeEndItem = settings.RangeEndItem;

            _digitForGuess = rnd.Next(settings.RangeStartItem, settings.RangeEndItem);

            _validator = validator;
            _logger = logger;
        }

        public bool TryGuess(int val)
        {
            var guessResult = _digitForGuess == val;
            _guessTime++;
            _logger.LogInformation("Tryied to guess digit", val);
            return guessResult;
        }

        public string GetGuessState(int val)
        {
            string? lastGuessResult = _validator.GetValidateStatus(val, _digitForGuess, _rangeStartItem, _rangeEndItem);

            if (_guessTime == _guessTimesCount)
            {
                _logger.LogWarning("Attempts ended");
                throw new AttemptsException(lastGuessResult, "No more attempts");
            }

            return lastGuessResult;
        }
    }
}
