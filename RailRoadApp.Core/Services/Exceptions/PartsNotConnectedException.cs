using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailRoadApp.Core.Services.Exceptions
{
    public class PartsNotConnectedException : Exception
    {
        public PartsNotConnectedException() {
        }

        public PartsNotConnectedException(string message)
            : base(message) {
        }

        public PartsNotConnectedException(string message, Exception inner)
            : base(message, inner) {
        }
    }
}
