using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoTask.TestData
{
    public static class GetUserTestData
    {
        public static IEnumerable<TestCaseData> Users =>
            new List<TestCaseData>
            {
                new TestCaseData(2, "Janet", "janet.weaver@reqres.in"),
            };
    }
}
