using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BinarySearchTree<T>:IEnumerable<T>
    {
        private Node<T> top;
        private readonly IComparer<T> comparer;

        public BinarySearchTree(IComparer<T> comparer = null)
        {
            top = null;
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public BinarySearchTree(IEnumerable<T> items, IComparer<T> comparer = null) : this(comparer)
        {
            if (ReferenceEquals(items, null))
                throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
                Add(item);
        }

        public bool IsEmpty() => top == null;

        public bool Add(T value)
        {
            if (IsEmpty())
            {
                this.top = new Node<T>(value);
                return true;
            }
            Node<T> current = this.top;
            bool added = false;
            do
            {
                if (comparer.Compare(value, current.Value) > 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node<T>(value);
                        added = true;
                    }
                    current = current.Right;
                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node<T>(value);
                        added = true;
                    }
                    current = current.Left;
                }
            } while (!added);
            return true;
        }

        public IEnumerator<T> GetPreorderEnumerator()
        {
            Node<T> current = this.top;
            Stack<Node<T>> stack = new Stack<Node<T>>();
            while (current != null || stack.Count != 0)
            {
                if (stack.Count != 0) current = stack.Pop();
                while (current != null)
                {
                    yield return current.Value;
                    if (current.Right != null) stack.Push(current.Right);
                    current = current.Left;
                }
            }
        }

        public IEnumerator<T> GetInorderEnumerator()
        {
            Node<T> current = this.top;
            Stack<Node<T>> stack = new Stack<Node<T>>();
            while (current != null || stack.Count != 0)
            {
                if (stack.Count != 0)
                {
                    current = stack.Pop();
                    yield return current.Value;
                    current = current.Right;
                }
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
            }
        }

        public IEnumerator<T> GetPostorderEnumerator()
        {
            Node<T> current = top;
            Stack<Node<T>> stack = new Stack<Node<T>>();
            while (current != null || stack.Count != 0)
            {
                if (stack.Count != 0)
                {
                    current = stack.Pop();
                    if (stack.Count != 0 && current.Right == stack.Last())
                    {
                        current = stack.Pop();
                    }
                    else
                    {
                        yield return current.Value;
                        current = null;
                    }
                }
                while (current != null)
                {
                    stack.Push(current);
                    if (current.Right != null)
                    {
                        stack.Push(current.Right);
                        stack.Push(current);
                    }
                    current = current.Left;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetPreorderEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
