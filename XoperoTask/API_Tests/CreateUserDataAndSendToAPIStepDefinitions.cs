using Newtonsoft.Json;
using RestSharp;
using XoperoTask.Drivers;
using XoperoTask.Helpers;
using XoperoTask.TestData;

namespace XoperoTask.API_Tests
{
    public class CreateUserDataAndSendToAPIStepDefinitions
    {
        private readonly ApiDriver apiDriver = new ApiDriver();
        private RestClient client;
        private readonly string endpoint = "api/users";

        [SetUp]
        public void Setup()
        {
            client = new RestClient(apiDriver.BaseUrl);
        }

        [Test, TestCaseSource(typeof(PostUserTestData), nameof(PostUserTestData.UserToCreate))]
        public async Task PostUserAndCheckApiStatusWithBodyRequest(CreateUserData userData)
        {
            var request = new RestRequest($"{endpoint}", Method.Post);
            request.AddHeader("x-api-key", apiDriver.ApiKey);
            request.AddJsonBody(userData);
            RestResponse response;
            try
            {
                response = await client.ExecuteAsync(request);

            }
            catch (Exception ex)
            {
                Assert.Fail($"API request failed: {ex.Message}");
                return;
            }

            Console.WriteLine(response!.Content);

            var dataObject = JsonConvert.DeserializeObject<CreateUserData>(response!.Content);

            Assert.Multiple(() => {
                Assert.That((int)response.StatusCode, Is.EqualTo(201));
                Assert.That(dataObject.Name, Is.EqualTo(userData.Name));
                Assert.That(dataObject.Job, Is.EqualTo(userData.Job));
                Assert.That(dataObject.Id, Is.Not.Empty);
                Assert.That(dataObject.createdAt, Is.Not.EqualTo(default(DateTime)));
            });
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
