using System;
using System.Collections.Specialized;
using System.Configuration;
using Intercop.Views.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;

namespace Intercop.Web.UITests.Views.Common
{
    public class ChromeDriver : CommonDriver, IDriver
    {
        public ChromeDriver()
        {
            var options = GetOptions();
            WebDriver = GetProtractorDriver(new OpenQA.Selenium.Chrome.ChromeDriver(ChromeDriverService.CreateDefaultService(), (ChromeOptions)options, TimeSpan.FromSeconds(90)));
            
                
        }

        public DriverType BrowserType => DriverType.CHROME;
        public NgWebDriver WebDriver { get; }

        public void Kill()
        {
            KillDriver("chromedriver");
        }

        private DriverOptions GetOptions()
        {
            var chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };

            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("--disable-plugins");
            chromeOptions.AddArgument("lang=en-US");
            chromeOptions.AcceptInsecureCertificates = true;

            try
            {
                var caps = ConfigurationManager.GetSection("capabilities/" + "chrome") as NameValueCollection;
                foreach (string key in caps.AllKeys)
                {
                    chromeOptions.AddAdditionalCapability(key, caps[key], true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set Chrome Options {ex}");
            }

            return chromeOptions;
        }
    }
}
