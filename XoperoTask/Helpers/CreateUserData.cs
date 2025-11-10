using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoTask.Helpers
{
    public class CreateUserData
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public DateTime createdAt { get; set; }

        public CreateUserData(string name, string job)
        {
            Name = name;
            Job = job;
        }
    }
}
