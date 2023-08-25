using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Annotations;

[AttributeUsage(AttributeTargets.Field)]
public class DisplayText : Attribute
{

    public DisplayText(string Text)
    {
        this.text = Text;
    }


    private string text;


    public string Text
    {
        get { return text; }
        set { text = value; }
    }
}