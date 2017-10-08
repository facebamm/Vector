using FaceMaterial.Vector.D2;
using FaceMaterial.Vector.Interfaces;

namespace FaceMaterial.Vector.D3
{
    public class Point3D : Point3<double, Point3D, Vector3D>
    {

        public Point3D(double val)
        {
            X = val;
            Y = val;
            Z = val;
        }
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point3D NullPoint { get => new Point3D(0); }
        public override bool IsEmpty() => Equals(NullPoint);

        public override bool EqualsTo(Point3D b) => EqualsToX(b) && EqualsToY(b) && EqualsToZ(b);
        public override bool EqualsToX(Point3D b) => X == b.X;
        public override bool EqualsToY(Point3D b) => Y == b.Y;
        public override bool EqualsToZ(Point3D b) => Z == b.Z;

        public override bool EqualsToXY(Point3D b) => EqualsToX(b) && EqualsToY(b);
        public override bool EqualsToXZ(Point3D b) => EqualsToX(b) && EqualsToZ(b);
        public override bool EqualsToYZ(Point3D b) => EqualsToY(b) && EqualsToZ(b);

        public override bool EqualsXYZ() => X == Y && Y == Z;
        public override bool EqualsXY() => X == Y;
        public override bool EqualsYZ() => Y == Z;
        public override bool EqualsXZ() => X == Z;

        public override Point3D Move(Vector3D vector) => Move(vector.X, vector.Y, vector.Z);
        public override Point3D Move(double x) => Move(x, 0, 0);
        public override Point3D Move(double x, double y) => Move(x, y,0);
        public override Point3D Move(double x, double y, double z) => new Point3D(X + X, Y + Y, Z + Z);

        public static Vector3D Delta(Point3D a, Point3D b) => (Vector3D)b - a;
        public static Vector3D Delta(Point3D a, double x_second, double y_second, double z_second) 
            => Delta(a, new Point3D(x_second, y_second, z_second));
        public static Vector3D Delta(double x_first, double y_first, double z_first, double x_second, double y_second, double z_second) 
            => Delta(new Point3D(x_first, y_first, z_first), new Point3D(x_second, y_second, z_second));

        /// <summary>
        /// Convert the Vector to String
        /// </summary>
        /// <returns>X:x_value Y:y_value Z:z_value</returns>
        public override string ToString() => this;
        
        public static implicit operator string(Point3D a) => $"{a.X} {a.Y} {a.Z}";

        public static implicit operator Vector3D(Point3D pointA) => new Vector3D(pointA.X, pointA.Y, pointA.Z);

        public static explicit operator D2.Vector(Point3D pointA) => new D2.Vector(pointA.X, pointA.Y);
        public static explicit operator Point(Point3D pointA) => new Point(pointA.X, pointA.Y);
    }
}
