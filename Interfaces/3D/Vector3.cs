namespace FaceMaterial.Terrain.Interfaces
{ 
    public abstract class Vector3<T,V> : Vector<T, V> where V : Vector3<T,V>
    {
        public T Z { get; set; }

        protected override abstract V Add(V otherVector);
        protected override abstract V Sub(V otherVector);
        protected override abstract V Mul(V otherVector);
        protected override abstract V Div(V otherVector);

        protected override abstract V Add(T otherVector);
        protected override abstract V Sub(T otherVector);
        protected override abstract V Mul(T otherVector);
        protected override abstract V Div(T otherVector);

        public static V operator +(Vector3<T,V> a, V b) => a.Add(b);
        public static V operator -(Vector3<T,V> a, V b) => a.Sub(b);
        public static V operator *(Vector3<T,V> a, V b) => a.Mul(b);
        public static V operator /(Vector3<T,V> a, V b) => a.Div(b);

        public static V operator +(V a, Vector3<T, V> b) => b.Add(a);
        public static V operator -(V a, Vector3<T, V> b) => b.Sub(a);
        public static V operator *(V a, Vector3<T, V> b) => b.Mul(a);
        public static V operator /(V a, Vector3<T, V> b) => b.Div(a);

        public static V operator +(Vector3<T,V> a, T b) => a.Add(b);
        public static V operator -(Vector3<T,V> a, T b) => a.Sub(b);
        public static V operator *(Vector3<T,V> a, T b) => a.Mul(b);
        public static V operator /(Vector3<T,V> a, T b) => a.Div(b);

        public override abstract bool EqualsTo(V b);
        public override abstract bool EqualsToX(V b);
        public override abstract bool EqualsToY(V b);
        public abstract bool EqualsToZ(V b);
        public abstract bool EqualsToXY(V b);
        public abstract bool EqualsToXZ(V b);
        public abstract bool EqualsToYZ(V b);

        public override abstract bool EqualsXY();
        public abstract bool EqualsYZ();
        public abstract bool EqualsXZ();
        public abstract bool EqualsXYZ();

        public abstract V Cross(V b);

        public override abstract bool IsEmpty();
        public override abstract double Value();
        public abstract override string ToString(); 
    }
}
