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
                // Ha valamelyikük nem tudja kifizetni a tétet,
                // akkor dobjunk InvalidOperationException-t!
                result["Anna"] -= game.Bet;
                result["Béla"] -= game.Bet;
                // Döntetlen játék esetén mindketten visszakapják a tétet;
                // Egyéb esetben a győztes kapja a tét kétszeresét!
            }
            return result;
        }
    }
}
