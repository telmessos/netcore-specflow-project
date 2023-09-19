using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace netcore_specflow_project.PageObjects;
[Binding]
    public class AlertsPage : Page
    {
        private CommonPage _commonPage;
        public AlertsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _commonPage = new CommonPage(_driver);
        }

        public IWebElement AlertButton => FindElementById("alertButton");
        public IWebElement TimerAlertButton => FindElementById("timerAlertButton");
        public IWebElement ConfirmAlertButton => FindElementById("confirmButton");
        public IWebElement ConfirmResult => FindElementById("confirmResult");
        public IWebElement PromptAlertButton => FindElementById("promtButton");
        public IWebElement PromptResult => FindElementById("promptResult");
        
        public void NavigateToAlertsPage()
        {
            _commonPage.NavigateTo("https://demoqa.com/alerts");
        }
    }
