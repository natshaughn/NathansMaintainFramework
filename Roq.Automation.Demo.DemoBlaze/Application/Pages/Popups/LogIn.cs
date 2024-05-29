using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Application.Elements;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages.Popups
{
	public class LogIn 
	{
        private static IWebDriver driver => DriverManager.WebDriver;
        public static ElementWrapper LogInButton => new(driver, By.XPath("//button[text()='Log in']"));
        public static ElementWrapper Password => new(driver, By.Id("loginpassword"));
        public static ElementWrapper Username => new(driver, By.Id("loginusername"));
	}
}
