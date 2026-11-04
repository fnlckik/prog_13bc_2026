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
