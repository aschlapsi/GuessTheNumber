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

        [Theory]
        [InlineData(11, "correct")]
        [InlineData(10, "too low")]
        [InlineData(12, "too high")]
        public async Task GuessNumber_Correct(int number, string expectedMessage)
        {
            var repository = new FakeDatabase();
            var game = new Game(1, new NumberRange(1, 20), 11);
            repository.Add(game);
            var controller = new GamesController(repository);

            var result = await controller.GuessNumber(game.Id, new GuessNumberRequest { Number = number });

            Assert.Equal(expectedMessage, result.Message);
        }
    }
}
