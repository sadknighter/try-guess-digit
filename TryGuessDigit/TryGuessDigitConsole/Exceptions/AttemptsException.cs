using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryGuessDigitConsole.Exceptions
{
    public class AttemptsException : Exception
    {
        public string LastGuessResult { get => _lastGuessResult; }

        private readonly string _lastGuessResult;

        public AttemptsException(string lastGuessResult, string message) 
            : base(message) 
        {
            _lastGuessResult = lastGuessResult;
        }
    }
}
