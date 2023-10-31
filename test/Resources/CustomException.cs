using System;

namespace BitHelp.Core.Validation.Test.Resources
{
    public class CustomException : Exception
    {
        public CustomException(string message, string stackTrace = null)
        {
            _message = message;
            _stackTrace = stackTrace;
        }


        private string _message;
        public override string Message => _message;

        private string _stackTrace;
        public override string StackTrace => _stackTrace;
    }
}
