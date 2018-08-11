using System;

namespace CoinChange
{
    public abstract class Option<T>
    {
        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);
        public abstract T Reduce(T whenNone);
        public abstract T Reduce(Func<T> whenNone);
        public abstract Option<T> TryReduce(Func<Option<T>> whenNone);
        
        public static implicit operator Option<T>(T value) =>
            new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();
    }
}
