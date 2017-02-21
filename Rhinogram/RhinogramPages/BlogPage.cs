using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Rhinogram
{
    internal class BlogPage : Page
    {
        public BlogPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[class='avatar-image u-size36x36 u-xs-size32x32']")]
        internal IWebElement Avatar { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[data-action = 'sign-in-prompt']")]
        internal IWebElement FollowButton { get; set; }
        internal void MouseOverAvatar()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Avatar));
            action.MoveToElement(Avatar).Perform();
        }
        internal void PushFollowButton()
        {
            FollowButton.Click();
            Thread.Sleep(1000);
        }
    }
}
