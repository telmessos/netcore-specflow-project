using OpenQA.Selenium;

namespace netcore_specflow_project.PageObjects;

public class CommonPage : Page
{
    public CommonPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }
    public void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);
    public string GetPageTitle()
    {
        return _driver.Title;
    }

    public string GetAlertText(bool dismiss = true)
    {
        var alert = _driver.SwitchTo().Alert();
        string alertText = alert.Text;
        if (dismiss)
        {
            alert.Dismiss();
        }
        return alertText;
    }

    public void SendStringToPrompt(string textToSend)
    {
        var alert = _driver.SwitchTo().Alert();
        alert.SendKeys(textToSend);
    }

    public void AcceptAlert()
    {
        var alert = _driver.SwitchTo().Alert();
        alert.Accept();
    }

    public bool IsAlertOpen()
    {
        try 
        { 
            _driver.SwitchTo().Alert(); 
            return true; 
        }
        catch (NoAlertPresentException Ex) 
        { 
            return false; 
        }
    }

    public void SendKeys(IWebElement elementToSendKeys, string textToSend)
    {
        elementToSendKeys.Clear();
        elementToSendKeys.SendKeys(textToSend);
    } 
}