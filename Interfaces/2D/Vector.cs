namespace FaceMaterial.Vector.Interfaces
{
    public abstract class Vector<T, V>  {

        public T X { get; set; }
        public T Y { get; set; }

        public abstract double Value();
        public abstract bool IsEmpty();

        public abstract bool EqualsTo (V b);
        public abstract bool EqualsToX(V b);
        public abstract bool EqualsToY(V b);

        public abstract bool EqualsXY();

        public abstract override string ToString();

        protected abstract V Add(V otherVector);
        protected abstract V Sub(V otherVector);
        protected abstract V Mul(V otherVector);
        protected abstract V Div(V otherVector);
                           
        protected abstract V Add(T otherVector);
        protected abstract V Sub(T otherVector);
        protected abstract V Mul(T otherVector);
        protected abstract V Div(T otherVector);

        public static V operator +(Vector<T, V> a, V b) => a.Add(b);
        public static V operator -(Vector<T, V> a, V b) => a.Sub(b);
        public static V operator *(Vector<T, V> a, V b) => a.Mul(b);
        public static V operator /(Vector<T, V> a, V b) => a.Div(b);
                                              
        public static V operator +(Vector<T, V> a, T b) => a.Add(b);
        public static V operator -(Vector<T, V> a, T b) => a.Sub(b);
        public static V operator *(Vector<T, V> a, T b) => a.Mul(b);
        public static V operator /(Vector<T, V> a, T b) => a.Div(b);
                      
        public static V operator +(T a, Vector<T, V> b) => b.Add(a);
        public static V operator -(T a, Vector<T, V> b) => b.Sub(a);
        public static V operator *(T a, Vector<T, V> b) => b.Mul(a);
        public static V operator /(T a, Vector<T, V> b) => b.Div(a);
    }
}
