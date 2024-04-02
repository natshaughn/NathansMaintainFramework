using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages
{
	public static class Cart
	{
		public static By PlaceOrder => By.XPath("//button[text()='Place Order']");

		public static bool PriceIsCorrect(int expected)
		{
			int actual = int.Parse(DriverManager.WebDriver.FindElement(By.XPath("//h3[@class='panel-title']")).Text);
			return actual == expected;
		}
	}
}
