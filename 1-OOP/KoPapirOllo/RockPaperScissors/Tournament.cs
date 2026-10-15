namespace RockPaperScissors
{
    public class Tournament
    {
        public DateTime Date { get; }
        public int Money1 { get; private set; }
        public int Money2 { get; private set; }
        public List<Game> Games { get; private set; }

        public Tournament(DateTime date)
        {
            Date = date;
            Money1 = 1000;
            Money2 = 1000;
            Games = [];
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }

        public int CountWins(string player)
        {
            return Games.Count(g => g.Winner == player);
        }

        public Game? GetFirstDraw()
        {
            if (!Games.Any(g => g.Winner == "Döntetlen")) return null;
            return Games.First(g => g.Winner == "Döntetlen");
        }

        public List<Game> GetDrawGames()
        {
            return Games.Where(g => g.Winner == "Döntetlen").ToList();
        }

        // F10
        public Dictionary<string, int> GetFinalMoney()
        {
            Dictionary<string, int> result = new();
            result.Add("Anna", Money1);
            result.Add("Béla", Money2);
            foreach (Game game in Games)
            {
                // result["Anna"] < game.Bet || result["Béla"] < game.Bet
                if (result.Any(kv => kv.Value < game.Bet))
                {
                    throw new InvalidOperationException("Nem lehetséges bajnokság.");
                }
                result["Anna"] -= game.Bet;
                result["Béla"] -= game.Bet;
                string winner = game.Winner;
                if (winner == "Döntetlen")
                {
                    result["Anna"] += game.Bet;
                    result["Béla"] += game.Bet;
                }
                else
                {
                    result[winner] += 2 * game.Bet;
                }
            }
            return result;
        }
    }
}
