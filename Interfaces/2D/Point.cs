namespace FaceMaterial.Terrain.Interfaces
{
    public abstract class Point<T, P, V>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public abstract bool IsEmpty();

        public abstract bool EqualsTo (P b);
        public abstract bool EqualsToX(P b);
        public abstract bool EqualsToY(P b);

        public abstract P Move(V vector);
        public abstract P Move(T x);
        public abstract P Move(T x, T y);

        public abstract override string ToString();
    }
}
