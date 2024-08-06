
namespace GuessTheNumber.Server
{
    public class InMemoryGameRepository : IGameRepository
    {
        private readonly List<Game> _games = [];
        private int _nextId = 1;

        public Task Create(Game game)
        {
            _games.Add(game);
            return Task.CompletedTask;
        }

        public Task<Game> Get(int id)
        {
            return Task.FromResult(
                _games.Where(game => game.Id == id).Single()
            );
        }

        public int NextId()
        {
            return _nextId++;
        }
    }
}
