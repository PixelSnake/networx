using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;

namespace NetworkMapCreator
{
    public enum CSSPosition
    {
        Relative,
        Absolute,
        Fixed
    }

    public struct CSSBorder
    {
        public CSSBorderStyle Style;
        public CSSColor Color;
        public CSSSize Width;
        public CSSDimension Radius;
    }

    public enum CSSColorValueType
    {
        None = 0,
        Transparent,
        Auto,
        Value
    }

    public struct CSSColor
    {
        public CSSColorValueType ValueType;
        public Color Value;

        public bool IsNone        { get { return ValueType == CSSColorValueType.None; } }
        public bool IsTransparent { get { return ValueType == CSSColorValueType.Transparent; } }
        public bool IsAuto        { get { return ValueType == CSSColorValueType.Auto; } }
        public bool IsValue       { get { return ValueType == CSSColorValueType.Value; } }

        public static CSSColor Parse(string csscolor)
        {
            CSSColor color;
            color.Value = Color.Transparent;

            switch (csscolor.ToLower().Trim())
            {
                case "auto":
                    color.ValueType = CSSColorValueType.Auto;
                    return color;

                case "transparent":
                    color.ValueType = CSSColorValueType.Transparent;
                    return color;

                case "none":
                    color.ValueType = CSSColorValueType.None;
                    return color;

                default:
                    color.ValueType = CSSColorValueType.Value;
                    break;
            }

            Match m;

            m = Regex.Match(csscolor, @"#(([0-9]|[a-f]|[A-F])([0-9]|[a-f]|[A-F])([0-9]|[a-f]|[A-F])(([0-9]|[a-f]|[A-F]){3})?)");
            if (m.Success)
            {
                color.Value = ColorTranslator.FromHtml(csscolor);
                return color;
            }

            m = Regex.Match(csscolor, @"rgb\s*\(\s*([0-9]+)\s*,\s*([0-9]+)\s*,\s*([0-9]+)\s*\)");
            if (m.Success)
            {
                Color c = Color.Transparent;

                try
                {
                    var red = int.Parse(m.Groups[1].Value);
                    var green = int.Parse(m.Groups[2].Value);
                    var blue = int.Parse(m.Groups[3].Value);

                    c = Color.FromArgb(255, red, green, blue);
                }
                catch (FormatException) { }

                color.Value = c;
                return color;
            }

            m = Regex.Match(csscolor, @"rgba\s*\(\s*([0-9]+)\s*,\s*([0-9]+)\s*,\s*([0-9]+)\s*,\s*(([0-9]+).([0-9]+))\s*\)");
            if (m.Success)
            {
                Color c = Color.Transparent;

                try
                {
                    var red = int.Parse(m.Groups[1].Value);
                    var green = int.Parse(m.Groups[2].Value);
                    var blue = int.Parse(m.Groups[3].Value);
                    var alpha = double.Parse(m.Groups[4].Value.Replace('.', ',')) * 255.0;

                    c = Color.FromArgb((int)alpha, red, green, blue);
                }
                catch (FormatException) { }

                color.Value = c;
                return color;
            }

            /* malformed color string */
            color.ValueType = CSSColorValueType.None;
            return color;
        }
        public Color GetColorAuto(Color autocolor)
        {
            switch (ValueType)
            {
                case CSSColorValueType.Auto:
                    return autocolor;

                case CSSColorValueType.Transparent:
                case CSSColorValueType.None:
                    return Color.Transparent;

                default:
                    return Value;
            }
        }
    }

    public struct CSSDimension
    {
        int l, t, r, b;
        public int Left   { get { return l; } }
        public int Top    { get { return t; } }
        public int Right  { get { return r; } }
        public int Bottom { get { return b; } }

        public CSSDimension(int r)
        {
            l = t = this.r = b = r;
        }

        public CSSDimension(int v, int h)
        {
            l = r = h;
            t = b = v;
        }

        public CSSDimension(int _l, int _t, int _r, int _b)
        {
            l = _l;
            t = _t;
            r = _r;
            b = _b;
        }
    }

    public enum CSSBorderStyle
    {
        None,
        Hidden,
        Dotted,
        Dashed,
        Solid,
        Double,
        Groove,
        Ridge,
        Inset,
        Outset,
        Initial,
        Inherit
    }

    public struct CSSSize
    {
        public int Value;
        public CSSSizeMode SizeMode;

        public CSSSize(int value, CSSSizeMode sizemode)
        {
            Value = value;
            SizeMode = sizemode;
        }

        public CSSSize(string value)
        {
            Match m;

            m = Regex.Match(value, @"([0-9]+)\s*(px)?");
            if (m.Success)
            {
                Value = int.Parse(m.Groups[1].Value);
                SizeMode = CSSSizeMode.Pixel;
                return;
            }

            m = Regex.Match(value, @"([0-9]+)\s*%");
            if (m.Success)
            {
                Value = int.Parse(m.Groups[1].Value);
                SizeMode = CSSSizeMode.Percent;
                return;
            }

            if (value.Equals("auto"))
            {
                Value = 0;
                SizeMode = CSSSizeMode.Auto;
                return;
            }

            Value = 0;
            SizeMode = CSSSizeMode.Auto;
        }
    }

    public enum CSSSizeMode
    {
        Auto,
        Pixel,
        Percent
    }

    public struct StyleSet
    {
        public static StyleSet Default = new StyleSet();

        public CSSColor BackgroundColor;
        public CSSColor Color;

        public CSSPosition Position;
        public CSSSize Width;
        public CSSSize Height;

        public CSSDimension Padding;
        public CSSDimension Margin;
        
        public CSSSize X;
        public CSSSize Y;
        public CSSBorder Border;
    }
}
