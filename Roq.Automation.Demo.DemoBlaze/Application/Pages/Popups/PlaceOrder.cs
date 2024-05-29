using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Application.Elements;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages.Popups
{
	public class PlaceOrder
	{
        private static IWebDriver driver => DriverManager.WebDriver;
        public static ElementWrapper City => new(driver, By.Id("city"));
        public static ElementWrapper Country => new(driver, By.Id("country"));
        public static ElementWrapper CreditCard => new(driver, By.Id("card"));
        public static ElementWrapper Month => new(driver, By.Id("month"));
        public static ElementWrapper Name => new(driver, By.Id("name"));
        public static ElementWrapper Purchase => new(driver, By.XPath("//button[text()='Purchase']"));
        public static ElementWrapper Year => new(driver, By.Id("year"));

        public static void PlaceTheOrder()
        {
            Name.SendKeys(Guid.NewGuid().ToString());
            Country.SendKeys(Guid.NewGuid().ToString());
            City.SendKeys(Guid.NewGuid().ToString());
            CreditCard.SendKeys(Guid.NewGuid().ToString());
            Month.SendKeys(Guid.NewGuid().ToString());
            Year.SendKeys(Guid.NewGuid().ToString());
            Purchase.Click();
        }
	}
}
