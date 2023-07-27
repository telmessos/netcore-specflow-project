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
        string PageTitle = _driver.Title;
        return _driver.Title;
    }

    public string GetAlertText()
    {
        var Alert = _driver.SwitchTo().Alert();
        string AlertText = Alert.Text;
        Alert.Dismiss();
        return AlertText;
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
}