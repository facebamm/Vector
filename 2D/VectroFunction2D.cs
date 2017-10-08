using FaceMaterial.Vector.Interfaces;
namespace FaceMaterial.Vector.D2
{
    public class VectroFunction2D : VectorFunction<Vector, VectroFunction2D, Point>
    {
        public VectroFunction2D(Vector positionvector, Vector directionvector)
        {
            PositionVector = positionvector;
            DirectionVector = directionvector;
        }

        public override CompareResult CompareTo(VectroFunction2D f)
        {

            bool kolli = Vector.IsKollinaer(DirectionVector, f.DirectionVector);

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

        public override Point GetIntersectPointTo(VectroFunction2D f)
        {
            IsIntersectTo(f, out Point p);
            return p;
        }

        public override bool IsElement(Point point)
        {
            if (DirectionVector.Equals(Vector.NullVector))
                return PositionVector.Equals(point);

            Vector vec = point - PositionVector;
            vec = vec / DirectionVector;

            return vec.X == vec.Y;
        }

        public override bool IsEqualTo(VectroFunction2D f)
        {
            CalcParameter(f, out double r, out double s);

            double Yg = PositionVector.Y + (r * DirectionVector.Y);
            double Yh = f.PositionVector.Y + (s * f.DirectionVector.Y);

            return Yg == Yh;
        }

        public override bool IsIdenticalTo(VectroFunction2D f) => CompareTo(f) == CompareResult.Skew;
        public override bool IsIntersectTo(VectroFunction2D f, out Point point)
        {
            bool isintersect = IsIdenticalTo(f);
            point = Point.NullPoint;

            if (isintersect)
            {
                CalcParameter(f, out double r, out double s);
                Vector res = Value(r) - (Vector) f.Value(s);
                point = res;
            }

            return isintersect;
        }

        public override bool IsParallelTo(VectroFunction2D f) => CompareTo(f) == CompareResult.Parallel;
        public override bool IsSkewTo(VectroFunction2D f) => CompareTo(f) == CompareResult.Skew;

        public override Point Value(double r) => PositionVector + r * DirectionVector;
        public override void CalcParameter(VectroFunction2D f, out double r, out double s)
        {
            r = double.NaN;
            s = double.NaN;

            Vector a = PositionVector,
                     b = DirectionVector,
                     c = f.PositionVector,
                     d = f.DirectionVector;

            s = ((b.X * (c.Y - a.Y)) - (b.Y * (a.X + c.X))) / ((b.Y * d.X) - (b.X * d.Y));
            r = ((d.X * s) + c.X - a.X) / b.X;
        }
    }
}
