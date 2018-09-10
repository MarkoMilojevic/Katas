using System;

namespace FunctionalExtensions
{
    public abstract class Option<T>
    {
        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);
        public abstract T Reduce(T whenNone);
        public abstract T Reduce(Func<T> whenNone);
        public abstract Option<T> TryReduce(Func<Option<T>> whenNone);

        public abstract void Do(Action<T> what);

        public abstract Option<TSubtype> When<TSubtype>() where TSubtype : T;
        public abstract Option<T> When(Func<T, bool> predicate);

        public static implicit operator Option<T>(T value) =>
            new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();
    }
}
