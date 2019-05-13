using System;

namespace eventbased.DataModel
{
    public class HairColor
    {
        public string ColorName { get; }

        public HairColor(string colorName)
        {
            ColorName = colorName;
        }

        public override bool Equals(object other) => other is HairColor && ((HairColor)other).ColorName.Equals(ColorName, StringComparison.OrdinalIgnoreCase);

        protected bool Equals(HairColor other)
        {
            return string.Equals(ColorName, other.ColorName);
        }

        public override int GetHashCode()
        {
            return (ColorName != null ? ColorName.GetHashCode() : 0);
        }
    }
}