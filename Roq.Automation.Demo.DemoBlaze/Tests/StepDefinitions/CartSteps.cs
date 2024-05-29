using Roq.Automation.Demo.DemoBlaze.Pages;
using Roq.Automation.Demo.DemoBlaze.Pages.Popups;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.Tests.StepDefinitions
{
    [Binding]
    internal class CartSteps
    {
        [When(@"I place the order")]
        public void WhenIPlaceTheOrder()
        {
            Cart.PlaceOrder.Click();
            PlaceOrder.PlaceTheOrder();
        }

        [Then(@"the total of the basket is correct")]
        public void ThenTheTotalOfTheBasketIsCorrect()
        {
            string expectedPrice = Cart.GetExpectedPrice();
            string actualPrice = Cart.GetTotalPrice();
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), $"Expected: {expectedPrice}, Actual: {actualPrice}");
        }

        [Then(@"the total of my basket is (.*)")]
        public void ThenTheTotalOfMyBasketIs(string expectedTotal)
        {
            string actualTotal = Cart.GetTotalPrice();
            Assert.That(actualTotal, Is.EqualTo(expectedTotal), $"Expected: {expectedTotal}, Actual: {actualTotal}");
        }

        [Then(@"my basket is empty")]
        public void ThenMyBasketIsEmpty()
        {
            string basketTotal = Cart.IsBasketEmpty();
            Assert.That(basketTotal, Is.EqualTo(string.Empty), $"The basket is not empty: {basketTotal}"); 
        }

        [Then(@"the order is placed")]
        public void ThenTheOrderIsPlaced()
        {
            Assert.That(Cart.IsOrderConfirmationDisplayed(), Is.True, "Confirmation message is not displayed after placing the order.");
        }

    }
}