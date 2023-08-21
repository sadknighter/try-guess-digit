namespace TryGuessDigitConsole
{
    public class AppSettings
    {
        public int GuessTimesCount { get => _guessTimesCount;  }
        public int RangeStartItem { get => _rangeStartItem; }
        public int RangeEndItem { get => _rangeEndItem; }

        private readonly int _guessTimesCount;
        private readonly int _rangeStartItem;
        private readonly int _rangeEndItem;

        public AppSettings(int guessTimesCount, int rangeStartItem, int rangeEndItem) 
        {
            _guessTimesCount = guessTimesCount;
            _rangeStartItem = rangeStartItem;
            _rangeEndItem = rangeEndItem;
        }
    }
}
