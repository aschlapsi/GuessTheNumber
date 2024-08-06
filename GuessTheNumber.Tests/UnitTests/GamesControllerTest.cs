using GuessTheNumber.Server;
using GuessTheNumber.Server.Controllers;

namespace GuessTheNumber.Tests.UnitTests
{
    public class GamesControllerTest
    {
        [Fact]
        public void StartGame()
        {
            var repository = new FakeDatabase();
            var random1 = new Random(42);
            var random2 = new Random(42);
            var controller = new GamesController(repository, random1);

            controller.StartGame(new StartGameRequest { DifficultyLevel = "Easy" });

            var expectedGame = new Game(1, new NumberRange(1, 20), random2.Next(1, 20));
            Assert.Contains(expectedGame, repository);
        }
    }
}
