using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Rhinogram
{
    internal class GmailPage : Page
    {
        public GmailPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Email")]
        internal IWebElement GmailField { get; set; }
        [FindsBy(How = How.Id, Using = "next")]
        internal IWebElement NextButton { get; set; }
        [FindsBy(How = How.Id, Using = "Passwd")]
        internal IWebElement PasswordField { get; set; }
        [FindsBy(How = How.Id, Using = "signIn")]
        internal IWebElement SignInButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@id=':3f'][contains(., 'Finish creating your account on Medium')]")]
        internal IWebElement UnreadSubscriptionMessage { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[class='asf T-I-J3 J-J5-Ji']")]
        internal IWebElement SendReceiveButton { get; set; }

        internal void OpenInNewTab()
        {
            openNewTab.ExecuteScript("window.open()");
            driver.SwitchTo().Window(driver.WindowHandles[1]).Navigate().GoToUrl("https://mail.google.com/");
        }
        internal void LogIn(string gmailId, string gmailPass)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(GmailField));
            GmailField.SendKeys(gmailId);
            NextButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(PasswordField));
            PasswordField.SendKeys(gmailPass);
            SignInButton.Click();
        }
        internal void OpenUnreadMessage()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(UnreadSubscriptionMessage));
                UnreadSubscriptionMessage.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Thread.Sleep(10000);
                //SendReceiveButton.Click();
                //Thread.Sleep(3000);
                //wait.Until(ExpectedConditions.ElementToBeClickable(UnreadSubscriptionMessage));
                UnreadSubscriptionMessage.Click();
            }
        }
    }
}
