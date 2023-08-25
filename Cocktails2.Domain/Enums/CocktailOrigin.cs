using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cocktails2.Domain.Annotations;

namespace Cocktails2.Domain.Enums;

public enum CocktailOrigin
{
    [DisplayText("United States")]
    UnitedStates,
    [DisplayText("United Kingdom")]
    UnitedKingdom,
    Mexico,
    Italy,
    France,
    Japan,
    Spain,
    Brazil,
    Australia,
    Other
}
