using BoDi;
using netcore_specflow_project.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace netcore_specflow_project.StepDefinitions;

[Binding]
public class AlertsSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IObjectContainer _objectContainer;
    private readonly FeatureContext _featureContext;
    private readonly CommonPage _commonPage;
    private readonly AlertsPage _alertsPage;
    public AlertsSteps(IObjectContainer objectContainer, ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _objectContainer = objectContainer;
        _commonPage = new CommonPage(objectContainer.Resolve<IWebDriver>());
        _alertsPage = new AlertsPage(objectContainer.Resolve<IWebDriver>());
    }
    
    [Given(@"user navigates to alert test page")]
    public void GivenUserNavigatesToAlertTestPage()
    {
        _alertsPage.NavigateToAlertsPage();
    }

    [When(@"user clicks alert button")]
    public void WhenUserClicksAlertButton()
    {
        _alertsPage.AlertButton.Click();
    }

    [Then(@"alert should be displayed")]
    public void ThenAlertShouldBeDisplayed()
    {
        Assert.True(_commonPage.IsAlertOpen(), "Alert is not displayed");
    }

    [Then(@"alert text should be ""(.*)""")]
    public void ThenAlertTextShouldBe(string AlertText)
    {
        string pageTitle = _commonPage.GetAlertText();
        Assert.True(AlertText.Equals(pageTitle), "Alert text is not equal to " + AlertText);
    }
}