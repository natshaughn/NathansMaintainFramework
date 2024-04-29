using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Utilities;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.StepDefinitions
{
	[Binding]
	internal class Cart
	{
		[When(@"I place the order")]
		public void WhenIPlaceTheOrder()
		{
			DriverManager.WebDriver.FindElement(Pages.Cart.PlaceOrder).Click();

			DriverManager.WebDriver.FindElement(Pages.Popups.PlaceOrder.Name).SendKeys(Guid.NewGuid().ToString());
			DriverManager.WebDriver.FindElement(Pages.Popups.PlaceOrder.Country).SendKeys(Guid.NewGuid().ToString());
			DriverManager.WebDriver.FindElement(Pages.Popups.PlaceOrder.City).SendKeys(Guid.NewGuid().ToString());
			DriverManager.WebDriver.FindElement(Pages.Popups.PlaceOrder.CreditCard).SendKeys(Guid.NewGuid().ToString());
			DriverManager.WebDriver.FindElement(Pages.Popups.PlaceOrder.Month).SendKeys(Guid.NewGuid().ToString());
			DriverManager.WebDriver.FindElement(Pages.Popups.PlaceOrder.Year).SendKeys(Guid.NewGuid().ToString());

			DriverManager.WebDriver.FindElement(Pages.Popups.PlaceOrder.Purchase).Click();

		}

		[Then(@"the order is placed")]
		public void ThenTheOrderIsPlaced()
		{
            // Not an alert
            // Assert.IsTrue(Alerts.IsAlertPresent());

            // Check if the message is displayed
            IWebElement confirmationMessage = DriverManager.WebDriver.FindElement(By.XPath("//div[@class='sweet-alert  showSweetAlert visible']"));

            // Assert that the message is displayed
            Assert.IsTrue(confirmationMessage.Displayed, "Confirmation message is not displayed after placing the order.");
        }

    }
}