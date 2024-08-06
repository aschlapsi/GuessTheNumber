using GuessTheNumber.Server;

namespace GuessTheNumber.Tests.UnitTests
{
    public class GameTest
    {
        [Theory]
        [InlineData(Game.DifficultyLevel.Easy, 20)]
        [InlineData(Game.DifficultyLevel.Medium, 50)]
        [InlineData(Game.DifficultyLevel.Hard, 100)]
        public void CreateGame(Game.DifficultyLevel difficultyLevel, int maxNumber)
        {
            var game = Game.Start(1, difficultyLevel);

            Assert.Equal(1, game.Id);
            Assert.Equal(new NumberRange(1, maxNumber), game.Range);
        }

        [Fact]
        public void Guess_NumberIsCorrect()
        {
            const int seed = 42;
            var random = new Random(seed);
            var game = Game.Start(42, Game.DifficultyLevel.Easy, new Random(seed));

            var result = game.Guess(random.Next(game.Range.Min, game.Range.Max));

            Assert.Equal(Game.GuessResult.Correct, result);
        }

        [Fact]
        public void Guess_NumberIsTooLow()
        {
            const int seed = 42;
            var random = new Random(seed);
            var game = Game.Start(42, Game.DifficultyLevel.Easy, new Random(seed));

            var result = game.Guess(random.Next(game.Range.Min, game.Range.Max) - 1);

            Assert.Equal(Game.GuessResult.TooLow, result);
        }

        [Fact]
        public void Guess_NumberIsTooHigh()
        {
            const int seed = 42;
            var random = new Random(seed);
            var game = Game.Start(42, Game.DifficultyLevel.Easy, new Random(seed));

            var result = game.Guess(random.Next(game.Range.Min, game.Range.Max) + 1);

            Assert.Equal(Game.GuessResult.TooHigh, result);
        }
    }
}
