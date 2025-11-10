using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoTask.Helpers
{
    public class UserData
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }
        [JsonProperty("last_name")]
        public string? LastName { get; set; }
        public string? Avatar { get; set; }
    }

    public class UserResponse
    {
        public UserData? Data { get; set; }
    }
}
