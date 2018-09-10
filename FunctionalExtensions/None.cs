using System;

namespace FunctionalExtensions
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

        public override void Do(Action<T> what) { }

        public override Option<TSubtype> When<TSubtype>() =>
            None.Value;

        public override Option<T> When(Func<T, bool> predicate) =>
            this;
    }

    public class None
    {
        public static None Value { get; } = new None();
        private None() { }
    }
}
