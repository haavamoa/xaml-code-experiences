using System;
using System.Collections.Generic;

namespace applicationskeleton.DataModel
{
    public class HairColor
    {
        public string ColorName { get; }

        public HairColor(string colorName)
        {
            ColorName = colorName;
        }

        public override bool Equals(object other) => other is HairColor && ((HairColor)other).ColorName.Equals(ColorName, StringComparison.OrdinalIgnoreCase);
    }
}