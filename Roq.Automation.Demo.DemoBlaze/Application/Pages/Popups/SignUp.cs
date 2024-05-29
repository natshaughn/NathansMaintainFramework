using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Application.Elements;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages.Popups
{
	public class SignUp 
	{
        private static IWebDriver driver => DriverManager.WebDriver;
        public static ElementWrapper Password => new(driver, By.Id("sign-password"));
        public static ElementWrapper SignUpButton => new(driver, By.XPath("//button[text()='Sign up']"));
        public static ElementWrapper Username => new(driver, By.Id("sign-username"));		
	}
}
