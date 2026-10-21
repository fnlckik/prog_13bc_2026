
namespace Staircase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Van egy 30 lépcsős mozgólépcsőnk.
            // Szimuláljuk a rajta lévő emberek számát!
            // Kezdetben üres a lépcső.
            // Egys szimulációs lépés: egy lépcsőfokot halad fentebb a lépcső (az első lépcsőről lelépnek, az utolsóra rálépnek)
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
        }
    }
}
