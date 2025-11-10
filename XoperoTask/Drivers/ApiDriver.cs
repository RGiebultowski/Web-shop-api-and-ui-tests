using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoTask.Drivers
{
    public class ApiDriver
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }

        public ApiDriver()
        {
            var jsonFlie = File.ReadAllText(Path.Combine("Configs", "apiconfig.json"));

            try
            {
                var config = JsonConvert.DeserializeObject<dynamic>(jsonFlie);
                BaseUrl = config!.BaseUrl;
                ApiKey = config!.ApiKey;
            }
            catch (JsonException jsonEx)
            {
                throw new Exception("Error parsing configuration file", jsonEx);
            }
        }
    }
}
