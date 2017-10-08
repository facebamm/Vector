using FaceMaterial.Vector.Interfaces;
namespace FaceMaterial.Vector.D2
{
    public class Point : Point<double, Point, Vector>
    {
        public Point(double val)
        {
            X = val;
            Y = val;
        }
        public Point(double x, double y = 0)
        {
            X = x;
            Y = y;
        }
        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public static Point NullPoint { get => new Point(0, 0); }
        public static Vector Delta(Point a, Point b) => (Vector) b - a;
        public static Vector Delta(double x_first, double y_first, double x_second, double y_second) => Delta(new Point(x_first, y_first), new Point(x_second, y_second));
        public override Point Move(Vector vector) => new Point(X + vector.X, Y + vector.Y);
        public override Point Move(double x) => Move(new Vector(x, 0));
        public override Point Move(double x, double y) => Move(new Vector(x, y));

        public override bool EqualsTo(Point b) => X == b.X && Y == b.Y;
        public override bool EqualsToX(Point b) => X == b.X;
        public override bool EqualsToY(Point b) => Y == b.Y;
        public override bool IsEmpty() => EqualsTo(NullPoint);
        public override string ToString() => this;

        public static implicit operator string(Point point) => $"{point.X} {point.Y}";
        public static implicit operator Vector(Point pointA) => new Vector(pointA.X, pointA.Y);
    }
}
