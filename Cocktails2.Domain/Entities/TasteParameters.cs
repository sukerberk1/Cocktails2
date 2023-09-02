using Cocktails2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Entities
{
    public class TasteParameters
    {
        public double Sourness { get; init; }
        public double Sweetness { get; init; }
        public double Bitterness { get; init; }
        public double Creaminess { get; init; }
        public double Spiciness { get; init; }
        // strength is a 'multplier' of the taste. Default for alcohols and mixers: 1 
        public double Strength { get; init; }

    }
}
