using TryGuessDigitConsole.Exceptions;

namespace TryGuessDigitConsole.Services
{
    public class GuessValidator
    {
        public string GetValidateStatus(int val, int digitForGuess, int rangeStart, int rangeEnd)
        {
            string? lastGuessResult;

            if (val == digitForGuess)
            {
                lastGuessResult = "You guessed";
            }
            else if (val < rangeStart || val > rangeEnd)
            {
                lastGuessResult = "Your digit is out of guess diapason";
            }
            else if (val < digitForGuess)
            {
                lastGuessResult = "Your value lower than need";
            }
            else if (val > digitForGuess)
            {
                lastGuessResult = "Your value greater than need";
            }
            else
            {
               throw new InvalidValidationStateException(val, "Can't check digit state for guess");
            }

            return lastGuessResult;
        }
    }
}
