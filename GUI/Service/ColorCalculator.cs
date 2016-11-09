using System;
using System.Windows.Media;

namespace HighwayToHell.GUI.Service
{
    class ColorCalculator
    {
        private readonly int _defaultRed;
        private readonly int _defaultGreen;
        private readonly int _defaultBlue;

        public ColorCalculator(int defaultRed, int defaultGreen, int defaultBlue)
        {
            _defaultRed = defaultRed;
            _defaultGreen = defaultGreen;
            _defaultBlue = defaultBlue;
        }

        public Color GetBackgroundColor(double heavCount, double hellCount)
        {
            if (heavCount > 0)
            {
                return CalcColor(50, 50, 255, heavCount);
            }
            return hellCount > 0 ? CalcColor(255, 125, 50, hellCount) : CalcColor(_defaultRed, _defaultGreen, _defaultBlue, 0);
        }

        private Color CalcColor(int red, int green, int blue, double count)
        {
            count = count * 2;
            var redFeet = red / _defaultRed;
            var greenFeet = green / _defaultGreen;
            var blueFeet = blue / _defaultBlue;
            var redByte = Convert.ToByte(redFeet * count);
            var greenByte = Convert.ToByte(greenFeet * count);
            var blueByte = Convert.ToByte(blueFeet * count);
            return Color.FromRgb(redByte, greenByte, blueByte);
        }
    }
}
