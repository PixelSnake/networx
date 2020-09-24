using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetworkMapCreator.Station;

namespace NetworkMapCreator.EditorElements
{
    public static class Tools
    {
        public static PointF Pivot2Point(LabelPivot p)
        {
            switch (p)
            {
                case LabelPivot.BottomCenter:
                    return new PointF(0.5f, 1.0f);

                case LabelPivot.BottomLeft:
                    return new PointF(0, 1.0f);

                case LabelPivot.BottomRight:
                    return new PointF(1.0f, 1.0f);

                case LabelPivot.Center:
                    return new PointF(0.5f, 0.5f);

                case LabelPivot.CenterLeft:
                    return new PointF(0, 0.5f);

                case LabelPivot.CenterRight:
                    return new PointF(1.0f, 0.5f);

                case LabelPivot.TopCenter:
                    return new PointF(0.5f, 0);

                case LabelPivot.TopLeft:
                    return new PointF(0, 0);

                case LabelPivot.TopRight:
                    return new PointF(1.0f, 0);

                default:
                    return new PointF(0.5f, 0.5f);
            }
        }

        public static LabelPivot Point2Pivot(PointF p)
        {
            if (p.Y == 0)
            {
                if (p.X == 0)
                    return LabelPivot.TopLeft;
                else if (p.X == 0.5f)
                    return LabelPivot.TopCenter;
                else
                    return LabelPivot.TopRight;
            }
            else if (p.Y == 0.5f)
            {
                if (p.X == 0)
                    return LabelPivot.CenterLeft;
                else if (p.X == 0.5f)
                    return LabelPivot.Center;
                else
                    return LabelPivot.CenterRight;
            }
            else
            {
                if (p.X == 0)
                    return LabelPivot.BottomLeft;
                else if (p.X == 0.5f)
                    return LabelPivot.BottomCenter;
                else
                    return LabelPivot.BottomRight;
            }
        }
    }
}
