﻿using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace netcore_specflow_project.PageObjects;
[Binding]
    public abstract class Page
    {
        protected IWebDriver _driver;

        protected Page(IWebDriver driver)
        {
            _driver = driver;
        }

        protected Page()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElementByXpath(string Xpath)
        {
            Thread.Sleep(500);
            return _driver.FindElement(By.XPath(Xpath));
        }

        public IWebElement FindElementById(string IdText)
        {
            Thread.Sleep(500);
            return _driver.FindElement(By.Id(IdText));
        }

        
        
        public void LongSleep()
        {
            Thread.Sleep(4000);
        }
        public void MediumSleep()
        {
            Thread.Sleep(1000);
        }
        public void ShortSleep()
        {
            Thread.Sleep(350);
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        
    }