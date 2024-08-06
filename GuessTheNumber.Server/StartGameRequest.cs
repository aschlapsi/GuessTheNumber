using System.Text.Json.Serialization;

namespace GuessTheNumber.Server
{
    public class StartGameRequest
    {
        [JsonPropertyName("difficulty_level")]
        public string? DifficultyLevel { get; set; }
    }
}
