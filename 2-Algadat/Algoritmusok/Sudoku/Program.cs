namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Latin négyzet

            // Egy megoldás
            List<List<int>> s1 = [ [0, 0, 0],
                                   [2, 3, 0],
                                   [3, 0, 0] ];

            List<List<int>> s2 = [ [ 0, 0, 3, 0, 0 ],
                                   [ 0, 0, 0, 5, 1 ],
                                   [ 0, 4, 0, 1, 2 ],
                                   [ 0, 0, 1, 2, 0 ],
                                   [ 0, 0, 0, 0, 0 ] ];

            // Sudoku (1) VS Latin négyzet (4)
            List<List<int>> s3 = [ [ 1, 2, 9, 3, 6, 7, 4, 5, 8 ],
                                   [ 5, 7, 4, 2, 8, 1, 6, 3, 9 ],
                                   [ 6, 0, 8, 5, 9, 4, 7, 2, 0 ],
                                   [ 8, 5, 1, 7, 3, 2, 9, 6, 4 ],
                                   [ 9, 6, 0, 4, 0, 8, 3, 1, 2 ],
                                   [ 2, 4, 3, 9, 1, 6, 8, 7, 5 ],
                                   [ 3, 9, 6, 8, 2, 5, 1, 4, 7 ],
                                   [ 4, 0, 0, 6, 0, 9, 2, 8, 0 ],
                                   [ 7, 8, 2, 1, 4, 3, 5, 9, 6 ] ];

            // Nincs megoldás
            List<List<int>> s4 = [ [ 2, 0, 1 ],
                                   [ 0, 1, 2 ],
                                   [ 3, 0, 0 ] ];

            List<List<int>> s5 = [ [ 0, 0, 0, 0, 4 ],
                                   [ 0, 0, 0, 0, 1 ],
                                   [ 0, 5, 4, 0, 0 ],
                                   [ 0, 0, 0, 5, 0 ],
                                   [ 0, 0, 0, 4, 3 ] ];

            Backtrack(s1, 0, 0);
        }

        static void Backtrack(List<List<int>> board, int i, int j)
        {
            bool finished = i == board.Count;
            if (finished)
            {
                Show(board);
                return;
            }
            for (int k = 1; k <= board.Count; k++) // Minden lehetséges számot kipróbálunk
            {
                if (IsValid(board, i, j, k))
                {
                    Step(board, i, j, k);
                    if (j < board.Count) Backtrack(board, i, j + 1); // jobbra
                    else Backtrack(board, i + 1, 0); // lefelé
                    Back(board, i, j);
                }
            }
        }

        static void Show(List<List<int>> board)
        {
            foreach (var row in board)
            {
                foreach (var item in row)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
