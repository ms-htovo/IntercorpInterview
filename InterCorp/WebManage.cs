using System;
using System.Configuration;
using Intercop.Views.Common;
using Intercop.Web.UITests.Views.Common;

namespace Intercop.Web.UITests
{
    public class WebManage
    {
        public IDriver Start()
        {
            try
            {
                return DriverFactory.Get(GetBrowserType());
            }
            catch (Exception ex)
            {
                throw new Exception($"Driver Coud not be launched. {ex}");
            }
        }

        private DriverType GetBrowserType()
        {
            var browser = Environment.GetEnvironmentVariable("BROWSER");

            try
            {
                if (string.IsNullOrEmpty(browser))
                {
                    browser = ConfigurationManager.AppSettings["browser"];
                }
                return (DriverType)Enum.Parse(typeof(DriverType), browser);
            }
            catch (Exception Ex)
            {
                throw new Exception($"Browser can't be gotten. {Ex}");
            }
        }

        public IDriver GetCurrentDriver()
        {
            try
            {
                return DriverFactory.Get(GetBrowserType());
            }
            catch (Exception ex)
            {
                throw new Exception($"Browser is not avialbl. {ex}");
            }
        }

    }
}