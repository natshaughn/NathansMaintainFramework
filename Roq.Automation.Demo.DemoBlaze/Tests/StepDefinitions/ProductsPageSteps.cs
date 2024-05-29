using Roq.Automation.Demo.DemoBlaze.Pages;

using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.Tests.StepDefinitions
{
    [Binding]
    public class ProductsPageSteps
    {
        [Given(@"I add the product to my basket"), When(@"I add the product to my basket")]
        public void WhenIAddTheProductToMyBasket()
        {
            Product.AddProductToBasket();
        }

        [Then(@"the product description is (.*)")]
        public void ThenTheProductDescriptionIs(string expectedDescription)
        {
            string actualDescription = Product.GetDescription(); 
            Assert.That(actualDescription, Is.EqualTo(expectedDescription), $"Expected description: {expectedDescription}, Actual description: {actualDescription}");
        }

        [Then(@"the price is (.*)")]
        public void ThenThePriceIs(int expectedPrice)
        {
            int actualPrice = int.Parse(Product.Getprice());
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), $"Expected price: {expectedPrice}, Actual price: {actualPrice}");
        }

        [Then(@"the product image is displayed")]
        public void ThenTheProductImageIsDisplayed()
        {
            Assert.That(Product.ProductImage.IsDisplayed(), "Product image is not being displayed");
        }
    }
}
