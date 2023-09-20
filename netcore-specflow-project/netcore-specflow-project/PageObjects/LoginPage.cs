using OpenQA.Selenium;

namespace netcore_specflow_project.PageObjects;

public class LoginPage : Page
{
    private CommonPage _commonPage;
    public LoginPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
        _commonPage = new CommonPage(_driver);
    }
    
    public IWebElement Username => FindElementById("user-name");
    public IWebElement Password => FindElementById("password");
    public IWebElement LoginButton => FindElementById("login-button");
    public IWebElement ErrorContainer => FindElementByCssSelector("#login_button_container > div > form > div.error-message-container.error > h3");
    public IWebElement AppLogoDiv => FindElementByCssSelector("#header_container > div.primary_header > div.header_label > div.app_logo");

    public void Login(string username, string password)
    {
        _commonPage.SendKeys(Username, username);
        _commonPage.SendKeys(Password, password);
        LoginButton.Click();
    }
    public void NavigateToLoginPage()
    {
        _commonPage.NavigateTo("https://www.saucedemo.com/");
    }
}