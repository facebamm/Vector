using System;
using FaceMaterial.Terrain.Interfaces;
namespace FaceMaterial.Terrain.Dimension2
{
    public class Vector2D : Vector<double, Vector2D>
    {
        public Vector2D()
        {
            X = 0;
            Y = 0;
        }
        public Vector2D(double val)
        {
            X = val;
            Y = val;
        }
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vector2D(Point2D point)
        {
            X = point.X;
            Y = point.Y;
        }

        public static Vector2D NullVector { get => new Vector2D(0, 0); }

        public override bool EqualsTo(Vector2D b) => X == b.X && Y == b.Y;
        public override bool EqualsToX(Vector2D b) => X == b.X;
        public override bool EqualsToY(Vector2D b) => Y == b.Y;

        public override bool EqualsXY() => X == Y;


        public override bool IsEmpty() => EqualsTo(NullVector);
        public override string ToString() => $"{X} {Y}";
        public override double Value() => Math.Sqrt(X.Sqr() + Y.Sqr());
        public static bool IsKollinaer(Vector2D vectorA, Vector2D vectorB) => (vectorA / vectorB).EqualsXY();

        protected override Vector2D Add(Vector2D vectorB) => new Vector2D(X + vectorB.X, Y + vectorB.Y);
        protected override Vector2D Sub(Vector2D vectorB) => new Vector2D(X - vectorB.X, Y - vectorB.Y);
        protected override Vector2D Mul(Vector2D vectorB) => new Vector2D(X * vectorB.X, Y * vectorB.Y);
        protected override Vector2D Div(Vector2D vectorB) => new Vector2D(X / vectorB.X, Y / vectorB.Y);

        protected override Vector2D Add(double value) => Add(new Vector2D(value));
        protected override Vector2D Sub(double value) => Sub(new Vector2D(value));
        protected override Vector2D Mul(double value) => Add(new Vector2D(value));
        protected override Vector2D Div(double value) => Add(new Vector2D(value));

        public override double Scalar() => X + Y;

        public static Vector2D operator +(Vector2D a, Vector2D b) => a.Add(b);
        public static Vector2D operator -(Vector2D a, Vector2D b) => a.Sub(b);
        public static Vector2D operator *(Vector2D a, Vector2D b) => a.Mul(b);
        public static Vector2D operator /(Vector2D a, Vector2D b) => a.Div(b);
                      
        public static Vector2D operator +(Vector2D a, double b) => a.Add(b);
        public static Vector2D operator -(Vector2D a, double b) => a.Sub(b);
        public static Vector2D operator *(Vector2D a, double b) => a.Mul(b);
        public static Vector2D operator /(Vector2D a, double b) => a.Div(b);
                      
        public static Vector2D operator +(double a, Vector2D b) => b.Add(a);
        public static Vector2D operator -(double a, Vector2D b) => b.Add(a);
        public static Vector2D operator *(double a, Vector2D b) => b.Add(a);
        public static Vector2D operator /(double a, Vector2D b) => b.Add(a);

        public static implicit operator Point2D(Vector2D vectorA) => new Point2D(vectorA.X, vectorA.Y);
        public static implicit operator string(Vector2D a) => a.ToString();
    }
}
