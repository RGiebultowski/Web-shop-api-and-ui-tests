using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoTask.Helpers
{
    public class WebDeserialization
    {
        public string LoginURL { get; set; }
        public string ValidUsername { get; set; }
        public string ValidPassword { get; set; }
        public string InvalidPassword { get; set; }
        public string InvalidUsername { get; set; }
        public WebDeserialization()
        {
            var jsonFlie = File.ReadAllText(Path.Combine("Configs", "webconfig.json"));
            try
            {
                var config = JsonConvert.DeserializeObject<dynamic>(jsonFlie);
                LoginURL = config!.LoginURL;
                ValidUsername = config!.ValidUsername;
                ValidPassword = config!.ValidPassword;
                InvalidPassword = config!.InvalidPassword;
                InvalidUsername = config!.InvalidUsername;
            }
            catch (JsonException jsonEx)
            {
                throw new Exception("Error parsing configuration file", jsonEx);
            }
        }
    }
}
