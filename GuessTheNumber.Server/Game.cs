namespace GuessTheNumber.Server
{
    public class Game(int id, NumberRange range, int numberToGuess)
    {
        public enum DifficultyLevel
        {
            Easy,
            Medium,
            Hard,
        }

        public enum GuessResult
        {
            TooLow,
            Correct,
            TooHigh
        }

        private static readonly Dictionary<DifficultyLevel, NumberRange> _numberRanges = new()
        {
            { DifficultyLevel.Easy, new NumberRange(1, 20) },
            { DifficultyLevel.Medium, new NumberRange(1, 50) },
            { DifficultyLevel.Hard, new NumberRange(1, 100) },
        };

        public static Game Start(int id, DifficultyLevel difficultyLevel, Random? random = null)
        {
            random = random ?? new Random();
            var numberRange = _numberRanges[difficultyLevel];
            return new Game(id, numberRange, random.Next(numberRange.Min, numberRange.Max));
        }

        private readonly int numberToGuess = numberToGuess;

        public int Id { get; } = id;
        public NumberRange Range { get; } = range;

        public GuessResult Guess(int number)
        {
            if (number < numberToGuess)
            {
                return GuessResult.TooLow;
            }
            else if (number == numberToGuess)
            {
                return GuessResult.Correct;
            }
            return GuessResult.TooHigh;
        }

        public override bool Equals(object? obj)
        {
            return obj is Game game
                && game.Id == Id
                && game.Range.Equals(Range)
                && game.numberToGuess == numberToGuess;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Range, numberToGuess);
        }
    }
}
