using System.Collections;

namespace LinkedList
{
    internal class List<T> : IEnumerable<T>
    {
        public List()
        {
            Count = 0;
            First = null;
            Last = null;
        }

        public List(IEnumerable<T> collection)
        {
            Count = 0;
            First = null;
            Last = null;
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public int Count { get; private set; }
        public Node<T>? First { get; private set; }
        public Node<T>? Last { get; private set; }

        public void AddLast(T value)
        {
            Node<T> e = new(Last, value, null);
            if (Count == 0) First = e;
            else Last!.Next = e;
            Last = e;
            Count++;
        }

        public void AddAfter(Node<T> node, T value)
        {
            Node<T> e = new(node, value, node.Next);
            node.Next = e;
            if (e.Next != null) // nem utolsóként szúrjuk be
            {
                e.Next.Previous = e;
            }
            else // utolsóként szúrjuk be
            {
                Last = e;
            }
            Count++;
        }

        public Node<T>? Find(T value) // O(n)
        {
            if (value == null) throw new ArgumentNullException();
            Node<T>? e = First;
            while (e != null && !(value.Equals(e.Value)))
            {
                e = e.Next;
            }
            return e;
        }

        public void Remove(Node<T> e) // O(1)
        {
            if (e.Previous != null && e.Next != null) // középső törlése
            {
                e.Previous.Next = e.Next;
                e.Next.Previous = e.Previous;
            }
            else if (e.Previous != null) // utolsó törlése
            {
                e.Previous.Next = null;
                Last = e.Previous;
            }
            else if (e.Next != null) // első törlése
            {
                e.Next.Previous = null;
                First = e.Next;
            }
            else // 1 elemű lista törlése
            {
                First = null;
                Last = null;
                //e = null;
            }
            Count--;
        }

        public void RemoveLast() // O(1)
        {
            if (Last != null) this.Remove(Last);
        }

        public void Remove(T value) // O(n) + O(1) => O(n)
        {
            Node<T>? node = this.Find(value);
            if (node != null) this.Remove(node);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException($"A(z) {index} nem valid index.");
                }
                Node<T>? current = First;
                for (int i = 0; i < index; i++)
                {
                    current = current!.Next;
                }
                return current!.Value;
            }
        }
    }

    internal class Node<T>
    {
        public Node(Node<T>? previous, T value, Node<T>? next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }

        public T Value { get; set; }
        public Node<T>? Previous { get; set; }
        public Node<T>? Next { get; set; }

        public override string ToString()
        {
            return Value?.ToString() ?? "";
        }
    }
}
