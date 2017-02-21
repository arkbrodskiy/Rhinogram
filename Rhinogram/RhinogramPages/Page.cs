using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Rhinogram
{
    internal class Page
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        public IJavaScriptExecutor openNewTab;
        public Actions action;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            openNewTab = driver as IJavaScriptExecutor;
            action = new Actions(driver);
        }
    }
}
