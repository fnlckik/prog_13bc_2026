using System.Collections;

namespace Shopping
{
    internal class Q<T> : IEnumerable<T>
    {
        public Q() // üres sor létrehozása
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        private Element<T>? Head { get; set; }
        private Element<T>? Tail { get; set; }
        public int Count { get; private set; }

        public void Add(T value)
        {
            Element<T> e = new(value, null);
            if (Count == 0) Head = e; // első elem legyen az új
            else Tail!.Next = e; // utolsó elem utáni legyen az új
            Tail = e; // utolsó elem az új
            Count++; // egyel több elemünk van
        }

        public T First()
        {
            if (Count == 0) throw new InvalidOperationException("Üres sornak nincs eleme.");
            return Head!.Value;
        }

        public T Pop()
        {
            T first = First();
            Head = Head!.Next;
            if (Head == null) Tail = null; // egy elemű sor törlése
            Count--;
            return first;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Element<T>? current = Head; // Hol állunk most?
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
    }

    internal class Element<T>
    {
        public Element(T value, Element<T>? next)
        {
            Value = value;
            Next = next;
        }

        public T Value { get; set; }
        public Element<T>? Next { get; set; }
    }
}
