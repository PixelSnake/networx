using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator.Utilities.Colors
{
    public static class ColorUtilities
    {
        public static Color GetNextMatchingColor(Color c)
        {
            /* 43 is a prime number, this way it takes a long time until the same color appears again */
            return HSLToRGB((c.GetHue() + 43) % 360, c.GetSaturation(), c.GetBrightness());
        }

        public static Color HSLToRGB(float h, float s, float l)
        {
            var C = (1 - Math.Abs(2 * l - 1)) * s;
            var X = C * (1 - Math.Abs((h / 60) % 2 - 1));
            var m = l - C / 2;

            float _R, _G, _B;

            if (0 <= h && h < 60)
            {
                _R = C;
                _G = X;
                _B = 0;
            }
            else if (60 <= h && h < 120)
            {
                _R = X;
                _G = C;
                _B = 0;
            }
            else if (120 <= h && h < 180)
            {
                _R = 0;
                _G = C;
                _B = X;
            }
            else if (180 <= h && h < 240)
            {
                _R = 0;
                _G = X;
                _B = C;
            }
            else if (240 <= h && h < 300)
            {
                _R = X;
                _G = 0;
                _B = C;
            }
            else // if (30 <= h && h < 360)
            {
                _R = C;
                _G = 0;
                _B = X;
            }

            return Color.FromArgb((int)((_R + m) * 255), (int)((_G + m) * 255), (int)((_B + m) * 255));
        }
    }
}
