using System;

namespace ClockWiseTreeSearch
{
    public class Node<T>
    {
        public T Value { get; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public override string ToString() => 
            Value.ToString();
    }
}
