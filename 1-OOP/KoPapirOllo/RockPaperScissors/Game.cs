namespace RockPaperScissors
{
    // Anna, Béla
    public class Game
    {
        private static string[] validChoices = ["kő", "papír", "olló"];

        public Game(string choice1, string choice2, int bet)
        {
            if (bet <= 0)
                throw new ArgumentOutOfRangeException("A tét pozitív kell legyen!");
            if (!IsValid(choice1) || !IsValid(choice2))
                throw new ArgumentException("Csak kő, papír, olló választható!");
            Choice1 = choice1;
            Choice2 = choice2;
            Bet = bet;
            Winner = DecideWinner(choice1, choice2);
        }

        public string Choice1 { get; }
        public string Choice2 { get; }
        public int Bet { get; }
        public string Winner { get; private set; }

        public static bool IsValid(string choice)
        {
            return validChoices.Contains(choice);
        }

        public static string DecideWinner(string a, string b)
        {
            if (a == b) return "Döntetlen";
            if (a == "kő" && b == "papír") return "Béla";
            if (a == "papír" && b == "olló") return "Béla";
            if (a == "olló" && b == "kő") return "Béla";
            return "Anna";
        }

        public bool IsHighBet()
        {
            return Bet >= 200;
        }
    }
}
