using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace EnglishLearningPlatform.IntegrationTests
{
    public class CourseApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public CourseApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllCourses_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/v1/courses");
            response.EnsureSuccessStatusCode();
        }
    }
}
