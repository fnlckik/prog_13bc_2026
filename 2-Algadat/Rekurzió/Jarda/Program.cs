namespace Jarda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Jarda(4)); // 5
            Console.WriteLine(Jarda(12)); // 233
            Console.WriteLine(Jarda(32));
            Console.WriteLine(a(7)); // 2356
        }

        // a(n): a 2xn-es teljes téglalap hányféleképp fedhető
        static int a(int n)
        {
            if (n == 1) return 2;
            if (n == 2) return 7;
            return 2 * a(n - 1) + a(n - 2) + 2 * b(n - 1);
        }

        // b(n): a 2xn-es csonka téglalap hányféleképp fedhető
        static int b(int n)
        {
            if (n == 1) return 1;
            return a(n - 1) + b(n - 1);
        }

        static int Jarda(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            return Jarda(n - 1) + Jarda(n - 2);
        }
    }
}
