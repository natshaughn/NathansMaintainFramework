using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Application.Elements;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages.Popups
{
	public class ContactUs
	{
        private static IWebDriver driver => DriverManager.WebDriver;
        public static ElementWrapper Email => new(driver, By.Id("recipient-email"));
        public static ElementWrapper Message => new(driver, By.Id("message-text"));
        public static ElementWrapper Name => new(driver, By.Id("recipient-name"));
		public static ElementWrapper SendMessage => new(driver, By.XPath("//button[text()='Send message']"));

        public static void FillOutContactForm()
        {
            Email.SendKeys(Guid.NewGuid().ToString());
            Name.SendKeys(Guid.NewGuid().ToString());
            Message.SendKeys(Guid.NewGuid().ToString());
            SendMessage.Click();
        }
	}
}
