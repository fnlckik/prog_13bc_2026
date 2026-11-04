using System.Reflection.Metadata.Ecma335;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new();
            stack.Push("alma");
            stack.Push("barack");
            stack.Push("citrom");
            stack.Push("dinnye");
            Console.WriteLine($"Elemek: {string.Join(";", stack)}");
            Console.WriteLine($"Tető elem: {stack.Peek()}");
            Console.WriteLine($"Tető eltávolítása: {stack.Pop()}");
            Console.WriteLine($"Elemek száma: {stack.Count}");

            // Saját verem
            Verem v = new();
            v.Verembe(3);
            v.Verembe(1);
            v.Verembe(4);
            v.Verembol(); // 4-et kivesszük
            Console.WriteLine($"Eme verem teteje: {v.Teteje()}"); // 1
            Console.WriteLine($"Elemek száma: {v.Elemszam}");
            Console.WriteLine();

            // Számrendszer váltás (10-ből a-ba)
            Stack<int> result = ToBase(418, 3); // 120111
            Console.WriteLine($"418_10 = {string.Join("", result)}_3");

            Verem eredmeny = ToBase_Verem(418, 3);
            Console.WriteLine($"418_10 = {string.Join("", eredmeny)}_3");
        }

        private static Verem ToBase_Verem(int n, int a)
        {
            Verem result = new();
            do
            {
                result.Verembe(n % a);
                n /= a;
            } while (n > 0);
            return result;
        }

        private static Stack<int> ToBase(int n, int a)
        {
            Stack<int> result = new();
            do
            {
                result.Push(n % a);
                n /= a;
            } while (n > 0);
            return result;
        }
    }
}
