using GoogleSearch.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleSearch.Factories
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.ChromeDriver:
                    return InitChromeDriver();
                default:
                    throw new NotSupportedException($"{driverType.ToString()} is not supported.");
            }
        }

        private static ChromeDriver InitChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            ChromeDriver webDriver = new ChromeDriver(options);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return webDriver;
        }
    }
}
