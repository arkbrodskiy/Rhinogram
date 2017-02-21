using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Rhinogram
{
    internal class GmailMessagePage : Page
    {
        public GmailMessagePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(., 'Create account on Medium')]")]
        internal IWebElement CreateAccountButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=':5']/div[2]/div[1]/div/div[2]/div[3]/div/div")]
        internal IWebElement DeleteButton { get; set; }

        internal void ClickCreateAccountButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(CreateAccountButton));
            CreateAccountButton.Click();
        }
        internal void SwitchToPage()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]).Navigate();
        }
        internal void DeleteMessage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(DeleteButton));
            DeleteButton.Click();
            Thread.Sleep(1000);
        }
    }
}
