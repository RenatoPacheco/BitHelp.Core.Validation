using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitHelp.Core.Validation.Test.Resources
{
    public class CustonException : Exception
    {
        public CustonException(string message, string stackTrace = null)
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
