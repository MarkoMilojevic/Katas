﻿using System;
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

        public static IEnumerable<Node<T>> ClockWiseSearch<T>(this Tree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            return tree
                    .Levels()
                    .AlternateVertically()
                    .AlternateReverse()
                    .SelectMany(level => level);
        }

        public static List<List<Node<T>>> Levels<T>(this Tree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            List<List<Node<T>>> levels = new List<List<Node<T>>>();

            Queue<QueueEntry<T>> queue = new Queue<QueueEntry<T>>();
            queue.Enqueue(new QueueEntry<T>(tree.Root, level: 0));

            while (queue.Count != 0)
            {
                QueueEntry<T> entry = queue.Dequeue();

                if (levels.Count == entry.Level)
                    levels.Add(new List<Node<T>>());

                levels[entry.Level].Add(entry.Node);

                if (entry.Node.Left != null)
                    queue.Enqueue(new QueueEntry<T>(entry.Node.Left, level: entry.Level + 1));

                if (entry.Node.Right != null)
                    queue.Enqueue(new QueueEntry<T>(entry.Node.Right, level: entry.Level + 1));
            }

            return levels;
        }

        public static List<List<Node<T>>> AlternateVertically<T>(this List<List<Node<T>>> levels) =>
            levels
                .Count
                .AlternateIndexes()
                .Select(i => levels[i])
                .ToList();

        public static List<List<Node<T>>> AlternateReverse<T>(this List<List<Node<T>>> levels) =>
            Enumerable
                .Range(0, levels.Count)
                .Select(i => i % 2 == 0 ? levels[i] : levels[i].AsEnumerable().Reverse().ToList())
                .ToList();

        public static IEnumerable<int> AlternateIndexes(this int n) => 
            Enumerable
                .Range(0, n)
                .Select(i => i % 2 == 0 ? i / 2 : n - ((i + 1) / 2));
    }
}
