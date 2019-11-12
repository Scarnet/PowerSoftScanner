using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.Business.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }
        public BusinessException(string msg) : base(msg)
        {

        }
    }
}
