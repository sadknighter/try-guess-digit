using Microsoft.Extensions.Configuration;

namespace TryGuessDigitConsole
{
    public class GeneratorSettings
    {
        public readonly int GuessTimesCount;
        public readonly int RangeStartItem;
        public readonly int RangeEndItem;

        public GeneratorSettings() 
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();
            
            this.GuessTimesCount = Convert.ToInt32(config["GuessTimesCount"]);
            this.RangeStartItem = Convert.ToInt32(config["RangeStartItem"]);
            this.RangeEndItem = Convert.ToInt32(config["RangeEndItem"]);

        }  
    }
}
