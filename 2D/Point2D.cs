using FaceMaterial.Terrain.Interfaces;
namespace FaceMaterial.Terrain.Dimension2
{
    public class Point2D : Point<double, Point2D, Vector2D>
    {
        public Point2D(double val)
        {
            X = val;
            Y = val;
        }
        public Point2D(double x, double y = 0)
        {
            X = x;
            Y = y;
        }
        public Point2D(Point2D point)
        {
            X = point.X;
            Y = point.Y;
        }

        public static Point2D NullPoint { get => new Point2D(0); }

        public static Vector2D Delta(Point2D a, Point2D b) => (Vector2D) b - a;
        public static Vector2D Delta(double x_first, double y_first, double x_second, double y_second) => Delta(new Point2D(x_first, y_first), new Point2D(x_second, y_second));

        public override Point2D Move(Vector2D vector) => new Point2D(X + vector.X, Y + vector.Y);
        public override Point2D Move(double x) => Move(new Vector2D(x, 0));
        public override Point2D Move(double x, double y) => Move(new Vector2D(x, y));

        public override bool EqualsTo(Point2D b) => X == b.X && Y == b.Y;
        public override bool EqualsToX(Point2D b) => X == b.X;
        public override bool EqualsToY(Point2D b) => Y == b.Y;
        public override bool IsEmpty() => EqualsTo(NullPoint);

        public override string ToString() => this;

        public static implicit operator string(Point2D point) => $"{point.X} {point.Y}";
        public static implicit operator Vector2D(Point2D pointA) => new Vector2D(pointA.X, pointA.Y);
    }
}
