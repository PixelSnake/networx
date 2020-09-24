using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator
{
    public class Vector3
    {
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }
        public static Vector3 operator *(Vector3 a, int s)
        {
            return new Vector3(a.X * s, a.Y * s, a.Z * s);
        }
        public static Vector3 operator /(Vector3 a, int s)
        {
            return new Vector3(a.X / s, a.Y / s, a.Z / s);
        }
        public static Vector3D operator *(Vector3 a, double s)
        {
            return new Vector3D(a.X * s, a.Y * s, a.Z * s);
        }
        public static Vector3D operator /(Vector3 a, double s)
        {
            return new Vector3D(a.X / s, a.Y / s, a.Z / s);
        }

        public int X, Y, Z;

        public Vector3()
        {
            X = Y = Z = 0;
        }

        public Vector3(int x, int y, int z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(Point p)
        {
            X = p.X;
            Y = p.Y;
            Z = 0;
        }

        public Vector3D Unit()
        {
            var a = Abs();

            if (a != 0)
                return new Vector3D(X / a, Y / a, Z / a);
            else
                return new Vector3D(0, 0, 0);
        }

        public double Abs()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public double Distance(Vector3 v)
        {
            double dx = v.X - X;
            double dy = v.Y - Y;
            double dz = v.Z - Z;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /* calculates the angle between this vector and v clockwise */
        public double Angle(Vector3 v)
        {
            var a = this.Unit().Abs();
            var av = v.Unit().Abs();

            if (av == 0)
                return 0.0;

            return Math.Acos(a / av);
        }


        public Vector3D ToVector3D()
        {
            return new Vector3D(X, Y, Z);
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public override String ToString()
        {
            return "Vector3 { x: " + X + ", y: " + Y + ", z: " + Z + "}";
        }
    }
}
