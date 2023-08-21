using System.Diagnostics.Metrics;
using TryGuessDigitConsole.Exceptions;

namespace TryGuessDigitConsole.Services
{
    public class DigitGenerator
    {
        private readonly int _digitForGuess;

        private readonly int _rangeStartItem;

        private readonly int _rangeEndItem;

        private readonly int _guessTimesCount;

        private int _guessTime;

        private readonly GuessValidator _validator;

        public int GuessTime { get => _guessTime; }

        public int LeftGuessAttempts
        {
            get
            {
                var leftAttempts = _guessTimesCount - _guessTime;
                return leftAttempts > 0 ? leftAttempts : 0;
            }
        }

        public DigitGenerator(AppSettings settings, GuessValidator validator)
        {
            var rnd = new Random();
            _guessTimesCount = settings.GuessTimesCount;
            _rangeStartItem = settings.RangeStartItem;
            _rangeEndItem = settings.RangeEndItem;

            _digitForGuess = rnd.Next(settings.RangeStartItem, settings.RangeEndItem);

            _validator = validator;
        }

        public bool TryGuess(int val)
        {
            var guessResult = _digitForGuess == val;
            _guessTime++;

            return guessResult;
        }

        public string GetGuessState(int val)
        {
            string? lastGuessResult = _validator.GetValidateStatus(val, _digitForGuess, _rangeStartItem, _rangeEndItem);

            if (_guessTime > _guessTimesCount)
            {
                throw new AttemptsException(lastGuessResult, "No more attempts");
            }

            return lastGuessResult;
        }
    }
}
