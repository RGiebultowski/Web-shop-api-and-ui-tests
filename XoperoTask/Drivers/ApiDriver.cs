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
        public string ApiBaseUrl { get; set; }
        public string ApiKey { get; set; }

        public ApiDriver()
        {
            var jsonFlie = File.ReadAllText(Path.Combine("Configs", "apiconfig.json"));
            
            ConfiguartionFile config;

            try
            {
                config = JsonConvert.DeserializeObject<ConfiguartionFile>(jsonFlie);
            }
            catch (NullReferenceException nullEx)
            {
                throw new Exception("Configuration file is null", nullEx);
            }
            catch (JsonException jsonEx)
            {
                throw new Exception("Error parsing configuration file", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading configuration file", ex);
            }

            ApiBaseUrl = config!.ApiBaseUrl;
            ApiKey = config!.ApiKey;
        }

        private class ConfiguartionFile()
        {
            public required string ApiBaseUrl { get; set; }
            public required string ApiKey { get; set; }
        }
    }
}
