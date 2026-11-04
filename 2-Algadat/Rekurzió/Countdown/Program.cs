
namespace Countdown
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // rekurzió: önhivatkozás
            //f();
            //C(5);
            Countdown(5);
        }

        static void f()
        {
            Console.WriteLine("f() kezdete.");
            g();
            Console.WriteLine("f() vége.");
        }

        static void g()
        {
            Console.WriteLine("g() kezdete.");
            h();
            Console.WriteLine("g() vége.");
        }

        static void h()
        {
            Console.WriteLine("h() kezdete.");
            Console.WriteLine("h() vége.");
        }

        // iteratív
        private static void C(int n)
        {
            while (true)
            {
                Console.WriteLine(n);
                n--;
            }
        }

        // rekurzív 5 -> 4 -> 3 -> 2 -> ...
        private static void Countdown(int n)
        {
            if (n < 0) return; // leállási feltétel (báziskritérium)
            Console.WriteLine(n);
            Countdown(n - 1);
        }
    }
}
