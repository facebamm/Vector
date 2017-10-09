using FaceMaterial.Terrain.Interfaces;
namespace FaceMaterial.Terrain.Dimension2
{
    public class VectorFunction2D : VectorFunction<Vector2D, VectorFunction2D, Point2D>
    {
        public VectorFunction2D(Vector2D positionvector, Vector2D directionvector)
        {
            PositionVector = positionvector;
            DirectionVector = directionvector;
        }

        public override CompareResult CompareTo(VectorFunction2D f)
        {

            bool kolli = Vector2D.IsKollinaer(DirectionVector, f.DirectionVector);

            if (kolli)
                if (IsElement(f.PositionVector))
                    return CompareResult.Identical;
                else
                    return CompareResult.Parallel;
            else
                if (IsEqualTo(f))
                return CompareResult.Intersect;

            return CompareResult.Skew;
        }

        public override Point2D GetIntersectPointTo(VectorFunction2D f)
        {
            IsIntersectTo(f, out Point2D p);
            return p;
        }

        public override bool IsElement(Point2D point)
        {
            if (DirectionVector.Equals(Vector2D.NullVector))
                return PositionVector.Equals(point);

            Vector2D vec = point - PositionVector / DirectionVector;

            return vec.X == vec.Y;
        }

        public override bool IsEqualTo(VectorFunction2D f)
        {
            CalcParameter(f, out double r, out double s);

            double Yg = PositionVector.Y + (r * DirectionVector.Y);
            double Yh = f.PositionVector.Y + (s * f.DirectionVector.Y);

            return Yg == Yh;
        }

        public override bool IsIdenticalTo(VectorFunction2D f) => CompareTo(f) == CompareResult.Skew;
        public override bool IsIntersectTo(VectorFunction2D f, out Point2D point)
        {
            bool isintersect = IsIdenticalTo(f);
            point = Point2D.NullPoint;

            if (isintersect)
            {
                CalcParameter(f, out double r, out double s);
                Vector2D res = GetPoint(r) - (Vector2D) f.GetPoint(s);
                point = res;
            }

            return isintersect;
        }

        public override bool IsParallelTo(VectorFunction2D f) => CompareTo(f) == CompareResult.Parallel;
        public override bool IsSkewTo(VectorFunction2D f) => CompareTo(f) == CompareResult.Skew;

        public override Point2D GetPoint(double r) => PositionVector + r * DirectionVector;
        public override bool GetParameter(Point2D point, out Vector2D vector)
        {
            vector = point - PositionVector / DirectionVector;
            return IsElement(point);
        }

        public override void CalcParameter(VectorFunction2D f, out double r, out double s)
        {
            r = double.NaN;
            s = double.NaN;

            Vector2D a = PositionVector,
                     b = DirectionVector,
                     c = f.PositionVector,
                     d = f.DirectionVector;

            s = ((b.X * (c.Y - a.Y)) - (b.Y * (a.X + c.X))) / ((b.Y * d.X) - (b.X * d.Y));
            r = ((d.X * s) + c.X - a.X) / b.X;
        }
        public override string ToString() => this;
        public static implicit operator string(VectorFunction2D fun) => $"g: x = ({fun.PositionVector}) + r({fun.DirectionVector})";
    }
}
