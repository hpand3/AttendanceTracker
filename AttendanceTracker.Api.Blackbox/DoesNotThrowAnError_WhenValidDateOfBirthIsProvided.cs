using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AttendanceTracker.Api.Blackbox.Fixture;
using AttendanceTracker.Api.Contract.Person.Register;
using AttendanceTracker.Common.Json;
using Newtonsoft.Json;
using NodaTime;
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
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.AddCustomSerialisationSettings();

            var personDetails = JsonConvert.SerializeObject(new RegisterPersonCommand
            {
                FirstName = "Rick",
                LastName = "Sanchez",
                DateOfBirth = new LocalDate(1949, 1, 1)
            }, jsonSerializerSettings);

            var content = new StringContent(personDetails, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync("/api/person/register", content);
            httpResponse.EnsureSuccessStatusCode();

            var responseJson = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject(responseJson, jsonSerializerSettings);

            response.ShouldNotBeNull();
        }
    }
}