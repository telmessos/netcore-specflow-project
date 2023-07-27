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
        public void NavigateToAlertsPage()
        {
            _commonPage.NavigateTo("https://demoqa.com/alerts");
        }
    }
