using OpenQA.Selenium;
using Protractor;
using FS.Web.UITests.Views.Common;

namespace FS.Web.UITests.Views.Login
{
    public class LoginPageLocator 
    {
        NgWebDriver Web;

        public LoginPageLocator(WebUser webUser)
        {
            Web = webUser.Browser.WebDriver;
            Web.IgnoreSynchronization = false;

        }
        public By EmailField => By.Name("loginfmt");

        public NgWebElement EnterEmail => Web.FindElement(EmailField);
    }
}
