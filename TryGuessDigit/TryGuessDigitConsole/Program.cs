// See https://aka.ms/new-console-template for more information
using TryGuessDigitConsole;
using TryGuessDigitConsole.Exceptions;
using TryGuessDigitConsole.Services;

Console.WriteLine("Hello, World!");
var settings = AppSettingsBuilder.GetAppSettings();
var validator = new GuessValidator();
var generator = new DigitGenerator(settings, validator);
bool needToGuess = false;

do
{
    try
    {
        Console.WriteLine("Let's guess the digit");
        Console.WriteLine("[ Rules: digit in range from {0} to {1}. Attempts count is {2} ]",
            settings.RangeStartItem, settings.RangeEndItem, generator.LeftGuessAttempts);

        Console.Write("Please input digit: ");
        var tryGuessDigit = Convert.ToInt32(Console.ReadLine()); // проверка на диапазон и формат
        var result = generator.TryGuess(tryGuessDigit);

        // Получаем подсказку (больше или меньше число загаданного
        Console.WriteLine("------");
        Console.WriteLine("Guess Result: " + generator.GetGuessState(tryGuessDigit));
        needToGuess = !result;
    }
    catch (FormatException ex)
    {
        Console.WriteLine("------");
        Console.WriteLine("Invalid digit input. Message: {0}", ex.Message);
        needToGuess = true;
    }
    catch (InvalidValidationStateException ex)
    {
        Console.WriteLine("------");
        Console.WriteLine("Can't validate your input: {0}, Message: {1}", ex.ValueToGuess, ex.Message);
    }
    catch (AttemptsException ex)
    {
        Console.WriteLine("------");
        Console.WriteLine("Last guess result: {0}", ex.LastGuessResult);
        Console.WriteLine("Message: {0}", ex.Message);
        Console.WriteLine("GAME OVER");
        needToGuess = false;
    }
}
while (needToGuess);