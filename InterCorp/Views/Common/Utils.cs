using Intercop.Web.UITests.Views.Common;
using NUnit.Framework;

namespace Intercop.Views.Common
{
    public class UITest
    {
        public TestUser Browser { get; private set; }

        [SetUp]
        public void StartBrowser()
        {
            Browser = new TestUser();
        }

        [TearDown]
        public void TearDown()
        {
            if (Browser != null)
            {
                Browser.Driver.WebDriver.Close();
                Browser.Driver.WebDriver.Quit();
            }
        }

        public void KillCurrentDriver()
        {
            Browser.Driver.Kill();
        }

    }
}