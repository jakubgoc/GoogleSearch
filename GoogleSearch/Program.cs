using GoogleSearch.Enums;
using GoogleSearch.Factories;
using GoogleSearch.PageObjects;
using OpenQA.Selenium;

class Program
{
    static void Main(string[] args)
    {
        string SearchPhrase = "test";

        RunWebsiteCrawl(SearchPhrase);
    }

    private static void RunWebsiteCrawl(string SearchPhrase)
    {
        IWebDriver webDriver = WebDriverFactory.CreateDriver(DriverType.ChromeDriver);
        GoogleSearchPageObject googleSearchPageObject = new GoogleSearchPageObject(webDriver);

        googleSearchPageObject.GoToPage();
        googleSearchPageObject.AcceptCookies();
        googleSearchPageObject.AcceptConsent();
        googleSearchPageObject.InputSearchParams(SearchPhrase);
        googleSearchPageObject.PressSearchButton();

        webDriver.Dispose();
    }
}