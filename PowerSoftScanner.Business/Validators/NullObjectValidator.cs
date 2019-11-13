using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.Business.Validators
{
    public static class NullObjectValidator
    {
        public static bool Validate(object obj)
        {
            return obj != null;
        }
    }
}
