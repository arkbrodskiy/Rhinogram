using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace Rhinogram
{
    [TestFixture]
    public class RhinogramTest
    {
        private HomePage homePage;
        private BlogPage blogPage;
        private SignInPage signInPage;
        private GmailPage gmailPage;
        private GmailMessagePage gmailMessagePage;
        private AlmostTherePage almostTherePage;
        public IWebDriver driver;

        public RhinogramTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Window.Size = new Size(1320, 700);
            homePage = new HomePage(driver);
            blogPage = new BlogPage(driver);
            signInPage = new SignInPage(driver);
            gmailPage = new GmailPage(driver);
            gmailMessagePage = new GmailMessagePage(driver);
            almostTherePage = new AlmostTherePage(driver);
        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
        [Test]
        public void GetSubscriptionEmail()
        {
            homePage.Open();
            homePage.GoToBlog();
            blogPage.MouseOverAvatar();
            blogPage.PushFollowButton();
            signInPage.SignInWithEmail("rhinogramtest@gmail.com");
            gmailPage.OpenInNewTab();
            gmailPage.LogIn("rhinogramtest@gmail.com", "Pkp4eded");
            gmailPage.OpenUnreadMessage();
            gmailMessagePage.ClickCreateAccountButton();
            almostTherePage.SwitchToPage();
            almostTherePage.VerifyPage();
            gmailMessagePage.SwitchToPage();
            gmailMessagePage.DeleteMessage();
        }
    }
}
