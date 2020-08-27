using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCUtilities.Exceptions
{
    public class MVCException:Exception
    {
        public MVCException()
        {

        }
        public MVCException(string message)
            :base(message)
        {

        }
        public MVCException(string message, Exception inner)
            :base(message,inner)
        {

        }

    }
}
