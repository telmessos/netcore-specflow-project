using BoDi;
using netcore_specflow_project.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace netcore_specflow_project.StepDefinitions;

[Binding]
public class AlertsSteps
{
    private readonly CommonPage _commonPage;
    private readonly AlertsPage _alertsPage;
    public AlertsSteps(IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
    {
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
    public void ThenAlertTextShouldBe(string alertText)
    {
        string pageTitle = _commonPage.GetAlertText();
        Assert.True(alertText.Equals(pageTitle), "Alert text is not equal to " + alertText);
    }

    [When(@"user clicks on delayed alert button")]
    public void GivenUserClicksOnDelayedAlertButton()
    {
        _alertsPage.TimerAlertButton.Click();
    }

    [When(@"user waits for ""(.*)"" seconds")]
    public void WhenUserWaitsForSeconds(string secondsString)
    {
        int secondsToWait = Int32.Parse(secondsString) * 1000;
        Thread.Sleep(secondsToWait);
    }

    [When(@"user clicks on confirm alert button")]
    public void WhenUserClicksOnConfirmAlertButton()
    {
        _alertsPage.ConfirmAlertButton.Click();
    }

    [When(@"user confirms alert")]
    public void WhenUserConfirmsAlert()
    {
        _commonPage.AcceptAlert();
    }

    [Then(@"confirm result text should contain ""(.*)""")]
    public void ThenConfirmResultTextShouldContain(string textToContain)
    {
        string elementText = _alertsPage.ConfirmResult.Text;
        Assert.True(elementText.Contains(textToContain), "Element text does not contain " + textToContain);
    }

    [Then(@"no dismiss alert text should be ""(.*)""")]
    public void ThenNoDismissAlertTextShouldBe(string alertText)
    {
        string pageTitle = _commonPage.GetAlertText(false);
        Assert.True(alertText.Equals(pageTitle), "Alert text is not equal to " + alertText);
    }

    [When(@"user clicks prompt alert button")]
    public void WhenUserClicksPromptAlertButton()
    {
        _alertsPage.PromptAlertButton.Click();
    }

    [When(@"user sends ""(.*)"" to prompt box")]
    public void WhenUserSendsToPromptBox(string stringToSend)
    {
        _commonPage.SendStringToPrompt(stringToSend);
    }

    [When(@"user accepts alert")]
    public void WhenUserAcceptsAlert()
    {
        _commonPage.AcceptAlert();
    }

    [Then(@"prompt result text should contain ""(.*)""")]
    public void ThenPromptResultTextShouldContain(string textToContain)
    {
        string elementText = _alertsPage.PromptResult.Text;
        Assert.True(elementText.Contains(textToContain), "Prompt result does not contain " + textToContain);
    }
}