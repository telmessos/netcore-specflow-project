using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace netcore_specflow_project.Core;
[Binding]
    static class Configuration
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        public static string BrowserName => InitConfiguration().GetSection("Configuration").GetSection("browser").Value;
        public static string BaseUrl => InitConfiguration().GetSection("Configuration").GetSection("baseUrl").Value;
        public static bool IsBrowserHeadless => bool.Parse(InitConfiguration().GetSection("Configuration").GetSection("headless").Value);
    }

