using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text;
using System.Text.Json;

namespace GuessTheNumber.Tests
{
    public class GamesControllerTest
    {
        [Fact]
        public async Task CreateGame()
        {
            using var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            var content = new StringContent(JsonSerializer.Serialize(new
            {
                difficulty_level = "Easy"
            }), Encoding.UTF8, "application/json");
            var response = await client
                .PostAsync("/api/v1/games", content);

            Assert.True(
                response.IsSuccessStatusCode,
                $"Actual status code: {response.StatusCode}.");
        }
    }
}