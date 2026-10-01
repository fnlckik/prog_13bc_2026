using System.Diagnostics;

namespace Hatekonysag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hatékonyság => csak működő, helyes programra
            // 1. Memória => kevés memóriát használjuk
            // 2. Processzor => gyors futási idő => kevés lépés
            Stopwatch sw = new();

            ulong n = 17_000_000;
            sw.Start();
            double sum = RecipSquareSum(n); // lineáris idejű
            sw.Stop();
            Console.WriteLine($"RecipSquareSum({n}) = {sum}");
            Console.WriteLine($"Idő: {sw.ElapsedTicks}"); // időegység
            Console.WriteLine();

            List<int> t = [4, 7, 2, 3, 3, 5, 7, 8]; // memóriában egymás mellett elhelyezkedő elemek sorozata
            int k = 5;
            sw.Restart();
            int e = t[k-1]; // indexelés => konstans idejű
            sw.Stop();
            Console.WriteLine($"Index[{k}] = {e}");
            Console.WriteLine($"Idő: {sw.ElapsedTicks}");
            Console.WriteLine();

            int a = 1000000000;
            sw.Restart();
            double psum = ProdSum3(a); // négyzetes idejű
            sw.Stop();
            Console.WriteLine($"ProdSum3({a}) = {psum}");
            Console.WriteLine($"Idő: {sw.ElapsedTicks}");
            Console.WriteLine();

            int b = 1000;
            sw.Restart();
            double tsum = TriangleSum(b); // négyzetes idejű
            sw.Stop();
            Console.WriteLine($"TriangleSum({b}) = {tsum}");
            Console.WriteLine($"Idő: {sw.ElapsedTicks}");
            Console.WriteLine();
        }

        // Négyzetes
        static double TriangleSum(int n)
        {
            double s = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    s += i * j;
                }
            }
            return s;
        }

        // Konstans
        static double ProdSum3(int n)
        {
            double x = (1 + n) * n / 2; //>> 1;
            return x * x;
        }

        // Lineáris
        static double ProdSum2(int n)
        {
            double sor = 0; // első sor összege
            for (int i = 1; i <= n; i++)
            {
                sor += i;
            }
            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += sor * i;
            }
            return result;
        }

        // Négyzetes
        static double ProdSum(int n)
        {
            double s = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    s += i * j;
                }
            }
            return s;
        }

        static double RecipSquareSum(ulong n)
        {
            double sum = 0;
            for (ulong i = 1; i <= n; i++)
            {
                //sum += 1.0 / (i * i); // Pl.: n = 100000 esetén overflow int-re
                //sum += (1.0 / i) / i; // helyes, de az osztás drága
                //sum += 1.0 / ((double)i * i);
                //sum += (1.0 / i) / (1.0 / i); // helyes
                double x = 1f / i; // futási idő VS memória idő
                sum += x * x;
            }
            return sum;
        }
    }
}
