using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Rhinogram
{
    internal class SignInPage : Page
    {
        public SignInPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[data-action = 'email-sign-in-prompt']")]
        internal IWebElement EmailLink { get; set; }
        [FindsBy(How = How.Name, Using = "email")]
        internal IWebElement EmailField { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[data-action = 'email-auth']")]
        internal IWebElement SubmitEmailLink { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[data-action = 'overlay-close']")]
        internal IWebElement OkButton { get; set; }

        internal void SignInWithEmail(string email)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(EmailLink));
            EmailLink.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(EmailField));
            EmailField.SendKeys(email);
            SubmitEmailLink.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(OkButton));
            OkButton.Click();
        }
    }
}
