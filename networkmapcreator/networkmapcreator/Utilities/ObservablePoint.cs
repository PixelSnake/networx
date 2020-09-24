using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator.Utilities
{
    public struct ObservablePointChangedEventArgs
    {
        public int X, Y;
    }

    public class ObservablePoint
    {
        public static explicit operator Point(ObservablePoint p)
        {
            return new Point(p.X, p.Y);
        }

        public bool IsEmpty
        {
            get
            {
                return X == 0 && Y == 0;
            }
        }

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                PointChanged?.Invoke(this, new ObservablePointChangedEventArgs
                {
                    X = value,
                    Y = this.Y
                });
            }
        }
        private int _x;
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                PointChanged?.Invoke(this, new ObservablePointChangedEventArgs
                {
                    X = this.X,
                    Y = value
                });
            }
        }
        private int _y;

        public delegate void PointChangedEventHandler(object sender, ObservablePointChangedEventArgs e);
        public event PointChangedEventHandler PointChanged;

        public ObservablePoint()
        {
            _x = 0;
            _y = 0;
        }

        public ObservablePoint(int X, int Y)
        {
            _x = X;
            _y = Y;
        }

        public ObservablePoint(Point p)
        {
            _x = p.X;
            _y = p.Y;
        }

        public void Set(int X, int Y)
        {
            _x = X;
            _y = Y;
            PointChanged?.Invoke(this, new ObservablePointChangedEventArgs
            {
                X = X,
                Y = Y
            });
        }

        public void Offset(int X, int Y)
        {
            this.X += X;
            this.Y += Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is ObservablePoint)
                return X == ((ObservablePoint)obj).X && Y == ((ObservablePoint)obj).Y;
            else if (obj is Point)
                return X == ((Point)obj).X && Y == ((Point)obj).Y;
            return false;
        }

        public override string ToString()
        {
            return $"{{{X}, {Y}}}";
        }
    }
}
