using Roq.Automation.Demo.DemoBlaze.Pages;
using Roq.Automation.Demo.DemoBlaze.Utilities;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.Tests.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        [Given(@"I am on the demo blaze website")]
        public void GivenIAmOnTheDemoBlazeWebsite()
        {
            Assert.That(DriverManager.WebDriver.Url, Is.EqualTo("https://www.demoblaze.com/index.html"));
        }

        [Given(@"I am on a product page"), When(@"I am on a product page")]
        public void GivenIAmOnAProductPage()
        {
            Home.NavigateToRandomProductPage();
        }

        [Given(@"I navigate to my basket"), When(@"I navigate to my basket")]
        public void GivenINavigateToMyBasket()
        {
            Home.Cart.Click();
        }

        [When(@"I open the page for the (.*)")]
        public void WhenIOpenThePageForTheProduct(string productName)
        {
            Home.NavigateToProductPage(productName);
        }

        [When(@"I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            Home.NavigateToHomePage();
        }

        [When(@"I open the basket")]
        public void WhenIOpenTheBasket()
        {
            Home.Cart.Click();
        }

        [Then(@"the ""([^""]*)"" category is available")]
        public void ThenTheCategoryIsAvailable(string category) 
        {
            bool actualCategory = Home.IsCategoryAvailable(category);
            Assert.That(actualCategory, Is.True, $"{category} category is not available");
        }
    }
}