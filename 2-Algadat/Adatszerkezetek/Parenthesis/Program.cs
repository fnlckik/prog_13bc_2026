namespace Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mikor helyes egy zárójelezés?
            // Minden nyitott zárójelet le is zárunk.
            // Legutoljára megnyitott zárójelet kell legelőször lezárni.
            Console.WriteLine(IsValid("(2+(a)sd)* 5")); // true
            Console.WriteLine(IsValid("(2+))(asd* 5")); // false => hamarabb zártam le, minthogy megnyitottam
            Console.WriteLine(IsValid("(2+(asd)* 5")); // false => nincs lezárva az egyik
            Console.WriteLine(IsValid("(a+b) * (b+d)")); // true
            Console.WriteLine();

            Console.WriteLine(IsValid("(2 + ([5] - 1) - [2*5])")); // true
            Console.WriteLine(IsValid("(2 + [3 - 4) + ]")); // false
            Console.WriteLine(IsValid("(2 + 3) [- 4)")); // false
            Console.WriteLine(IsValid("(2 + 3) [- 4")); // false
        }

        // LIFO => Stack
        private static bool IsValid(string expression)
        {
            Stack<char> stack = [];
            foreach (char c in expression)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) return false;
                    if (c == ')' && stack.Peek() != '(') return false;
                    if (c == ']' && stack.Peek() != '[') return false;
                    if (c == '}' && stack.Peek() != '{') return false;
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
    }
}
