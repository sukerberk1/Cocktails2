using Cocktails2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Entities
{
    public class TasteParameters : BaseEntity
    {
        public double Sourness { get; init; }
        public double Sweetness { get; init; }
        public double Bitterness { get; init; }
        public double Creaminess { get; init; }
        public double Spiciness { get; init; }
        // Strength acts as a multiplier for ingredient's taste
        public int Strength { get; init; }
    }
}
