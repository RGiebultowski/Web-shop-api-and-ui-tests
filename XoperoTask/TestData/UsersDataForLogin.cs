using XoperoTask.Helpers;

namespace XoperoTask.TestData
{
    public static class UsersDataForLogin
    {
        private static WebDeserialization data = new WebDeserialization();
        private static string errorMessage = "Epic sadface: Username and password do not match any user in this service";
        private static string errorUsernameMessage = "Epic sadface: Password is required";
        private static string errorPasswordMessage = "Epic sadface: Username is required";
        public static IEnumerable<TestCaseData> testCaseUsers =>
            new List<TestCaseData> 
            {
                new TestCaseData(data.ValidUsername, data.InvalidPassword, errorMessage),
                new TestCaseData(data.InvalidUsername, data.ValidPassword, errorMessage),
                new TestCaseData(data.InvalidUsername, data.InvalidPassword, errorMessage),
                new TestCaseData(data.ValidUsername, "", errorUsernameMessage),
                new TestCaseData("", data.ValidPassword, errorPasswordMessage),
            };
    }
}
