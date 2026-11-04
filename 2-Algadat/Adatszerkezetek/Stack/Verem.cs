using System.Collections;

namespace Stack
{
    public class Verem : IEnumerable<int>
    {
        public Verem()
        {
            Elemszam = 0;
            Teto = null;
        }

        public int Elemszam { get; private set; } // Count
        public Elem? Teto { get; private set; } // Top

        public void Verembe(int value) // Push()
        {
            Elem e = new(value, Teto); // új elem, amit az eddigi tető követ
            Teto = e; // új elem a verem tetejére
            Elemszam++; // egyel több elemünk van
        }

        public int Teteje() // Peek()
        {
            if (Elemszam == 0) throw new InvalidOperationException("Eme verem elemetlen.");
            return Teto!.Value;
        }

        public int Verembol() // Pop()
        {
            int teteje = Teteje();
            Teto = Teto!.Next;
            Elemszam--;
            return teteje;
        }

        public IEnumerator<int> GetEnumerator()
        {
            Elem? e = Teto;
            while (e != null)
            {
                yield return e.Value;
                e = e.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Elem
    {
        public Elem(int value, Elem? next)
        {
            Value = value;
            Next = next;
        }

        public int Value { get; set; }
        public Elem? Next { get; set; }
    }
}
