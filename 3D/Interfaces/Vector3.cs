namespace FaceMaterial.Vector.D3 { 
    public abstract class Vector3<T,R>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }

        protected abstract R Add(R otherVector);
        protected abstract R Sub(R otherVector);
        protected abstract R Mul(R otherVector);
        protected abstract R Div(R otherVector);

        protected abstract R Add(T otherVector);
        protected abstract R Sub(T otherVector);
        protected abstract R Mul(T otherVector);
        protected abstract R Div(T otherVector);

        public static R operator +(Vector3<T,R> a, R b) => a.Add(b);
        public static R operator -(Vector3<T,R> a, R b) => a.Sub(b);
        public static R operator *(Vector3<T,R> a, R b) => a.Mul(b);
        public static R operator /(Vector3<T,R> a, R b) => a.Div(b);
                      
        public static R operator +(Vector3<T,R> a, T b) => a.Add(b);
        public static R operator -(Vector3<T,R> a, T b) => a.Sub(b);
        public static R operator *(Vector3<T,R> a, T b) => a.Mul(b);
        public static R operator /(Vector3<T,R> a, T b) => a.Div(b);
                      
        public static R operator +(R a, Vector3<T,R> b) => b.Add(a);
        public static R operator -(R a, Vector3<T,R> b) => b.Sub(a);
        public static R operator *(R a, Vector3<T,R> b) => b.Mul(a);
        public static R operator /(R a, Vector3<T,R> b) => b.Div(a);

        public abstract bool EqualsTo(R b);
        public abstract bool EqualsToX(R b);
        public abstract bool EqualsToY(R b);
        public abstract bool EqualsToZ(R b);

        public abstract bool EqualsToXY(R b);
        public abstract bool EqualsToXZ(R b);

        public abstract bool EqualsToYZ(R b);

        public abstract bool EqualsXYZ() ;
        public abstract bool EqualsToXY();
        public abstract bool EqualsToYZ();
        public abstract bool EqualsToXZ();

        public abstract bool IsEmpty(R b);

        public abstract override string ToString();

        public static implicit operator Vector3D(Vector3<T, R> vector)
        {
            double.TryParse(vector.X.ToString(), out double x);
            double.TryParse(vector.Y.ToString(), out double y); ;
            double.TryParse(vector.Z.ToString(), out double z);
            return new Vector3D(x,y,z);
        }

    }
}
