namespace FaceMaterial.Vector.D2
{
    public abstract class Vector2<T,R> {

        public T X { get; set; }
        public T Y { get; set; }
        
        public abstract double Value();
        public abstract bool IsEmpty();

        public abstract bool EqualsTo(R b);
        public abstract bool EqualsToX(R b);
        public abstract bool EqualsToY(R b);

        public abstract bool EqualsXY();

        public abstract override string ToString();

        protected abstract R Add(R otherVector);
        protected abstract R Sub(R otherVector);
        protected abstract R Mul(R otherVector);
        protected abstract R Div(R otherVector);
                           
        protected abstract R Add(T otherVector);
        protected abstract R Sub(T otherVector);
        protected abstract R Mul(T otherVector);
        protected abstract R Div(T otherVector);

        public static R operator +(Vector2<T, R> a, R b) => a.Add(b);
        public static R operator -(Vector2<T, R> a, R b) => a.Sub(b);
        public static R operator *(Vector2<T, R> a, R b) => a.Mul(b);
        public static R operator /(Vector2<T, R> a, R b) => a.Div(b);
                      
        public static R operator +(Vector2<T, R> a, T b) => a.Add(b);
        public static R operator -(Vector2<T, R> a, T b) => a.Sub(b);
        public static R operator *(Vector2<T, R> a, T b) => a.Mul(b);
        public static R operator /(Vector2<T, R> a, T b) => a.Div(b);
                      
        public static R operator +(T a, Vector2<T,R> b) => b.Add(a);
        public static R operator -(T a, Vector2<T,R> b) => b.Sub(a);
        public static R operator *(T a, Vector2<T,R> b) => b.Mul(a);
        public static R operator /(T a, Vector2<T,R> b) => b.Div(a);

        public static implicit operator Vector2D(Vector2<T, R> vector)
        {
            double.TryParse(vector.X.ToString(), out double x);
            double.TryParse(vector.Y.ToString(), out double y);
            return new Vector2D(x, y);
        }
    }
}
