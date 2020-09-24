using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator.EditorElements
{
    public class SegmentDrawingParams
    {
        public int begin_factor_x = 0, begin_factor_y = 0;
        public int end_factor_x = 0, end_factor_y = 0;
        public int begin_shift_x = 0, begin_shift_y = 0;
        public int end_shift_x = 0, end_shift_y = 0;

        public static SegmentDrawingParams FromStations(Station begin, Station end, int width)
        {
            int begin_factor_x = 0, begin_factor_y = 0;
            int end_factor_x = 0, end_factor_y = 0;
            int begin_shift_x = 0, begin_shift_y = 0;
            int end_shift_x = 0, end_shift_y = 0;

            var begin_side = begin.GetStationSide(end);
            var end_side = end.GetStationSide(begin);

            switch (begin_side)
            {
                case Station.Direction.Left:
                case Station.Direction.Right:
                    begin_factor_y = 1;
                    begin_shift_y = -width / 2;
                    break;

                case Station.Direction.Top:
                case Station.Direction.Bottom:
                    begin_factor_x = 1;
                    begin_shift_x = -width / 2;
                    break;
            }

            switch (end_side)
            {
                case Station.Direction.Left:
                case Station.Direction.Right:
                    end_factor_y = 1;
                    end_shift_y = -width / 2;
                    break;

                case Station.Direction.Top:
                case Station.Direction.Bottom:
                    end_factor_x = 1;
                    end_shift_x = -width / 2;
                    break;
            }

            return new SegmentDrawingParams
            {
                begin_factor_x = begin_factor_x,
                begin_factor_y = begin_factor_y,
                begin_shift_x = begin_shift_x,
                begin_shift_y = begin_shift_y,
                end_factor_x = end_factor_x,
                end_factor_y = end_factor_y,
                end_shift_x = end_shift_x,
                end_shift_y = end_shift_y
            };
        }
    }
}
