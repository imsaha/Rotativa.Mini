using System;

namespace Rotativa.Mini
{
    public class OptionFlag:Attribute
    {
        public string Name { get; private set; }
        public bool IsCusotm { get; private set; }

        public OptionFlag(string name)
        {
            Name = name;
        }
        public OptionFlag(bool isCustom)
        {
            IsCusotm = isCustom;
        }
    }
}
