using GuessTheNumber.Server;
using System.Collections.ObjectModel;

namespace GuessTheNumber.Tests.UnitTests
{
    public class FakeDatabase : Collection<Game>, IGameRepository
    {
        private int _nextId = 1;

        public Task Create(Game game)
        {
            Add(game);
            return Task.CompletedTask;
        }

        public Task<Game> Get(int id)
        {
            return Task.FromResult(this.Where(game => game.Id == id).Single());
        }

        public int NextId()
        {
            return _nextId++;
        }
    }
}
