namespace TryGuessDigitConsole.Exceptions
{
    public class InvalidValidationStateException : Exception
    {
        public int ValueToGuess { get => _valueToGuess; }

        private readonly int _valueToGuess;
        public InvalidValidationStateException(int val, string message) 
            : base(message) 
        {
            _valueToGuess = val;
        }
    }
}
