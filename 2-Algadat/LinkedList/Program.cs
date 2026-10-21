using Microsoft.VisualBasic.FileIO;

namespace LinkedList
{
    internal class Program
    {
        private static Random r = new();

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
            Console.Clear();

            List<string> lista = new();
            lista.AddLast("alfa");
            lista.AddLast("beta");
            lista.AddLast("delta");
            Node<string> b = lista.Find("beta")!;
            lista.AddAfter(b, "gamma");
            lista.Remove("beta"); // alfa, gamma, delta
            Console.WriteLine($"Elemek száma: {lista.Count}");
            Console.WriteLine(string.Join(",", lista));
            Console.WriteLine(lista[1]); // gamma

            //Node<string>? x = new(null, "alma", null);
            //Delete(x);
            //Console.WriteLine(x?.Value);
            //List<string> l = new();
            //l.AddLast("alma");
            //l.Remove(l.First);
            //Console.WriteLine(l.First);

            //Simulation();
            //Simulation_List();

            // Vigyázat! Tudunk törölni olyan elemet, ami nincs is a listában!
            List<string> x = new(["Anna"]);
            List<string> y = new(["Béla"]);
            x.Remove(y.First!);
            Console.WriteLine(x.Count);
        }

        private static void Delete(Node<string>? x)
        {
            x = null;
        }

        private static void Simulation_List()
        {
            List<string> names = new(["Anna", "Béla", "Cecil", "Dani",
                                      "Elemér", "Feri", "Géza", "Hedvig",
                                      "Ignác", "Jani", "Károly", "Lajos"]);
            Queue<string> waiting = [];
            for (int i = 0; i < 144; i++)
            {
                Console.Write($"{i + 1}. nap felelői: ");
                Node<string>? e = names.First;
                while (e != null)
                {
                    Node<string>? next = e.Next;
                    if (r.NextDouble() < 0.2)
                    {
                        Console.Write(e.Value + " ");
                        waiting.Enqueue(e.Value);
                        names.Remove(e);
                    }
                    e = next;
                }
                Console.WriteLine($"\nNem feleltek: {string.Join(",", names)}\n");
                if (names.Count == 0)
                {
                    names = new(waiting);
                    waiting.Clear();
                }
            }
        }

        // foreach esetén nem módosítható a kollekció tartalma
        private static void Simulation()
        {
            LinkedList<string> names = new(["Anna", "Béla", "Cecil", "Dani",
                                            "Elemér", "Feri", "Géza", "Hedvig",
                                            "Ignác", "Jani", "Károly", "Lajos"]);
            Queue<string> waiting = [];
            for (int i = 0; i < 144; i++)
            {
                Console.Write($"{i+1}. nap felelői: ");
                LinkedListNode<string>? e = names.First;
                while (e != null)
                {
                    LinkedListNode<string>? next = e.Next;
                    if (r.NextDouble() < 0.2)
                    {
                        Console.Write(e.Value + " ");
                        waiting.Enqueue(e.Value);
                        names.Remove(e);
                    }
                    e = next;
                }
                Console.WriteLine($"\nNem feleltek: {string.Join(",", names)}\n");
                if (names.Count == 0)
                {
                    names = new(waiting);
                    waiting.Clear();
                }
            }
        }
    }
}
