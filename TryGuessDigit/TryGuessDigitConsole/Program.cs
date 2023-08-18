// See https://aka.ms/new-console-template for more information
using TryGuessDigitConsole;
using TryGuessDigitConsole.Services;

Console.WriteLine("Hello, World!");
var settings = new GeneratorSettings();
var generator = new DigitGenerator(settings);
var needToGuess = true;
do
{
    try
    {
        Console.WriteLine("Let's guess the digit");
        Console.WriteLine("[ Rules: digit in range from {0} to {1}. Attempts count is {2} ]",
            settings.RangeStartItem, settings.RangeEndItem, generator.LeftGuessAttempts);
        Console.Write("Please input digit:");
        var tryGuessDigit = Convert.ToInt32(Console.ReadLine()); // проверка на диапазон и формат
        var result = generator.TryGuess(tryGuessDigit);
        Console.WriteLine("Guess Result:" + generator.GetRangeGuessState(tryGuessDigit));
        needToGuess = !result;
    } catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("GAME OVER");
        needToGuess = false;
    }
}
while (needToGuess);