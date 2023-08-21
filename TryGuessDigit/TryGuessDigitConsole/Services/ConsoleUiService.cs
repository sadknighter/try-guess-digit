using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TryGuessDigitConsole.Exceptions;
using TryGuessDigitConsole.Interfaces;

namespace TryGuessDigitConsole.Services
{
    public class ConsoleUiService : IConsoleUiService
    {
        private readonly ILogger<ConsoleUiService> _log;
        private readonly IConfiguration _config;
        private readonly AppSettings _settings;
        private readonly IDigitGenerator _generator;

        public ConsoleUiService(ILogger<ConsoleUiService> log, IConfiguration config, IDigitGenerator generator)
        {
            _log = log;
            _config = config;
            _settings = new AppSettingsReader(_config).GetAppSettings();
            _generator = generator;
        }

        public void Run()
        {
            bool needToGuess = false;

            do
            {
                try
                {
                    _log.LogInformation("Let's guess the digit");
                    _log.LogInformation("Rules: digit in range from {rangeStartItem} to {rangeEndItem}. Attempts count is {leftGuessAttempts}",
                        _settings.RangeStartItem,
                        _settings.RangeEndItem,
                        _generator.LeftGuessAttempts);

                    Console.Write("Please input digit: ");
                    var tryGuessDigit = Convert.ToInt32(Console.ReadLine()); // проверка на диапазон и формат
                    var result = _generator.TryGuess(tryGuessDigit);

                    // Получаем подсказку (больше или меньше число загаданного
                    _log.LogInformation("------");
                    _log.LogInformation("Guess Result: {guessResult}", _generator.GetGuessState(tryGuessDigit));
                    needToGuess = !result;
                }
                catch (FormatException ex)
                {
                    _log.LogError("------");
                    _log.LogError("Invalid digit input. Message: {message}", ex.Message);
                    needToGuess = true;
                }
                catch (InvalidValidationStateException ex)
                {
                    _log.LogWarning("------");
                    _log.LogWarning ("Can't validate your input: {valueToGuess}. Message: {ex.Message}", ex.ValueToGuess, ex.Message);
                }
                catch (AttemptsException ex)
                {
                    _log.LogWarning("------");
                    _log.LogWarning("Last guess result: {lastGuessResult}", ex.LastGuessResult);
                    _log.LogWarning("Message: {message}", ex.Message);
                    _log.LogWarning("GAME OVER");
                    needToGuess = false;
                }
            }
            while (needToGuess);
        }
    }
}
