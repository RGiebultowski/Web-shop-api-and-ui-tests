using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoperoTask.Drivers;

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

        [Test]
        public void Test1()
        {
            var request = new RestRequest($"{endpoint}", Method.Post);
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
