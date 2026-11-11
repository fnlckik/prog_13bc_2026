namespace Hanoi
{
    internal class Program
    {
        static int k = 1;

        static void Main(string[] args)
        {
            Console.WriteLine(H(5));
            Console.WriteLine(H(12)); // 2^n - 1
            Console.WriteLine();

            // Cél: A-ról C-re B segítségével
            Hanoi(5, 'A', 'C', 'B');
        }

        // k. lépésnél következik
        static void Hanoi(int n, char from, char to, char with)
        {
            if (n == 0) return;
            Hanoi(n - 1, from, with, to);
            Console.WriteLine($"{k}. lépés: {from} -> {to}");
            k++;
            Hanoi(n - 1, with, to, from);
        }

        static int H(int n)
        {
            if (n == 1) return 1;
            return 2 * H(n - 1) + 1;
        }
    }
}
