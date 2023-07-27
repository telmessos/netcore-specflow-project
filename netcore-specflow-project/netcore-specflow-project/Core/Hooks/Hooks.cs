using BoDi;
using OpenQA.Selenium;
using System.Drawing;
using Allure.Commons;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using TechTalk.SpecFlow;

namespace netcore_specflow_project.Core.Hooks;
[Binding]
    class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private readonly ScenarioContext scenarioContext;
        private IWebDriver webDriver;
        private static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName
                                           + Path.DirectorySeparatorChar + "Result"
                                           + Path.DirectorySeparatorChar + "Result_" +
                                           DateTime.Now.ToString("ddMMyyyy_HHmmss");

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            string test = reportPath;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.File(reportPath + @"/Logs",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}",
                    rollingInterval: RollingInterval.Day).CreateLogger();
        }

        [BeforeStep]
        public void BeforeStep()
        {
        }
        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError != null)
            {
                Log.Error("Test Step Failed | {0}", context.TestError.Message);
                byte[] screenshot = ((ITakesScreenshot)webDriver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment("Failed Screenshot", "image/png", screenshot);
            }
        }

        [BeforeScenario]
        public void InitializeWebDriver(ScenarioContext context)
        {
            if (!scenarioContext.ScenarioInfo.Tags.Contains("API"))
            {
                webDriver = Browser.InitBrowser(Configuration.BrowserName);
                if (Configuration.IsBrowserHeadless)
                    webDriver.Manage().Window.Size = new Size(1920, 1080);
                else
                    webDriver.Manage().Window.Maximize();

                objectContainer.RegisterInstanceAs(webDriver);

            }

            Log.Information("Selecting scenario hede to run");
           
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            if (objectContainer.IsRegistered<IWebDriver>())
            {
                objectContainer.Resolve<IWebDriver>().Close();
                objectContainer.Resolve<IWebDriver>().Dispose();
            }
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            Log.Information("Selecting feature file {0} to run", context.FeatureInfo.Title);
        }
    
        [AfterFeature]
        public static void CloseLogger()
        {
            // Logger.Instance.Close();
        }
    }