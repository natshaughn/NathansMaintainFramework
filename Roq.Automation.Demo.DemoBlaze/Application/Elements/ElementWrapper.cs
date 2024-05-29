using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Roq.Automation.Demo.DemoBlaze.Application.Elements
{
    public class ElementWrapper
    {
        private readonly IWebDriver driver;
        private readonly By by;

        public ElementWrapper(IWebDriver driver, By by)
        {
            this.driver = driver;
            this.by = by;
        }

        public By By => by;

        public void Click()
        {
            FindElement().Click();
        }

        public bool Exists()
        {
            return driver.FindElements(by).Count() > 0;
        }

        public IWebElement FindElement()
        {
            return driver.FindElement(by);
        }

        public string GetText()
        {
            return FindElement().Text;
        }

        public bool IsDisplayed()
        {
            return FindElement().Displayed;
        }

        public void SendKeys(string text)
        {
            FindElement().SendKeys(text);
        }

        public void WaitForAlert()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public void WaitForElement()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(by));
        }
    }
}
