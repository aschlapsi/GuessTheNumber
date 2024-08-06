namespace GuessTheNumber.Server
{
    public class GameDTO
    {
        public int Id { get; set; }
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }
    }

    public static class GameExtension
    {
        public static GameDTO ToDTO(this Game game)
        {
            return new GameDTO
            {
                Id = game.Id,
                RangeMin = game.Range.Min,
                RangeMax = game.Range.Max,
            };
        }
    }
}
