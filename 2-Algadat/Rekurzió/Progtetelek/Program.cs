namespace Progtetelek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "datolya";
            Console.WriteLine($"Fordítva: {Reverse(s)}");

            List<int> x = [5, 2, 2, -1, 7, 2, -3, 6];
            Console.WriteLine($"Párosak száma: {Count(x, x.Count-1)}");
            Console.WriteLine($"Van-e negatív? {Any(x, x.Count-1)}");
            Console.WriteLine($"Egy negatív elem: {Find(x, x.Count-1)}");
            Console.WriteLine($"Az első negatív elem: {FindFirst(x, 0)}");
            List<int> y = [];
            Filter(x, x.Count - 1, y);
            Console.WriteLine($"Negatívak: {string.Join(";", Filter(x, x.Count-1))}");
            Console.WriteLine($"Maximum: {Max(x, x.Count-1)}");

            s = "kosarasok";
            Console.WriteLine($"Palindrom-e? {IsPalindrome(s, 0, s.Length-1)}");

            x = [1, 2, 3, 5, 6, 7, 9, 12, 13, 15, 17];
            int? i = BinSearch(x, 5, 0, x.Count - 1);
            string? result = (i == null) ? "-" : i.ToString();
            Console.WriteLine($"5-ös elem indexe: {result}");

            x = [5, 9, 11, 3, 6, 7, 2, 3, 7, 9, 8, 6];
            Console.WriteLine($"Gyorsrendezés: {string.Join(";", QuickSort(x))}");
        }

        static List<int> QuickSort(List<int> x)
        {
            if (x.Count == 0) return [];

            int pivot = x[x.Count - 1];

            List<int> smaller = []; // pivot-nál kisebb vagy egyenlő elemek
            List<int> bigger = []; // pivot-nál nagyobb elemek
            for (int i = 0; i < x.Count-1; i++)
            {
                if (x[i] <= pivot) smaller.Add(x[i]);
                else bigger.Add(x[i]);
            }

            List<int> result = [];
            result.AddRange(QuickSort(smaller));
            result.Add(pivot);
            result.AddRange(QuickSort(bigger));
            return result;
        }

        static int? BinSearch(List<int> x, int e, int left, int right)
        {
            if (left > right) return null;
            int mid = (left + right) / 2;
            if (x[mid] == e) return mid;
            if (x[mid] > e) return BinSearch(x, e, left, mid - 1);
            return BinSearch(x, e, mid + 1, right);
        }

        static bool IsPalindrome(string s, int left, int right)
        {
            if (left >= right) return true;
            if (s[left] != s[right]) return false;
            return IsPalindrome(s, left + 1, right - 1);
        }

        // Feltehető, hogy van elem a tömbben!
        static int Max(List<int> x, int i)
        {
            if (i == 0) return x[i];
            int m = Max(x, i - 1);
            if (x[i] > m) return x[i];
            return m;
        }

        // if (x[i] < 0) return [x[i], ..Filter(x, i - 1)];
        /*
         *  var others = Filter(x, i - 1);
            others.Add(x[i]);
            return others;
         */
        static IEnumerable<int> Filter(List<int> x, int i)
        {
            if (i < 0) return [];
            if (x[i] < 0) return Filter(x, i - 1).Append(x[i]);
            return Filter(x, i - 1);
        }

        static void Filter(List<int> x, int i, List<int> y)
        {
            if (i < 0) return;
            if (x[i] < 0) y.Add(x[i]);
            Filter(x, i - 1, y);
        }

        // Az első i indexű elem közül megadja az első negatívat.
        static int? FindFirst(List<int> x, int i)
        {
            if (i >= x.Count) return null;
            if (x[i] < 0) return x[i];
            return FindFirst(x, i+1);
        }

        // Megad egy negatív értékű elemet.
        // (Ha nincs, akkor null-t adunk.)
        // => az utolsót adja
        // Lineáris keresés O(n)
        static int? Find(List<int> x, int i)
        {
            if (i < 0) return null;
            if (x[i] < 0) return x[i];
            return Find(x, i - 1);
        }

        // Van-e negatív az első i indexű elem között?
        static bool Any(List<int> x, int i)
        {
            if (i < 0) return false; // üres tömbben nincs negatív
            if (x[i] < 0) return true;
            return Any(x, i - 1);
        }

        // Megadja az i-dik indexű elemig a párosak számát.
        static int Count(List<int> x, int i)
        {
            if (i < 0) return 0;
            if (x[i] % 2 == 0) return 1 + Count(x, i - 1);
            return 0 + Count(x, i - 1);
        }

        // Becsomagoljuk a rekurzív függvényt
        static string Reverse(string s)
        {
            return RecReverse(s, s.Length - 1);
        }

        // i-dik karakterig fordítja meg
        // s: a megfordítandó szöveg
        // i: azon karakter indexe, ahol járunk a megfordításban
        static string RecReverse(string s, int i)
        {
            if (i < 0) return "";
            return s[i] + RecReverse(s, i - 1);
        }
    }
}
