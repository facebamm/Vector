namespace FaceMaterial.Vector.D3
{
    public abstract class Point3<T, R>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }

        public abstract bool EqualsTo(R b);
        public abstract bool EqualsToX(R b);
        public abstract bool EqualsToY(R b);
        public abstract bool EqualsToZ(R b);

        public abstract bool EqualsToXY(R b);
        public abstract bool EqualsToXZ(R b);

        public abstract bool EqualsToYZ(R b);

        public abstract bool EqualsXYZ();
        public abstract bool EqualsXY();
        public abstract bool EqualsYZ();
        public abstract bool EqualsXZ();

        public abstract override string ToString();
    }
}
