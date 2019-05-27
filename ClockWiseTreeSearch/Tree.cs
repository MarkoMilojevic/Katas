using System;

namespace ClockWiseTreeSearch
{
    public class Tree<T>
    {
        public Node<T> Root { get; }

        public Tree(Node<T> root) => 
            Root = root ?? throw new ArgumentNullException(nameof(root));
    }
}
