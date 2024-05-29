using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Application.Elements;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages
{
	public static class Cart
	{
        private static IWebDriver driver => DriverManager.WebDriver;
        public static ElementWrapper BasketItems => new(driver, By.XPath("//tbody[@id='tbodyid']/tr"));
        public static ElementWrapper ConfirmationMessage => new(driver, By.XPath("//div[@class='sweet-alert  showSweetAlert visible']"));
        public static ElementWrapper PlaceOrder => new(driver, By.XPath("//button[text()='Place Order']"));
        public static ElementWrapper ProductVisible => new(driver, By.XPath("//tr[@class='success']"));
        public static ElementWrapper TotalPrice => new(driver, By.Id("totalp"));

        public static string IsBasketEmpty()
        {
            string totalIsEmpty = TotalPrice.GetText();
            return totalIsEmpty;
        }

        public static bool IsOrderConfirmationDisplayed()
        {
            return ConfirmationMessage.IsDisplayed();
        }

        public static string GetExpectedPrice()
        {
            return TestData.TestDataDictionary["CartTotal"].ToString();
        }

        public static string GetTotalPrice()
        {
            ProductVisible.WaitForElement();
            return TotalPrice.GetText();
        }

        public static bool PriceIsCorrect(int expected)
        {           
            int actual = int.Parse(GetTotalPrice());
            return actual == expected;
        }
    }
}
