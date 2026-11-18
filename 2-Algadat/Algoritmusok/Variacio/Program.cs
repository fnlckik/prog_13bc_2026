namespace Variacio
{
    internal class Program
    {
        static List<string> elements = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j"];
        static List<string> elements2 = ["a", "b", "c"];
        static int K = 3;
        static StreamWriter sw;

        static void Main(string[] args)
        {
            // abcde => 3 hosszú sorozatok
            // aaa, aab, aac, aad, aae
            // aba, abb, ...
            LinkedList<string> list = [];
            sw = new("variacio.txt", true);
            Backtrack(list);
            sw.Close();
        }

        static void Backtrack(LinkedList<string> list)
        {
            bool finished = list.Count == K;
            if (finished)
            {
                //sw.WriteLine(string.Join("", list));
                Console.WriteLine(string.Join("", list));
                return;
            }
            foreach (string item in elements) // Minden lehetséges lépésre
            {
                if (IsValid2(list, item))
                {
                    Step(list, item);
                    Backtrack(list);
                    Back(list);
                }
            }
        }

        static void Step(LinkedList<string> list, string item)
        {
            list.AddLast(item);
        }

        static void Back(LinkedList<string> list)
        {
            list.RemoveLast();
        }

        // Ismétlés nélküli variáció
        static bool IsValid2(LinkedList<string> list, string item)
        {
            return !list.Contains(item);
        }

        // Ismétléses
        static bool IsValid(LinkedList<string> list, string item)
        {
            return true;
        }
    }
}
