﻿using Cocktails2.Domain.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Extensions;

public static class EnumExtensions
{
    public static string ToDisplay(this Enum en)
    {

        Type type = en.GetType();

        MemberInfo[] memInfo = type.GetMember(en.ToString());

        if (memInfo != null && memInfo.Length > 0)
        {

            object[] attrs = memInfo[0].GetCustomAttributes(
                                          typeof(DisplayText),

                                          false);

            if (attrs != null && attrs.Length > 0)

                return ((DisplayText)attrs[0]).Text;

        }

        return en.ToString();

    }

}
