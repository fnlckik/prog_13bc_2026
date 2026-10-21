
namespace Staircase
{
    internal class Program
    {
        private static Random r = new();

        static void Main(string[] args)
        {
            // Van egy 30 lépcsős mozgólépcsőnk.
            // Szimuláljuk a rajta lévő emberek számát!
            // Kezdetben üres a lépcső.
            // Egy szimulációs lépés: egy lépcsőfokot halad fentebb a lépcső (az első lépcsőről lelépnek, az utolsóra rálépnek)
            // 30% valószínűséggel 1 ember lép fel
            // 10% valószínűséggel 2 ember
            // egyéb esetben üres a lépcsőfok
            Simulate(50);
        }

        // FIFO => Queue
        private static void Simulate(int n)
        {
            // Kirajzolja a lépcső aktuális állapotát.
            // Írjuk ki azt is, hogy összesen hányan vannak a lépcsőn!
            // [0, 0, 0, 0] => 0
            // [0, 0, 0, 1] => 1
            // [0, 0, 1, 2] => 3
            // [0, 1, 2, 0] => 3
            // [1, 2, 0, 1] => 4
            // [2, 0, 1, 0] => 3
            Queue<int> stairs = new();
            for (int i = 0; i < 30; i++) stairs.Enqueue(0);
            Console.WriteLine(string.Join(" ", stairs));
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                int k;
                double p = r.NextDouble();
                if (p < 0.3) k = 1;
                else if (p < 0.4) k = 2;
                else k = 0;
                count -= stairs.Dequeue();
                stairs.Enqueue(k);
                count += k;
                Console.WriteLine(string.Join(" ", stairs) + " => " + count);
            }
        }
    }
}
