
using System.Diagnostics;

namespace Shopping
{
    internal class Program
    {
        private static Random r = new();
        private static List<string> names = [];

        static void Main(string[] args)
        {
            // Fájl beolvasás
            Stopwatch sw = new();
            sw.Start();
            names = ReadFromFile("../../../names.txt");
            sw.Stop();
            Console.WriteLine($"Idő (fájl beolvasás): {sw.ElapsedTicks}");
            //Console.WriteLine(names.Count);
            //Console.WriteLine(names[names.Count-1]);

            // ------------------------------
            // Lista szimuláció
            sw.Restart();
            List<string> waitingList = Simulation_List(1_000_000, 1_000_000); // O(n)
            sw.Stop();
            Console.WriteLine($"Idő (lista szimuláció): {sw.ElapsedTicks}");
            Console.Write("\nA végén a sorban állnak:\n\t");
            //Console.WriteLine(string.Join("\n\t", waitingList));

            // Lista VS Sor
            Console.WriteLine();
            List<string> lista = [];
            lista.Add("alma"); // Végéhez
            lista.Add("banán");
            lista.Add("citrom");
            lista.Add("dió");
            Console.WriteLine($"Lista elemei: {String.Join("-", lista)}");
            Console.WriteLine("Lista 2. eleme: " + lista[2]); // Index
            lista.RemoveAt(2); // Elem törlése (bárhonnan)
            Console.WriteLine("Lista elemszáma: " + lista.Count); // Hossz
            Console.WriteLine("Lista elemei:");
            foreach (var item in lista)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine();
            Queue<string> sor = [];
            sor.Enqueue("alma"); // Végéhez (sorba)
            sor.Enqueue("banán");
            sor.Enqueue("citrom");
            sor.Enqueue("dió");
            Console.WriteLine($"Sor elemei: {String.Join("-", sor)}");
            Console.WriteLine("Sor első eleme: " + sor.Peek()); // Első
            Console.WriteLine("Sorból kivéve az első: " + sor.Dequeue()); // Elejéről (sorból)
            Console.WriteLine("Sor elemszáma: " + sor.Count); // Elemszám
            Console.WriteLine("Sor elemei:");
            foreach (var item in sor)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // --------------------------
            // Sor szimuláció
            sw.Restart();
            Queue<string> waitingQueue = Simulation_Queue(1_000_000, 1_000_000);
            sw.Stop();
            Console.WriteLine($"Idő (sor szimuláció): {sw.ElapsedTicks}");
            Console.Write("\nA végén a sorban állnak:\n\t");
            //Console.WriteLine(string.Join("\n\t", waitingQueue));

            // Tóth Loréna -> hiányzó 0-ás gomb
            //Console.Clear();
            Q<string> queue = new();
            Console.WriteLine($"Sor hossza: {queue.Count}");
            queue.Add("alma");
            queue.Add("barack");
            queue.Add("citrom");
            //Console.WriteLine($"Sor hossza: {queue.Count}");
            //Console.WriteLine($"Első elem: {queue.First()}");
            //Console.WriteLine($"Elemek: {String.Join(";", queue)}");
            //Console.WriteLine($"Első elem kivétele: {queue.Pop()}");
            //Console.WriteLine($"Első elem kivétele: {queue.Pop()}");
            //Console.WriteLine($"Első elem kivétele: {queue.Pop()}");
            //Console.WriteLine($"Sor hossza: {queue.Count}");

            // Kitekintés
            //IEnumerable<int> x = Szamok();
            //foreach (int number in x)
            //{
            //    Console.Write(number + " ");
            //}

            // Szimuláció - saját sorral
            sw.Restart();
            Q<string> waitingQ = Simulation_Q(1_000_000, 1_000_000);
            sw.Stop();
            Console.WriteLine($"Idő (saját sor szimuláció): {sw.ElapsedTicks}");
            Console.Write("\nA végén a sorban állnak:\n\t");
        }

        // yield: hozam, termés
        // Megjegyzi az állapotot, és később, innen folytatja a végrehajtást.
        // Valójában a yield egy IEnumerator-t ad vissza (amiből a C# készít egy IEnumerable-t)
        private static IEnumerable<int> Szamok()
        {
            yield return 3;
            yield return 1;
            yield return 4;
        }

        private static List<string> Simulation_List(int n, int length)
        {
            List<string> waitingList = [];
            for (int i = 0; i < n; i++) // n szimulációs lépés
            {
                if (r.NextDouble() < 0.6 && waitingList.Count < length) // érkezik
                {
                    string name = names[r.Next(0, names.Count)]; // Ki érkezik?
                    waitingList.Add(name);
                    //Console.WriteLine($"Érkezett: {name}");
                }
                if (r.NextDouble() < 0.2 && waitingList.Count > 0) // Ki távozik?
                {
                    //Console.WriteLine($"Távozott: {waitingList[0]}");
                    waitingList.RemoveAt(0);
                }
            }
            return waitingList;
        }

        private static Queue<string> Simulation_Queue(int n, int length)
        {
            Queue<string> waitingList = [];
            for (int i = 0; i < n; i++) // n szimulációs lépés
            {
                if (r.NextDouble() < 0.6 && waitingList.Count < length) // érkezik
                {
                    string name = names[r.Next(0, names.Count)]; // Ki érkezik?
                    waitingList.Enqueue(name);
                    //Console.WriteLine($"Érkezett: {name}");
                }
                if (r.NextDouble() < 0.2 && waitingList.Count > 0) // Ki távozik?
                {
                    //Console.WriteLine($"Távozott: {waitingList.Peek()}");
                    waitingList.Dequeue();
                }
            }
            return waitingList;
        }

        private static Q<string> Simulation_Q(int n, int length)
        {
            Q<string> waitingList = [];
            for (int i = 0; i < n; i++) // n szimulációs lépés
            {
                if (r.NextDouble() < 0.6 && waitingList.Count < length) // érkezik
                {
                    string name = names[r.Next(0, names.Count)]; // Ki érkezik?
                    waitingList.Add(name);
                }
                if (r.NextDouble() < 0.2 && waitingList.Count > 0) // Ki távozik?
                {
                    waitingList.Pop();
                }
            }
            return waitingList;
        }

        private static List<string> ReadFromFile(string path)
        {
            List<string> result = [];
            using StreamReader sr = new(path);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine()!;
                result.Add(line);
            }
            return result;
        }
    }
}
