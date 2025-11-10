using Newtonsoft.Json;
using RestSharp;
using XoperoTask.Drivers;
using XoperoTask.Helpers;
using XoperoTask.TestData;

namespace XoperoTask.API_Tests
{
    public class GetUserDataFromAPIStepDefinitions
    {
        private readonly ApiDriver apiDriver = new ApiDriver();
        private RestClient client;
        private readonly string endpoint = "api/users/";

        [SetUp]
        public void Setup()
        {
            client = new RestClient(apiDriver.BaseUrl);
        }

        [Test, TestCaseSource(typeof(GetUserTestData), nameof(GetUserTestData.Users))]
        public async Task GetUserByIdShouldReturnCorrectEmailAndFirstName(int id, string expectedName, string expectedEmail)
        {
            var request = new RestRequest($"{endpoint}{id}", Method.Get);
            request.AddHeader("x-api-key", apiDriver.ApiKey);
            RestResponse response;

            try
            {
                response = await client.ExecuteAsync(request);

            }catch (Exception ex)
            {
                Assert.Fail($"API request failed: {ex.Message}");
                return;
            }

            Console.WriteLine(response!.Content);

            var dataObject = JsonConvert.DeserializeObject<UserResponse>(response!.Content);

            var userData = dataObject!.Data;

            Assert.That(userData.FirstName, Is.EqualTo(expectedName));
            Assert.That(userData.Email, Is.EqualTo(expectedEmail));

        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
