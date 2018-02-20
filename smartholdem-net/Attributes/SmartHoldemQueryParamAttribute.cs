using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHoldemNet.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SmartHoldemQueryParamAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
