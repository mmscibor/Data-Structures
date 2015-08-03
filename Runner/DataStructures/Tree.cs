
using System;
using System.Collections;

namespace DataStructures
{
    public class Tree<T> : IEnumerable where T : IComparable
    {
        private Node _root;

        public void Add(T value)
        {
            if (_root == null)
            {
                _root = new Node {Value = value};
                return;
            }

            AddTraverseToLeaf(_root, value);
        }

        public bool Contains(T value)
        {
            Node currentNode = _root;

            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.Value) == 0)
                {
                    return true;
                }

                currentNode = value.CompareTo(currentNode.Value) < 0 ? currentNode.LeftChild : currentNode.RightChild;
            }

            return false;
        }

        private void AddTraverseToLeaf(Node currentNode, T value)
        {
            if (value.CompareTo(currentNode.Value) < 0)
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = new Node {Value = value};
                }
                else
                {
                    AddTraverseToLeaf(currentNode.LeftChild, value);
                }
            }
            else
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = new Node {Value = value};
                }
                else
                {
                    AddTraverseToLeaf(currentNode.RightChild, value);
                }
            }
        }

        private class Node
        {
            public T Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
        }

        public IEnumerator GetEnumerator()
        {
            return new TreeEnumerator(_root);
        }

        private class TreeEnumerator : IEnumerator
        {
            private readonly Stack _visitedStack;
            private Node _currentNode;

            public TreeEnumerator(Node root)
            {
                _visitedStack = new Stack();

                if (root != null)
                {
                    _visitedStack.Push(root);
                }
            }

            public bool MoveNext()
            {
                if (_visitedStack.Count == 0) return false;

                _currentNode = (Node) _visitedStack.Pop();
                
                if (_currentNode.RightChild != null) _visitedStack.Push(_currentNode.RightChild);
                if (_currentNode.LeftChild != null) _visitedStack.Push(_currentNode.LeftChild);

                return true;
            }

            public void Reset()
            {

            }

            public object Current { get { return _currentNode.Value; } }
        }
    }
}
