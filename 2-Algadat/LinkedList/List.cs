namespace LinkedList
{
    internal class List<T>
    {
        public List()
        {
            Count = 0;
            First = null;
            Last = null;
        }

        public int Count { get; private set; }
        public Node<T>? First { get; private set; }
        public Node<T>? Last { get; private set; }
    }

    internal class Node<T>
    {
        public Node(T value, Node<T>? previous, Node<T>? next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }

        public T Value { get; set; }
        public Node<T>? Previous { get; set; }
        public Node<T>? Next { get; set; }
    }
}
