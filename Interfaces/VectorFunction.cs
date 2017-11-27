﻿namespace FaceMaterial.Terrain.Interfaces
{
    public abstract class VectorFunction<T, F, P> {
        public T PositionVector { get; protected set; }
        public T DirectionVector { get; protected set; }

        public abstract bool IsParallelTo(F f);
        public abstract bool IsIdenticalTo(F f);
        public abstract bool IsIntersectTo(F f, out P point);
        public abstract bool IsSkewTo(F f);
        public abstract bool IsEqualTo(F f);
        public abstract bool IsPerpendicularTo(F f);
        public abstract bool IsElement(P point);

        public abstract P GetIntersectPointTo(F f);
        public abstract P GetPoint(double r);
        public abstract bool GetParameter(P point, out T vector);

        public abstract CompareResult CompareTo(F f);
        public abstract void CalcParameter(F f, out double r, out double s);
        
        public static implicit operator string(VectorFunction<T, F, P> fun) => $"g: x = ({fun.PositionVector}) + r({fun.DirectionVector})";
           
    }
}