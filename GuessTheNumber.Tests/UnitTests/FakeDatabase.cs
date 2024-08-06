using GuessTheNumber.Server;
using System.Collections.ObjectModel;

namespace GuessTheNumber.Tests.UnitTests
{
    public class FakeDatabase : Collection<Game>, IGameRepository
    {
        public Task Create(Game game)
        {
            Add(game);
            return Task.CompletedTask;
        }
    }
}
