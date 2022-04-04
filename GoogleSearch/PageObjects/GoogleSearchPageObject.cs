using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleSearch.PageObjects
{

    public class GoogleSearchPageObject
    {
        private IWebDriver _webDriver;
        private const string PageUrl = "https://www.google.com/";
        private const string CookiesButtonXpath = "//div[@class=\"QS5gu sy4vM\"]";
        private const string Consent1ButtonXpath = "//button[@class=\"VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-INsAgc VfPpkd-LgbsSe-OWXEXe-dgl2Hf Rj2Mlf OLiIxf PDpWxe P62QJc qfvgSe S82sre UAxHUb\"]";
        private const string Consent2ButtonXpath = "//button[@class=\"VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-INsAgc VfPpkd-LgbsSe-OWXEXe-dgl2Hf Rj2Mlf OLiIxf PDpWxe P62QJc qfvgSe S82sre\"]";
        private const string Consent3ButtonXpath = "//button[@class=\"VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-INsAgc VfPpkd-LgbsSe-OWXEXe-dgl2Hf Rj2Mlf OLiIxf PDpWxe P62QJc qfvgSe S82sre UAxHUb\"]";
        private const string Consent4ButtonXpath = "//button[@class=\"VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qfvgSe XICXwf\"]";
        private const string PhraseSearchInputXpath = "//input[@class=\"gLFyf gsfi\"]";
        private const string SearchButtonXpath = "//input[@class=\"gNO89b\"]";

        public GoogleSearchPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public void GoToPage()
        {
            _webDriver.Navigate().GoToUrl(PageUrl);
        }

        public void AcceptCookies()
        {
            try
            {
                _webDriver.FindElement(By.XPath(CookiesButtonXpath)).Click();
            }
            catch (StaleElementReferenceException)
            {
                _webDriver.FindElement(By.XPath(CookiesButtonXpath)).Click();
            }
        }

        public void AcceptConsent()
        {
            try
            {
                _webDriver.FindElement(By.XPath(Consent1ButtonXpath)).Click();
                _webDriver.FindElement(By.XPath(Consent2ButtonXpath)).Click();
                _webDriver.FindElement(By.XPath(Consent3ButtonXpath)).Click();
                _webDriver.FindElement(By.XPath(Consent4ButtonXpath)).Click();
            }
            catch (StaleElementReferenceException)
            {
                _webDriver.FindElement(By.XPath(Consent1ButtonXpath)).Click();
                _webDriver.FindElement(By.XPath(Consent2ButtonXpath)).Click();
                _webDriver.FindElement(By.XPath(Consent3ButtonXpath)).Click();
                _webDriver.FindElement(By.XPath(Consent4ButtonXpath)).Click();
            }
        }

        public void InputSearchParams(string searchPhrase)
        {
            _webDriver.FindElement(By.XPath(PhraseSearchInputXpath)).SendKeys(searchPhrase);
        }

        public void PressSearchButton()
        {
            IWebElement searchButtonElement = _webDriver.FindElement(By.XPath(SearchButtonXpath));
            (_webDriver as IJavaScriptExecutor)
                .ExecuteScript("arguments[0].scrollIntoView(true);", searchButtonElement);
            searchButtonElement.Click();
        }
    }
}
