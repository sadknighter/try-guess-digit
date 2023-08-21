namespace TryGuessDigitConsole.Interfaces
{
    public interface IGuessValidator
    {
        string GetValidateStatus(int val, int digitForGuess, int rangeStart, int rangeEnd);
    }
}