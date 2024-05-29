using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Application.Elements;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages
{
	public static class Product
	{
        private static IWebDriver driver => DriverManager.WebDriver;
        public static ElementWrapper AddToCart => new(driver, By.XPath("//a[text()='Add to cart']"));
		public static ElementWrapper Description => new(driver, By.XPath("//div[@id='myTabContent']//p"));
		public static ElementWrapper Price => new(driver, By.XPath("//h3[@class='price-container']"));
		public static ElementWrapper IncludesTaxText => new(driver, By.XPath("//h3[@class='price-container']/small"));
		public static ElementWrapper ProductImage => new(driver, By.XPath("//div[@class='item active']/img"));

		public static void AddProductToBasket()
		{
            string stringPrice = Getprice();
            int price = int.Parse(stringPrice);

            if (TestData.TestDataDictionary.ContainsKey("CartTotal"))
            {
                int total = (int)TestData.TestDataDictionary["CartTotal"];
                TestData.TestDataDictionary["CartTotal"] = total + price;
            }
            else
            {
                TestData.TestDataDictionary.Add("CartTotal", price);
            }

            AddToCart.Click();
            AddToCart.WaitForAlert();
            driver.SwitchTo().Alert().Accept();
        }

		public static string Getprice()
		{
			string price = Price.GetText().Replace("$", string.Empty);
			return price.Replace(IncludesTaxText.GetText(), string.Empty).Trim();
		}

		public static string GetDescription()
		{
			Description.Exists();
			return Description.GetText();
		}
	}
}
