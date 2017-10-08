﻿namespace FaceMaterial.Vector.D3
{
    public class VectroFunction3D : VectorFunction<Vector3D, VectroFunction3D, Point3D>
    {
        public VectroFunction3D(Vector3D positionvector, Vector3D directionvector)
        {
            PositionVector = positionvector;
            DirectionVector = directionvector;
        }

        public override CompareResult CompareTo(VectroFunction3D f)
        {

            bool kolli = Vector3D.IsKollinaer(DirectionVector, f.DirectionVector);

            if (kolli)
                if (IsElement((Point3D)f.PositionVector))
                    return CompareResult.Identical;
                else
                    return CompareResult.Parallel;
            else
                if (IsEqualTo(f))
                    return CompareResult.Intersect;

            return CompareResult.Skew;
        }

        public override Point3D GetIntersectPointTo(VectroFunction3D f)
        {
            IsIntersectTo(f, out Point3D p);
            return p;
        }

        public override bool IsElement(Point3D point) {
            if (DirectionVector.Equals(Vector3D.NullVector))
                return PositionVector.Equals((Vector3D)point);

            Vector3D vec = (Vector3D)point - PositionVector;
            vec = vec / DirectionVector;

            return vec.X == vec.Y && vec.Y == vec.Z;
        }

        public override bool IsEqualTo(VectroFunction3D f) {
            CalcParameter(f, out double r, out double s);

            double Zg = PositionVector.Z + (r * DirectionVector.Z);
            double Zh = f.PositionVector.Z + (s * f.DirectionVector.Z);

            return Zg == Zh;
        }

        public override bool IsIdenticalTo(VectroFunction3D f) => CompareTo(f) == CompareResult.Skew;
        public override bool IsIntersectTo(VectroFunction3D f, out Point3D point)
        {
            bool isintersect = IsIdenticalTo(f);
            point = Point3D.NullPoint;

            if (isintersect) {
                CalcParameter(f, out double r, out double s);
                Vector3D res = (Vector3D) Value(r) - (Vector3D) f.Value(s);
                point = (Point3D) res;
            }

            return isintersect;
        }

        public override bool IsParallelTo(VectroFunction3D f) => CompareTo(f) == CompareResult.Parallel;
        public override bool IsSkewTo(VectroFunction3D f) => CompareTo(f) == CompareResult.Skew;

        public override Point3D Value(double r) => (Point3D) (PositionVector + r * DirectionVector);
        public override void CalcParameter(VectroFunction3D f, out double r, out double s)
        {
            r = double.NaN;
            s = double.NaN;

            Vector3D a = PositionVector,
                     b = DirectionVector,
                     c = f.PositionVector,
                     d = f.DirectionVector;

            s = ((b.X * (c.Y - a.Y)) - (b.Y * (a.X + c.X))) / ((b.Y * d.X) - (b.X * d.Y));
            r = ((d.X * s) + c.X - a.X) / b.X;
        }
    }
}
