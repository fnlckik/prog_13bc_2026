namespace Torony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(T(5));
            Console.WriteLine(T(30));
        }

        // Milyen futási idejű ez? O(2^n)
        // Hogyan lehetne hatékonyabban? (dinamikus programozás, lásd: később)
        // harmadrendű lineáris rekurzió
        static double T(int n)
        {
            if (n == 0) return 1; // T(0) = 1
            if (n == 1) return 2;
            if (n == 2) return 4;
            return T(n - 3) + 2 * T(n - 1); // Teteje: F v (P v Z)
            //switch (n)
            //{
            //    case 0: return 1;
            //    case 1: return 2;
            //    case 2: return 4;
            //    default: return T(n - 3) + 2 * T(n - 1);
            //}
        }
    }
}
