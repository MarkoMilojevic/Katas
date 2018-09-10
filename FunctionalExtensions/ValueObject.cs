using System.Collections.Generic;
using System.Linq;

namespace FunctionalExtensions
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
    /// </summary>
    public abstract class ValueObject
    {
        public static bool operator ==(ValueObject left, ValueObject right) =>
            !(left is null ^ right is null) && (left is null || left.Equals(right));

        public static bool operator !=(ValueObject left, ValueObject right) =>
            !(left == right);

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject) obj;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current is null ^ otherValues.Current is null)
                    return false;

                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                    return false;
            }

            bool result = !thisValues.MoveNext() && !otherValues.MoveNext();

            thisValues.Dispose();
            otherValues.Dispose();

            return result;
        }

        public override int GetHashCode() =>
            GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);

        public abstract override string ToString();
    }
}
