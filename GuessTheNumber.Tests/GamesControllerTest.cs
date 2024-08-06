using GuessTheNumber.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace GuessTheNumber.Tests
{
    public class GamesControllerTest
    {
        [Fact]
        public async Task CreateGame()
        {
            var response = await PostNewGame(new
            {
                difficulty_level = "Easy"
            });

            Assert.True(
                response.IsSuccessStatusCode,
                $"Actual status code: {response.StatusCode}.");

            var game = await response.Content.ReadFromJsonAsync<GameDTO>();
            Assert.NotNull(game);
            Assert.True(game.Id > 0, "Game.Id is not set");
            Assert.Equal(1, game.RangeMin);
            Assert.Equal(20, game.RangeMax);
        }

        private async Task<HttpResponseMessage> PostNewGame(object newGame)
        {
            using var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            using var content = new StringContent(JsonSerializer.Serialize(newGame), Encoding.UTF8, "application/json");
            return await client.PostAsync("/api/v1/games", content);
        }
    }
}