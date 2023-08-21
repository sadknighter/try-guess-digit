namespace TryGuessDigitConsole.Interfaces
{
    public interface IDigitGenerator
    {
        int GuessTime { get; }
        int LeftGuessAttempts { get; }

        string GetGuessState(int val);
        bool TryGuess(int val);
    }
}