using System;
using System.Net.Http;

namespace AttendanceTracker.Api.Blackbox.Fixture
{
    public class HttpClientFixture : IDisposable
    {
        private readonly HttpClient _httpClient;

        public HttpClient HttpClient => _httpClient;

        public HttpClientFixture()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000");
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}