using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Exceptions
{
    public class InvalidTasteParameterException : ArgumentOutOfRangeException
    {
        public InvalidTasteParameterException(double minTasteValue, double maxTasteValue) 
            : base($"Taste parameter value must be between {minTasteValue} and {maxTasteValue}") 
        { }

    }
}
