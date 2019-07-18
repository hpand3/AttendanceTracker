using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AttendanceTracker.Api.Blackbox.Fixture;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace AttendanceTracker.Api.Blackbox
{
    public class DoesNotThrowAnError_WhenValidDateOfBirthIsProvided
    {
        private readonly HttpClient _httpClient;

        public DoesNotThrowAnError_WhenValidDateOfBirthIsProvided()
        {
            _httpClient = new HttpClientFixture().HttpClient;
        }

        [Test]
        public async Task Execute()
        {
            var personDetails = JsonConvert.SerializeObject(new
            {
                FirstName = "Rick",
                LastName = "Sanchez",
                DateOfBirth = "01-01-1949"
            });

            var content = new StringContent(personDetails, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync("/api/person/register", content);
            httpResponse.EnsureSuccessStatusCode();

            var responseJson = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject(responseJson);

            response.ShouldNotBeNull();
        }
    }
}