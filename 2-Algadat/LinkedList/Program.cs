namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LinkedList - Láncolt lista
            // Sokszor törlünk, beszúrunk => láncolt lista
            // Sokszor indexelünk => sima lista (tömb)
            LinkedList<string> names = new();
            names.AddLast("Anna"); // O(1)
            names.AddLast("Ferenc");
            names.AddLast("Michelangelo");
            Console.WriteLine($"Elemek száma: {names.Count}"); // O(1)
            Console.WriteLine($"Elemek: {string.Join(";", names)}");
            LinkedListNode<string> node = names.Find("Ferenc")!; // O(n)
            node = node.Next!; // Michelangelo
            names.AddAfter(node, "Pista"); // O(1)
            names.AddBefore(node, "János"); // O(1)
            Console.WriteLine($"Elemek: {string.Join(";", names)}");
            Console.WriteLine($"Első elem: {names.First!.Value}");
            Console.WriteLine($"Utolsó elem: {names.Last!.Value}");
            names.Remove(node); // O(1)
            names.Remove("János"); // O(n) -> Find(value) + Remove(Node)
            Console.WriteLine($"Elemek: {string.Join(";", names)}");
        }
    }
}
