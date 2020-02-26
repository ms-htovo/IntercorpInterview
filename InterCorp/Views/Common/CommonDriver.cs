using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using Protractor;

namespace Intercop.Web.UITests.Views.Common
{
    public abstract class CommonDriver
    {
        public bool RequireLocalBrowser => ConfigurationManager.AppSettings["server_configuration"].Equals("LOCAL", StringComparison.InvariantCultureIgnoreCase);
        public string GetLocalDriverUrl =>  $"http://{ConfigurationManager.AppSettings["local_server"]}/wd/hub";
       
        public NgWebDriver GetProtractorDriver(IWebDriver driver)
        {
            try
            {
                var protractor = new NgWebDriver(driver);
                protractor.Manage().Window.Maximize();
                protractor.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
                protractor.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return protractor;
            }
            catch (Exception Ex)
            {
                throw new Exception($"Failed to Convert Selenium Driver to Protractor Driver{Ex}");
            }
        }
        public void KillDriver(string processName)
        {
            var browser = Process.GetProcessesByName(processName);

            if (browser != null)
            {
                foreach (var browserProcress in browser)
                {
                    try
                    {
                        browserProcress.Kill();
                        browserProcress.WaitForExit();
                    }
                    catch (Win32Exception)
                    {
                        if (browserProcress.HasExited)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("Unable to kill WebDriver process");
                        }
                    }
                }
            }
        }
    }
}
