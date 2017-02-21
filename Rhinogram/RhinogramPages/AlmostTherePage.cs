using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Rhinogram
{
    internal class AlmostTherePage : Page
    {
        public AlmostTherePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@title='Almost there'][contains(., 'Create account')]")]
        internal IWebElement CreateAccountButton { get; set; }
        [FindsBy(How = How.Name, Using = "name")]
        internal IWebElement FullNameField { get; set; }

        internal void SwitchToPage()
        {
            driver.SwitchTo().Window(driver.WindowHandles[2]).Navigate();
        }
        internal void VerifyPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(CreateAccountButton));
            FullNameField.SendKeys("TEST CASE PASS");
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}
