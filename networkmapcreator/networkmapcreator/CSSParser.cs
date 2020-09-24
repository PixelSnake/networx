using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NetworkMapCreator
{
    public static class CSSParser
    {
        public static StyleSet CompleteParse(ExCSS.StyleRule s)
        {
            StyleSet set = new StyleSet();

            foreach (var r in s.Declarations)
            {
                switch (r.Name.ToLower())
                {
                    case "background":
                    case "background-color":
                        set.BackgroundColor = CSSColor.Parse(r.Term.ToString());
                        break;

                    case "color":
                        set.Color = CSSColor.Parse(r.Term.ToString());
                        break;

                    case "left":
                        set.X = new CSSSize(r.Term.ToString());
                        break;

                    case "top":
                        set.Y = new CSSSize(r.Term.ToString());
                        break;

                    case "width":
                        set.Width = new CSSSize(r.Term.ToString());
                        break;

                    case "height":
                        set.Height = new CSSSize(r.Term.ToString());
                        break;

                    case "padding":
                        set.Padding = ParseDimension(r.Term.ToString());
                        break;

                    case "margin":
                        set.Margin = ParseDimension(r.Term.ToString());
                        break;

                    case "border-radius":
                        try
                        {
                            set.Border.Radius = ParseDimension(r.Term.ToString());
                        }
                        catch (Exception) { }
                        break;

                    case "border":
                        var attrs = r.Term.ToString().Split(' ');

                        if (attrs.Length > 0)
                            set.Border.Width = new CSSSize(attrs[0]);
                        if (attrs.Length > 1)
                            set.Border.Style = (CSSBorderStyle)Enum.Parse(typeof(CSSBorderStyle), attrs[1].First().ToString().ToUpper() + String.Join("", attrs[1].Skip(1)));
                        if (attrs.Length > 2)
                            set.Border.Color = CSSColor.Parse(attrs[2]);
                        break;

                    case "position":
                        switch (r.Term.ToString().ToLower())
                        {
                            case "relative":
                                set.Position = CSSPosition.Relative;
                                break;

                            case "absolute":
                                set.Position = CSSPosition.Absolute;
                                break;

                            case "fixed":
                                set.Position = CSSPosition.Fixed;
                                break;
                        }
                        break;
                }
            }

            return set;
        }

        public static CSSDimension ParseDimension(string dim)
        {
            Match m;

            m = Regex.Match(dim, @"([0-9]+)\s+([0-9]+)\s+([0-9]+)\s+([0-9]+)");
            if (m.Success)
                return new CSSDimension(
                    int.Parse(m.Groups[1].Value),
                    int.Parse(m.Groups[2].Value),
                    int.Parse(m.Groups[3].Value),
                    int.Parse(m.Groups[4].Value));

            m = Regex.Match(dim, @"([0-9]+)\s+([0-9]+)");
            if (m.Success)
                return new CSSDimension(
                    int.Parse(m.Groups[1].Value),
                    int.Parse(m.Groups[2].Value));

            m = Regex.Match(dim, @"([0-9]+)");
            if (m.Success)
                return new CSSDimension(
                    int.Parse(m.Groups[1].Value));

            return new CSSDimension();
        }
    }
}
