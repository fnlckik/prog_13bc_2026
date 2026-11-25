
namespace Queens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<char>> board = [];
            Init(board, 8);
            //Show(board);
            int count = 0;
            //BacktrackRook(board, 0, ref count);
            //Backtrack(board, 0);

            Stack<int> queens = [];
            //BacktrackSearch(board, 0, queens);
            //Console.WriteLine(string.Join(";", queens.Reverse()));

            List<Stack<int>> solutions = [];
            BacktrackAll(board, 0, queens, solutions);
            foreach (var solution in solutions)
            {
                Console.WriteLine(string.Join(";", solution.Reverse()));
            }
        }

        // F4 - Minden megoldást tároljunk el
        private static void BacktrackAll(List<List<char>> board, int j, Stack<int> queens, List<Stack<int>> solutions)
        {
            bool finished = j == board.Count;
            if (finished)
            {
                solutions.Add(new(queens));
                //Show(board);
                return;
            }
            for (int k = 0; k < board.Count; k++)
            {
                if (IsValidQueen(board, k, j))
                {
                    Step(board, k, j, 'Q', queens);
                    BacktrackAll(board, j + 1, queens, solutions);
                    Back(board, k, j, queens);
                }
            }
        }

        // F3 - Egy megoldást adjunk csak meg -> One solution
        private static bool BacktrackSearch(List<List<char>> board, int j, Stack<int> queens)
        {
            bool finished = j == board.Count;
            if (finished)
            {
                Show(board);
                return true;
            }
            for (int k = 0; k < board.Count; k++)
            {
                if (IsValidQueen(board, k, j))
                {
                    Step(board, k, j, 'Q', queens);
                    if (BacktrackSearch(board, j + 1, queens)) return true;
                    Back(board, k, j, queens);
                }
            }
            return false;
        }

        // F2 - Backtrack (queen) -> All solution
        private static void Backtrack(List<List<char>> board, int j)
        {
            bool finished = j == board.Count;
            if (finished)
            {
                Show(board);
                return;
            }
            for (int k = 0; k < board.Count; k++)
            {
                if (IsValidQueen(board, k, j))
                {
                    Step(board, k, j, 'Q');
                    Backtrack(board, j + 1);
                    Back(board, k, j);
                }
            }
        }

        static bool IsValidQueen(List<List<char>> board, int i, int j)
        {
            if (board[i].Any(e => e == 'Q')) return false; // Ebben a sorban már van királynő
            for (int r = 0; r < board.Count; r++)
            {
                for (int c = 0; c < board.Count; c++)
                {
                    // Gond: átlóban vagyunk és már tettünk le ide királynőt
                    if (board[r][c] == 'Q' && Math.Abs(i-r) == Math.Abs(j-c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // F1 - Backtrack (rook) ✔️

        // Most rakunk a j. oszlopba
        private static void BacktrackRook(List<List<char>> board, int j, ref int count)
        {
            bool finished = j == board.Count; // utolsó oszlopba is raktunk
            if (finished)
            {
                count++;
                Console.WriteLine(count + ". megoldás:");
                Show(board);
                return;
            }
            for (int k = 0; k < board.Count; k++) // Minden lehetséges k. sorra
            {
                if (IsValid(board, k, j)) // k. sor, j. oszlop
                {
                    Step(board, k, j, 'R');
                    BacktrackRook(board, j + 1, ref count);
                    Back(board, k, j);
                }
            }
        }

        private static void Back(List<List<char>> board, int i, int j, Stack<int>? queens = null)
        {
            board[i][j] = '.';
            queens?.Pop();
        }

        private static void Step(List<List<char>> board, int i, int j, char c, Stack<int>? queens = null)
        {
            board[i][j] = c; // rook vs queen
            queens?.Push(i);
        }

        // Szabad lépés: i. sorban nincs még rook
        private static bool IsValid(List<List<char>> board, int i, int j)
        {
            return !board[i].Any(e => e == 'R');
        }

        private static void Init(List<List<char>> board, int n)
        {
            for (int i = 0; i < n; i++)
            {
                List<char> row = [];
                for (int j = 0; j < n; j++)
                {
                    row.Add('.');
                }
                board.Add(row);
            }
        }

        private static void Show(List<List<char>> board)
        {
            foreach (var row in board)
            {
                foreach (var e in row)
                {
                    Console.Write(e + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
