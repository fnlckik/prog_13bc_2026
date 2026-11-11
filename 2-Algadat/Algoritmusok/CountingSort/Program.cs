namespace CountingSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Parkolóház: Hány óráig voltak ott az autók?
            // Előfeltétel: minden adat 1 és 24 közötti!
            List<int> x = [12, 5, 12, 3, 5, 5, 12, 8, 3, 5];
            var result = CountingSort(x);
            Console.WriteLine(string.Join(";", result));

            // n elemű listát rendezünk
            // 1-től k-ig lehetnek az értékek
        }

        // O(2n+k) = O(n+k)
        static List<int> CountingSort(List<int> x)
        {
            int[] countingArray = new int[25]; // számláló tömb technika O(k)
            Console.WriteLine(string.Join(';', countingArray));

            // Párhuzamos megszámolás tételek O(n)
            foreach (int e in x)
            {
                countingArray[e]++;
            }
            Console.WriteLine(string.Join(';', countingArray));

            List<int> result = [];
            for (int i = 0; i < countingArray.Length; i++)
            {
                int n = countingArray[i];
                for (int j = 0; j < n; j++)
                {
                    result.Add(i); // O(n)
                }
            }
            return result;
        }
    }
}
