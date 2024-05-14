using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages
{
	public static class Cart
	{
		public static By PlaceOrder => By.XPath("//button[text()='Place Order']");
        public static By ConfirmationMessage => By.XPath("//div[@class='sweet-alert  showSweetAlert visible']");
        public static By BasketItems => By.XPath("//tbody[@id='tbodyid']/tr");

        public static bool PriceIsCorrect(int expected)
		{
			int actual = int.Parse(DriverManager.WebDriver.FindElement(By.XPath("//h3[@class='panel-title']")).Text);
			return actual == expected;
		}

        // Added the xpath above & method here 
        public static bool IsOrderConfirmationDisplayed()
        {
            IWebElement confirmationMessage = DriverManager.WebDriver.FindElement(ConfirmationMessage);
            return confirmationMessage.Displayed;
        }

        public static bool IsBasketEmpty()
        {
            return DriverManager.WebDriver.FindElements(BasketItems).Count == 0;
        }
    }
}
