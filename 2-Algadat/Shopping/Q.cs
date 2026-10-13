namespace Shopping
{
    internal class Q
    {
        public Q() // üres sor létrehozása
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        private Element? Head { get; set; }
        private Element? Tail { get; set; }
        public int Count { get; private set; }

        public void Add(string value)
        {
            Element e = new(value, null);
            if (Count == 0) Head = e; // első elem legyen az új
            else Tail!.Next = e; // utolsó elem utáni legyen az új
            Tail = e; // utolsó elem az új
            Count++; // egyel több elemünk van
        }

        public string First()
        {
            if (Count == 0) throw new InvalidOperationException("Üres sornak nincs eleme.");
            return Head!.Value;
        }
    }

    internal class Element
    {
        public Element(string value, Element? next)
        {
            Value = value;
            Next = next;
        }

        public string Value { get; set; }
        public Element? Next { get; set; }
    }
}
