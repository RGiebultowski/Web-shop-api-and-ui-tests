using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoperoTask.Helpers;

namespace XoperoTask.TestData
{
    public static class PostUserTestData
    {
        public static IEnumerable<TestCaseData> UserToCreate =>
            new List<TestCaseData>
            {
                new TestCaseData(new CreateUserData(name: "James", job:"Professional Driver")),
            };
    }
}
