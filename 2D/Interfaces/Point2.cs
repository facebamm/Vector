namespace FaceMaterial.Vector.D2
{
    public abstract class Point2<T, R>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public abstract bool IsEmpty();

        public abstract bool EqualsTo(R b);
        public abstract bool EqualsToX(R b);
        public abstract bool EqualsToY(R b);

        public abstract R Move(Vector2D vector);
        public abstract R Move(T x, T y);

        public abstract override string ToString();
    }
}
