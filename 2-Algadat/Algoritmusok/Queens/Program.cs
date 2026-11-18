
namespace Queens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<char>> board = [];
            Init(board, 4);
            //Show(board);
            int count = 0;
            BacktrackRook(board, 0, 0, ref count);
        }

        // F2 - Backtrack (queen)

        // F1 - Backtrack (rook) ✔️

        // Most rakunk a j. oszlopba
        private static void BacktrackRook(List<List<char>> board, int i, int j, ref int count)
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
                    Step(board, k, j);
                    BacktrackRook(board, k, j + 1, ref count);
                    Back(board, k, j);
                }
            }
        }

        private static void Back(List<List<char>> board, int i, int j)
        {
            board[i][j] = '.';
        }

        private static void Step(List<List<char>> board, int i, int j)
        {
            board[i][j] = 'R'; // rook
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
