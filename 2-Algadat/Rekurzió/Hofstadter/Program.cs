namespace Hofstadter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(R(18)); // 69
            Console.WriteLine(S(18)); // 14
        }

        static int R(int n)
        {
            if (n == 1) return 1;
            return R(n - 1) + S(n - 1);
        }

        // O(szutyok) ~ O(a^n) exponenciális
        // Lehetne hatékonyabban? (Igen, lásd: dinamikus programozás.)
        static int S(int n)
        {
            if (n == 1) return 2;
            HashSet<int> set = [];
            for (int i = 1; i < n; i++)
            {
                set.Add(R(i));
                set.Add(S(i));
            }
            set.Add(R(n));
            int j = 1;
            while (true)
            {
                if (!set.Contains(j))
                {
                    return j;
                }
                j++;
            }
        }
    }
}
