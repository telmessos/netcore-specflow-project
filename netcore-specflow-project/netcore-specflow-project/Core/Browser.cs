using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace netcore_specflow_project.Core
{
    class Browser
    {
        public static IWebDriver driver;
        private static readonly FeatureContext _featureContext;
        private static readonly ScenarioContext _scenarioContext;
        private static readonly IObjectContainer _objectContainer;

        public static IWebDriver InitBrowser(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (IsBrowserHeadless)
                    {
                        chromeOptions.AddArgument("headless");
                    }
                    chromeOptions.AddArguments("--ignore-certificate-errors");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments("--ignore-certificate-errors");
                    driver = new EdgeDriver(edgeOptions);
                    break;
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return driver;
        }

        public static bool IsBrowserHeadless => Configuration.IsBrowserHeadless;
    }
}