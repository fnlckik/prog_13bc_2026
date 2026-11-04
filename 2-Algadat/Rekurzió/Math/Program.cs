using System.Diagnostics;

namespace Math
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"8! = {Factorial(8)}");
            // 1 + 2 + 3 + ... + 10 == 55
            Console.WriteLine($"= {Sum(10)}");
            Console.WriteLine($"Fib(6) = {Fib(6)}");
            Console.WriteLine($"5 alatt 2 = {Bin(5, 2)}");
            Console.WriteLine($"200 alatt 4 = {Bin(200, 4)}");
            //Console.WriteLine($"1000 alatt 5 = {Bin(1000, 5)}");
            Stopwatch sw = new();
            sw.Start();
            Console.WriteLine($"2^800 = {Power(2, 800)}");
            sw.Stop();
            Console.WriteLine($"Idő: {sw.ElapsedTicks}");
            sw.Restart();
            Console.WriteLine($"2^800 = {FastPower(2, 800)}");
            sw.Stop();
            Console.WriteLine($"Idő: {sw.ElapsedTicks}");
        }

        static double Square(double x) => x * x;

        // O(log(n))
        static double FastPower(double a, int n)
        {
            if (n == 0) return 1;
            if (n % 2 == 0) return Square(FastPower(a, n / 2));
            return a * Square(FastPower(a, (n - 1) / 2));
        }

        // O(n)
        static double Power(double a, int n)
        {
            if (n == 0) return 1;
            return a * Power(a, n - 1);
        }

        static int Bin(int n, int k)
        {
            if (k == 0 || k == n) return 1;
            if (k == 1 || k == n - 1) return n;
            return Bin(n - 1, k - 1) + Bin(n - 1, k);
        }

        // n alatt k
        // Gond: túlcsordul a szám típus
        static double Binomial(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        // másodrendű rekurzió
        static int Fib(int n)
        {
            if (n == 1 || n == 2) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }

        // elsőrendű rekurzió
        // 0 + 1 + 2 + 3 + ... + n
        static int Sum(int n)
        {
            if (n == 0) return 0;
            Console.Write($"{n} " + (n == 1 ? "" : "+ "));
            return n + Sum(n - 1);
        }

        static double Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }
    }
}
