using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Concepts_Std.Interfaces
{
    
    [Serializable]
    public class CarIsDeadException : Exception
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException(string message) : base(message) { }
        public CarIsDeadException(string message, Exception inner) : base(message, inner) { }
        protected CarIsDeadException(System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        // Feed message to parent constructor.
        public CarIsDeadException(string message, string cause, DateTime time)
        : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
