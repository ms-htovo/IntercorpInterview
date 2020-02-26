using FS.Web.UITests.Views.Common;
using System.Configuration;

namespace FS.Web.UITests.Views.Login
{
    public class LoginPage : BasicView
    {
        public LoginPage(WebUser webUser) : base(webUser)
        {
            webUser.Browser.WebDriver.IgnoreSynchronization = false;
            Browser.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);
            Locate = new LoginPageLocator(webUser);
        }

        public LoginPageLocator Locate { get; }

        public LoginPage ClickOnEnterEmail()
        {
            ExplicitWait(Locate.EmailField);
            Locate.EnterEmail.Click();
            return this;
        }

        public LoginPage EnterEmail(string email = "htovo@frogslayer.com")
        {
            Locate.EnterEmail.SendKeys(email);
            return this;
        }
    }
}
