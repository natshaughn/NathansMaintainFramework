using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages
{
	public static class Product
	{
		public static By AddToCart => By.XPath("//a[text()='Add to cart']");

		public static By Description => By.XPath("//div[@id='myTabContent']//p");
		public static By ProductImage => By.XPath("//div[@class='item active']/img");

		public static string Getprice()
		{
			string price = DriverManager.WebDriver.FindElement(By.XPath("//h3[@class='price-container']")).Text.Replace("$", string.Empty);
			price = price.Replace(DriverManager.WebDriver.FindElement(By.XPath("//h3[@class='price-container']/small")).Text, string.Empty).Trim();
			return price;
		}
	}
}
