using System;
using System.Collections.Generic;
using System.Linq;

namespace ClockWiseTreeSearch
{
    public static class TreeExtensions
    {
        public class QueueEntry<T>
        {
            public Node<T> Node { get; }
            public int Level { get; }

            public QueueEntry(Node<T> node, int level)
            {
                if (level < 0)
                    throw new ArgumentOutOfRangeException(nameof(level));

                Node = node ?? throw new ArgumentNullException(nameof(node));
                Level = level;
            }
        }

        public static IEnumerable<T> ClockWiseSearch<T>(this Tree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            return tree
                    .Levels()
                    .ReverseRowsInBottomHalf()
                    .AlternateRowsVertically()
                    .SelectMany(level => level);
        }

        public static T[][] Levels<T>(this Tree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            List<List<T>> levels = new List<List<T>>();

            Queue<QueueEntry<T>> queue = new Queue<QueueEntry<T>>();
            queue.Enqueue(new QueueEntry<T>(tree.Root, level: 0));

            while (queue.Count != 0)
            {
                QueueEntry<T> entry = queue.Dequeue();

                if (levels.Count == entry.Level)
                    levels.Add(new List<T>());

                levels[entry.Level].Add(entry.Node.Value);

                if (entry.Node.Left != null)
                    queue.Enqueue(new QueueEntry<T>(entry.Node.Left, level: entry.Level + 1));

                if (entry.Node.Right != null)
                    queue.Enqueue(new QueueEntry<T>(entry.Node.Right, level: entry.Level + 1));
            }

            return levels
                    .Select(level => level.ToArray())
                    .ToArray();
        }
    }
}
