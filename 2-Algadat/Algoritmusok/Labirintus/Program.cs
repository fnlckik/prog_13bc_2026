namespace Labirintus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<char>> m1 = [ ['.', '.', '#', '.'],
                                    ['.', '.', '.', '#'],
                                    ['#', '.', '#', '.'],
                                    ['.', '.', '.', 'T'] ];

            List<List<char>> m2 = [ ['.', '.', '.', '.', '#'],
                                    ['#', '#', '#', '.', '#'],
                                    ['.', '.', '.', '.', '#'],
                                    ['.', '.', '.', '#', '#'],
                                    ['#', '#', '.', '.', 'T'] ];

            int startI = 0;
            int startJ = 0;
            m1[startI][startJ] = 'X';
            //Show(m1);

            Backtrack(m1, 0, 0); // startI, startJ
        }

        static void Backtrack(List<List<char>> board, int i, int j)
        {
            Show(board);
            bool finished = board[i][j] == 'T';
            if (finished)
            {
                Show(board);
                return;
            }
            if (IsValid(board, i, j+1)) // jobbra lépés
            {
                Step(board, i, j + 1);
                Backtrack(board, i, j + 1);
                Back(board, i, j + 1);
            }
            if (IsValid(board, i + 1, j)) // lefelé lépés
            {
                Step(board, i + 1, j);
                Backtrack(board, i + 1, j);
                Back(board, i + 1, j);
            }
        }

        static void Back(List<List<char>> board, int i, int j)
        {
            if (board[i][j] == 'T') return; // Ne írjuk felül a célt!
            board[i][j] = '.';
        }

        static void Step(List<List<char>> board, int i, int j)
        {
            if (board[i][j] == 'T') return; // Ne írjuk felül a célt!
            board[i][j] = 'X';
        }

        static bool IsValid(List<List<char>> board, int i, int j)
        {
            if (i < 0 || i >= board.Count || j < 0 || j >= board[i].Count) return false;
            if (board[i][j] == '#') return false;
            return true;
        }

        static void Show(List<List<char>> board)
        {
            foreach (var row in board)
            {
                foreach (var e in row)
                {
                    if (e == 'X') Console.ForegroundColor = ConsoleColor.Green;
                    else if (e == '#') Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(e + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
