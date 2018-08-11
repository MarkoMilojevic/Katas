using System;

namespace CoinChange
{
    public class None<T> : Option<T>
    {
        public override Option<TResult> Map<TResult>(Func<T, TResult> map) =>
            new None<TResult>();

        public override T Reduce(T whenNone) =>
            whenNone;

        public override T Reduce(Func<T> whenNone) =>
            whenNone();

        public override Option<T> TryReduce(Func<Option<T>> whenNone) =>
            whenNone();
    }

    public class None
    {
        public static None Value { get; } = new None();
        private None() { }
    }
}
