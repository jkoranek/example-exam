using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Orientation_example_exam.IntegrationTests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient httpClient;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            httpClient = factory.CreateClient();
        }

        [Fact]
        public void AliasTestNotExist()
        {
            //arrange
            var responseMessage = httpClient.GetAsync("/a/Honza").Result;
            var expectedStatusCode = 404;

            //act
            var actualStatusCode = (int)responseMessage.StatusCode;

            //assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void AliasTestExist()
        {
            //arrange
            var responseMessage = httpClient.GetAsync("/a/Lukáš").Result;
            var expectedStatusCode = 200;
            //var expectedUrl = "https://www.novy-stavebni-zakon.cz";

            //act
            var actualStatusCode = (int)responseMessage.StatusCode;

            //assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        //[Fact]
        //public void GrootWithString()
        //{
        //    //arrange
        //    HttpStatusCode expectedStatusCode = HttpStatusCode.OK;
        //    string message = "ahoj";
        //    string result = "I am Groot!";
        //    string expectedReceived = message;
        //    string expectedTranslated = result;

        //    //act
        //    var response = _httpClient.GetAsync($"/groot?message={message}").Result;
        //    var responseBody = response.Content.ReadAsStringAsync().Result;
        //    Groot responseData = JsonConvert.DeserializeObject<Groot>(responseBody);
        //    string received = responseData.Received;
        //    string translated = responseData.Translated;

        //    //assert
        //    Assert.True(response.StatusCode == expectedStatusCode);
        //    Assert.True(response.IsSuccessStatusCode);
        //    Assert.Equal(expectedReceived, received);
        //    Assert.Equal(expectedTranslated, translated);
        //}
    }

    //public class Groot
    //{
    //    public string Received { get; set; }
    //    public string Translated { get; set; }
    //}
}
