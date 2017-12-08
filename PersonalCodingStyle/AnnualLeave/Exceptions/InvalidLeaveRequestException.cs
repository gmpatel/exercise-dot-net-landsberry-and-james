using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AnnualLeave.Exceptions
{
    public class InvalidLeaveRequestException : Exception
    {
        public InvalidLeaveRequestException() : base()
        {
        }

        public InvalidLeaveRequestException(string message) : base(message)
        {
        }

        public InvalidLeaveRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}