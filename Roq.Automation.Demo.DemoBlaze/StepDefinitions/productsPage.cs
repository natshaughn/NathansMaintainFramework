using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.StepDefinitions
{
	[Binding]
	public class ProductsPage
	{
        // Moved from home step def
        [Given(@"I add the product to my basket"), When(@"I add the product to my basket")]
        public void WhenIAddTheProductToMyBasket()
        {
            string stringPrice = Pages.Product.Getprice();
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

            DriverManager.WebDriver.FindElement(Pages.Product.AddToCart).Click();
            //SpinWait.SpinUntil(() => DriverManager.WebDriver.SwitchTo().Alert(), TimeSpan.FromSeconds(5));
            Thread.Sleep(TimeSpan.FromSeconds(5)); // How to get rid of this? Spin Wait above doesn't work
            DriverManager.WebDriver.SwitchTo().Alert().Accept();
        }




        /*		[Then(@"the price per unit is ""([^""]*)""")]
                public void ThenThePricePerUnitIs(string expectedPrice)
                {
                    //string expectedPrice = p0;
                    //Assert.AreEqual(expectedPrice, Pages.Product.Getprice());

                    // Actual price from the product page
                    string actualPrice = Pages.Product.Getprice();

                    // Add an assertion to compare the expected and actual prices
                    Assert.That(expectedPrice, Is.EqualTo(actualPrice), $"Expected price: {expectedPrice}, Actual price: {actualPrice}");
                }*/



        [Then(@"the product description is (.*)")]
        public void ThenTheProductDescriptionIs(string expectedDescription)
        {
            // Actual description from the product page
            string actualDescription = DriverManager.WebDriver.FindElement(Pages.Product.Description).Text;

            // Add an assertion to compare the expected and actual descriptions
            Assert.That(actualDescription, Is.EqualTo(expectedDescription), $"Expected description: {expectedDescription}, Actual description: {actualDescription}");
        }

        [Then(@"the price is (.*)")]
        public void ThenThePriceIs(int expectedPrice)
        {
            // Actual price from the product page
            int actualPrice = int.Parse(Pages.Product.Getprice());

            // Add an assertion to compare the expected and actual prices
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), $"Expected price: {expectedPrice}, Actual price: {actualPrice}");
        }

        [Then(@"the product image is displayed")]
        public void ThenTheProductImageIsDisplayed()
        {
            Assert.That(DriverManager.WebDriver.FindElement(Pages.Product.ProductImage).Displayed, "Product image is not being displayed");
        }



        /*        [Then(@"the product description is:")]
                public void ThenTheProductDescriptionIs(Table table)
                {
                    string description = table.Rows[0][0]; // WHATS THIS DO?????

                    Assert.That(Utilities.DriverManager.WebDriver.FindElement(Pages.Product.Description).Text, Is.EqualTo(description), $"{description} that is being displayed");
                }

                [Then(@"the product image is displayed")]
                public void ThenTheProductImageIsDisplayed()
                {
                    Assert.That(Utilities.DriverManager.WebDriver.FindElement(Pages.Product.ProductImage).Displayed, "Product image is not being displayed");
                }*/

    }
}
