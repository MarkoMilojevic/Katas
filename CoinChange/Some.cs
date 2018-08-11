using System;

namespace CoinChange
{
    public class Some<T> : Option<T>
    {
        private T Content { get; }

        public Some(T content) =>
            Content = content;

        public override Option<TResult> Map<TResult>(Func<T, TResult> map) =>
            new Some<TResult>(map(Content));

        public override T Reduce(T whenNone) =>
            Content;

        public override T Reduce(Func<T> whenNone) =>
            Content;
        public override Option<T> TryReduce(Func<Option<T>> whenNone) =>
            this;
    }
}
