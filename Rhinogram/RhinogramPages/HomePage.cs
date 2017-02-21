using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Rhinogram
{
    internal class HomePage : Page
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[href='http://blog.rhinogram.com']")]
        internal IWebElement BlogLink { get; set; }

        internal HomePage Open()
        {
            driver.Url = "https://rhinogram.com/";
            return this;
        }
        internal void GoToBlog()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(BlogLink));
            BlogLink.Click();
        }
    }
}
