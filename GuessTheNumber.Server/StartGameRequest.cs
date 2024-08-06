using System.Text.Json.Serialization;

namespace GuessTheNumber.Server
{
    public class StartGameRequest
    {
        [JsonPropertyName("difficulty_level")]
        public string? DifficultyLevel { get; set; }

        public Game.DifficultyLevel ToDifficultyLevel()
        {
            return (Game.DifficultyLevel)Enum.Parse(typeof(Game.DifficultyLevel), DifficultyLevel!, false);
        }
    }
}
