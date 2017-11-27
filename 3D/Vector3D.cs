using FaceMaterial.Terrain.Interfaces;
namespace FaceMaterial.Terrain.Dimension3
{
    public class Vector3D : Vector3<double,Vector3D>
    {
        public Vector3D(double val)
        {
            X = val;
            Y = val;
            Z = val;
        }
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3D(Point3D point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        public static Vector3D NullVector { get => new Vector3D(0); }
        public override bool IsEmpty() => Equals(NullVector);
        public override double Value() => System.Math.Sqrt((X.Sqr() + Y.Sqr() + Z.Sqr()));

        public override bool EqualsToX(Vector3D b) => X == b.X;
        public override bool EqualsToY(Vector3D b) => Y == b.Y;
        public override bool EqualsToZ(Vector3D b) => Z == b.Z;

        public override bool EqualsToXY(Vector3D b) => EqualsToX(b) && EqualsToY(b);
        public override bool EqualsToXZ(Vector3D b) => EqualsToX(b) && EqualsToZ(b);

        public override bool EqualsToYZ(Vector3D b) => EqualsToY(b) && EqualsToZ(b);

        public override bool EqualsTo(Vector3D b) => EqualsToX(b) && EqualsToY(b) && EqualsToZ(b);

        public override bool EqualsXYZ() => X == Y && Y == Z;
        public override bool EqualsXY() => X == Y;
        public override bool EqualsYZ() => Y == Z;
        public override bool EqualsXZ() => X == Z;
        
        public override string ToString() => $"{X} {Y} {Z}";

        protected override Vector3D Add(Vector3D vectorA) => new Vector3D(X + vectorA.X, Y + vectorA.Y, Z + vectorA.Z);
        protected override Vector3D Sub(Vector3D vectorA) => new Vector3D(X - vectorA.X, Y - vectorA.Y, Z - vectorA.Z);
        protected override Vector3D Mul(Vector3D vectorA) => new Vector3D(X * vectorA.X, Y * vectorA.Y, Z * vectorA.Z);
        protected override Vector3D Div(Vector3D vectorA) => new Vector3D(X / vectorA.X, Y / vectorA.Y, Z / vectorA.Z);

        protected override Vector3D Add(double value) => Add(new Vector3D(value));
        protected override Vector3D Sub(double value) => Sub(new Vector3D(value));
        protected override Vector3D Mul(double value) => Mul(new Vector3D(value));
        protected override Vector3D Div(double value) => Div(new Vector3D(value));

        public static Vector3D operator +(Vector3D a, Vector3D b) => a.Add(b);
        public static Vector3D operator -(Vector3D a, Vector3D b) => a.Sub(b);
        public static Vector3D operator *(Vector3D a, Vector3D b) => a.Mul(b);
        public static Vector3D operator /(Vector3D a, Vector3D b) => a.Div(b);

        public static Vector3D operator +(Vector3D a, double b) => a.Add(b);
        public static Vector3D operator -(Vector3D a, double b) => a.Sub(b);
        public static Vector3D operator *(Vector3D a, double b) => a.Mul(b);
        public static Vector3D operator /(Vector3D a, double b) => a.Div(b);

        public static Vector3D operator +(double a, Vector3D b) => b.Add(a);
        public static Vector3D operator -(double a, Vector3D b) => b.Sub(a);
        public static Vector3D operator *(double a, Vector3D b) => b.Mul(a);
        public static Vector3D operator /(double a, Vector3D b) => b.Div(a);

        public static bool IsKomplanar(Vector3D vectorA, Vector3D vectorB, Vector3D vectorC)
        {
            double v1 = vectorA.X * vectorB.Y * vectorC.Z,
                v2 = vectorB.X * vectorC.Y * vectorA.Z,
                v3 = vectorC.X * vectorA.Y * vectorB.Z,
                v4 = vectorA.Z * vectorB.Y * vectorC.X,
                v5 = vectorB.Z * vectorC.Y * vectorA.X,
                v6 = vectorC.Z * vectorA.Y * vectorB.X;
            return v1 + v2 + v3 - v4 - v5 - v6 == 0;
        }
        public static bool IsKollinaer(Vector3D vectorA, Vector3D vectorB)
        {
            Vector3D result = vectorA / vectorB;
            return result.X == result.Y && result.Y == result.Z;
        }

        public override Vector3D Cross(Vector3D b) => new Vector3D((Y  * b.Z) - (Z * b.Y), -((Z * b.X) - (X * b.Z)), (X * b.Y) - (Y * b.X));
        public override double Scalar() => throw new System.NotImplementedException();

        public static implicit operator Point3D(Vector3D vector) => new Point3D(vector.X, vector.Y, vector.Z);
        public static implicit operator string(Vector3D a) => $"{a.X} {a.Y} {a.Z}";
    }
}
