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

        [Then(@"the total of the basket is correct")]
        public void ThenTheTotalOfTheBasketIsCorrect()
        {
            Thread.Sleep(5000); // fails without sleep 
            Assert.That(Pages.Cart.PriceIsCorrect((int)TestData.TestDataDictionary["CartTotal"]), Is.True, "Total price of the basket is incorrect");
        }

        [Then(@"the total of my basket is (.*)")]
        public void ThenTheTotalOfMyBasketIs(int total)
        {
            Thread.Sleep(5000); // without the sleep it fails when making it one test
            Assert.That(Pages.Cart.PriceIsCorrect(total), Is.True, $"The actual total of the basket is {total}");

        }

        [Then(@"my basket is empty")]
        public void ThenMyBasketIsEmpty()
        {
            /*Assert.That(DriverManager.WebDriver.FindElements(By.XPath("//tbody[@id='tbodyid']/tr")).Count, Is.EqualTo(0), "The basket is not empty");*/
            Assert.That(Pages.Cart.IsBasketEmpty(), Is.True, "The basket is not empty");
        }

        [Then(@"the order is placed")]
		public void ThenTheOrderIsPlaced()
		{
            /*// Not an alert
            // Assert.IsTrue(Alerts.IsAlertPresent());

            // Check if the message is displayed
            IWebElement confirmationMessage = DriverManager.WebDriver.FindElement(By.XPath("//div[@class='sweet-alert  showSweetAlert visible']"));

            // Assert that the message is displayed
            *//*Assert.IsTrue(confirmationMessage.Displayed, "Confirmation message is not displayed after placing the order.");*//*
            Assert.That(confirmationMessage.Displayed, Is.True, "Confirmation message is not displayed after placing the order.");*/

            // Check if the order confirmation message is displayed
            Assert.That(Pages.Cart.IsOrderConfirmationDisplayed(), Is.True, "Confirmation message is not displayed after placing the order.");
        }

    }
}