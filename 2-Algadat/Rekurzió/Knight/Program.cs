using System.Drawing;

namespace Knight
{
    public class Vector
    {
        public int di, dj;

        public Vector(int di, int dj)
        {
            this.di = di;
            this.dj = dj;
        }
    }

    internal class Program
    {
        const int N = 20; // 8x8-as tábla
        const int K = 13; // max ennyi lépés tehető meg
        static List<List<int>> board = [];
        static List<Vector> directions = [ new(-2, -1), new(-2, +1), new(-1, -2), new(-1, +2),
                                           new(+1, -2), new(+1, +2), new(+2, -1), new(+2, +1)];

        static void Main(string[] args)
        {
            for (int i = 0; i < N; i++)
            {
                List<int> row = [];
                for (int j = 0; j < N; j++)
                {
                    row.Add(0);
                }
                board.Add(row);
            }
            Knight(0, 0, 0);
            Show();
        }

        // board[i][j] == 0 -> nem jártam még a cellában
        // k < board[i][j] -> találtam rövidebb utat
        static bool IsValid(int i, int j, int k)
        {
            if (i < 0 || i >= N || j < 0 || j >= N) return false; // valid index
            //return true;
            return board[i][j] == 0 || k < board[i][j]; // legrövidebb út
        }

        // (i, j): itt járunk
        // k: ennyi lépést tettünk eddig
        static void Knight(int i, int j, int k)
        {
            bool finished = k >= K;
            if (finished) return; // Végeztünk-e?
            foreach (Vector v in directions) // Minden lehetséges lépésre...
            {
                int nextI = i + v.di;
                int nextJ = j + v.dj;
                if (IsValid(nextI, nextJ, k + 1)) // Ha szabályos a lépés
                {
                    board[nextI][nextJ] = k + 1; // Lépünk!
                    Knight(nextI, nextJ, k + 1); // Megyünk tovább (rekurzió)
                }
            }
        }

        static void Show()
        {
            foreach (var row in board)
            {
                foreach (var cell in row)
                {
                    if (cell != 0)
                    {
                        // kicsit savanyú, kicsit sárga...
                        // ConsoleColor.DarkYellow
                        Console.ForegroundColor = (ConsoleColor)cell;
                    }
                    string s = cell.ToString().PadLeft(4);
                    Console.Write(s);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
    }
}
