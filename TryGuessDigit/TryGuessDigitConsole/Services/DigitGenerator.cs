namespace TryGuessDigitConsole.Services
{
    public class DigitGenerator
    {
        private readonly int _digitForGuess;

        private readonly int _guessTimesCount;

        private int _guessTime;

        public int GuessTime { get => _guessTime; }

        public int LeftGuessAttempts { get {
                var leftAttempts = _guessTimesCount - _guessTime;
                return leftAttempts > 0 ? leftAttempts : 0;
            }
        }

        public DigitGenerator(GeneratorSettings settings)
        {
            var rnd = new Random();
            _guessTimesCount = settings.GuessTimesCount;
            _digitForGuess = rnd.Next(settings.RangeStartItem, settings.RangeEndItem);
        }

        public bool TryGuess(int val)
        {
            if (_guessTime > _guessTimesCount)
            {
                throw new InvalidOperationException("No more attempts");
            }

            var guessResult = _digitForGuess == val;
            _guessTime++;

            return guessResult;
        }

        public string GetRangeGuessState(int val)
        {
            if (val < _digitForGuess)
            {
                return "your value lower than need";
            }

            if (val > _digitForGuess)
            {
                return "your value greater than need";
            }

            return "you guessed!";
        }
    }
}
