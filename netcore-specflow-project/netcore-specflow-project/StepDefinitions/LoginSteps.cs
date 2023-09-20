using BoDi;
using netcore_specflow_project.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace netcore_specflow_project.StepDefinitions;

[Binding]
public sealed class LoginSteps
{
    private readonly LoginPage _loginPage;

    public LoginSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer)
    {
        _loginPage = new LoginPage(objectContainer.Resolve<IWebDriver>());
    }

    [Given(@"user navigates to login page")]
    public void GivenUserNavigatesToLoginPage()
    {
        _loginPage.NavigateToLoginPage();
    }

    [When(@"user tries to login with empty username and password")]
    public void WhenUserTriesToLoginWithEmptyUsernameAndPassword()
    {
        _loginPage.Login("","");
    }

    [Then(@"error container should be displayed")]
    public void ThenErrorContainerShouldBeDisplayed()
    {
        Assert.True(_loginPage.ErrorContainer.Displayed, "Error container is not displayed");
    }

    [Then(@"error message should be ""(.*)""")]
    public void ThenErrorMessageShouldBe(string textToBeDisplayed)
    {
        string elementText = _loginPage.ErrorContainer.Text;
        Assert.True(elementText.Contains(textToBeDisplayed), "Error container does not contain " + textToBeDisplayed);
    }

    [When(@"user tries to login with username ""(.*)"" and password ""(.*)""")]
    public void WhenUserTriesToLoginWithUsernameAndPassword(string username, string password)
    {
        _loginPage.Login(username, password);
    }

    [Then(@"page header should contain text ""(.*)""")]
    public void ThenPageHeaderShouldContainText(string headerText)
    {
        string elementText = _loginPage.AppLogoDiv.Text;
        Assert.True(elementText.Contains(headerText), "Header text does not contain " + headerText);
    }
}