namespace Knight
{
    public class Vector
    {
        int di, dj;

        public Vector(int di, int dj)
        {
            this.di = di;
            this.dj = dj;
        }
    }

    internal class Program
    {
        const int N = 8; // 8x8-as tábla
        const int K = 4; // max ennyi lépés tehető meg
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

        static void Knight(int i, int j, int k)
        {
            if (k > K) return;
            board[i][j] = k + 1;
        }

        static void Show()
        {
            foreach (var row in board)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
