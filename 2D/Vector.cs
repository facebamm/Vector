using System;
using FaceMaterial.Vector.Interfaces;
namespace FaceMaterial.Vector.D2
{
    public class Vector : Vector<double, Vector>
    {
        public Vector()
        {
            X = 0;
            Y = 0;
        }
        public Vector(double val)
        {
            X = val;
            Y = val;
        }
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vector(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public static Vector NullVector { get => new Vector(0, 0); }

        public override bool EqualsTo(Vector b) => X == b.X && Y == b.Y;
        public override bool EqualsToX(Vector b) => X == b.X;
        public override bool EqualsToY(Vector b) => Y == b.Y;

        public override bool EqualsXY() => X == Y;


        public override bool IsEmpty() => EqualsTo(NullVector);
        public override string ToString() => $"{X} {Y}";
        public override double Value() => Math.Sqrt(X.Sqr() + Y.Sqr());
        public static bool IsKollinaer(Vector vectorA, Vector vectorB) => (vectorA / vectorB).EqualsXY();

        protected override Vector Add(Vector vectorB) => new Vector(X + vectorB.X, Y + vectorB.Y);
        protected override Vector Sub(Vector vectorB) => new Vector(X - vectorB.X, Y - vectorB.Y);
        protected override Vector Mul(Vector vectorB) => new Vector(X * vectorB.X, Y * vectorB.Y);
        protected override Vector Div(Vector vectorB) => new Vector(X / vectorB.X, Y / vectorB.Y);

        protected override Vector Add(double value) => Add(new Vector(value));
        protected override Vector Sub(double value) => Sub(new Vector(value));
        protected override Vector Mul(double value) => Add(new Vector(value));
        protected override Vector Div(double value) => Add(new Vector(value));

        public static Vector operator +(Vector a, Vector b) => a.Add(b);
        public static Vector operator -(Vector a, Vector b) => a.Sub(b);
        public static Vector operator *(Vector a, Vector b) => a.Mul(b);
        public static Vector operator /(Vector a, Vector b) => a.Div(b);
                      
        public static Vector operator +(Vector a, double b) => a.Add(b);
        public static Vector operator -(Vector a, double b) => a.Sub(b);
        public static Vector operator *(Vector a, double b) => a.Mul(b);
        public static Vector operator /(Vector a, double b) => a.Div(b);
                      
        public static Vector operator +(double a, Vector b) => b.Add(a);
        public static Vector operator -(double a, Vector b) => b.Add(a);
        public static Vector operator *(double a, Vector b) => b.Add(a);
        public static Vector operator /(double a, Vector b) => b.Add(a);


        public static implicit operator Point(Vector vectorA) => new Point(vectorA.X, vectorA.Y);
        public static implicit operator string(Vector a) => a.ToString();
    }
}
