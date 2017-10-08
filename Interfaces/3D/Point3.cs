namespace FaceMaterial.Terrain.Interfaces
{
    public abstract class Point3<T, P, V> : Point<T, P, V>
    {
        public T Z { get; set; }

        public abstract P Move(T x, T y, T z);
        public abstract override P Move(V vector);

        public abstract override bool EqualsTo(P b);
        public abstract override bool EqualsToX(P b);
        public abstract override bool EqualsToY(P b);
        public abstract override bool IsEmpty();

        public abstract bool EqualsToZ(P b);

        public abstract bool EqualsToXY(P b);
        public abstract bool EqualsToXZ(P b);
                                        
        public abstract bool EqualsToYZ(P b);

        public abstract bool EqualsXYZ();
        public abstract bool EqualsXY();
        public abstract bool EqualsYZ();
        public abstract bool EqualsXZ();

        public abstract override string ToString();
    }
}
