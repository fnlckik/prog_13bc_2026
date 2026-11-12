namespace BinarySeries
{
    internal class Program
    {
        const int N = 7;

        static void Main(string[] args)
        {
            LinkedList<int> list = [];
            Backtrack(list);
        }

        // Backtrack: visszalépéses keresés
        // "próba szerencse", "trial & error"
        static void Backtrack(LinkedList<int> list)
        {
            bool finished = list.Count == N; // Végeztünk-e? (Megvan-e a megoldás?)
            if (finished)
            {
                Console.WriteLine(string.Join("", list));
                return;
            }
            for (int i = 0; i <= 1; i++) // Minden lehetséges lépésre...
            {
                if (IsValid(list, i)) // Szabályos-e a lépés?
                {
                    Step(list, i); // Előre lépek
                    Backtrack(list); // Rekurzívan haladok tovább... (Megpróbálom befejezni így a megoldást.)
                    Back(list); // Visszalépek
                }
            }
        }

        static bool IsValid(LinkedList<int> list, int i)
        {
            return true;
        }

        static void Step(LinkedList<int> list, int i)
        {
            list.AddLast(i);
        }

        static void Back(LinkedList<int> list)
        {
            list.RemoveLast();
        }
    }
}
