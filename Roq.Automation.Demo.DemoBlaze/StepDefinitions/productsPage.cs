using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.StepDefinitions
{
	[Binding]
	internal class ProductsPage
	{
		[When(@"I open the product page for the ""([^""]*)""")]
		public void WhenIOpenTheProductPageForThe(string productName)
		{
			Utilities.DriverManager.WebDriver.FindElement(By.XPath($"//a[text()='{productName}']")).Click();
		}

		[Then(@"the price per unit is ""([^""]*)""")]
		public void ThenThePricePerUnitIs(string expectedPrice)
		{
            //string expectedPrice = p0;
            //Assert.AreEqual(expectedPrice, Pages.Product.Getprice());

            // Actual price from the product page
            string actualPrice = Pages.Product.Getprice();

            // Add an assertion to compare the expected and actual prices
            Assert.AreEqual(expectedPrice, actualPrice, $"Expected price: {expectedPrice}, Actual price: {actualPrice}");
        }

        
		[Then(@"the product description is:")]
		public void ThenTheProductDescriptionIs(Table table)
		{
			string description = table.Rows[0][0]; // WHATS THIS DO?????

			Assert.IsTrue(Utilities.DriverManager.WebDriver.FindElement(Pages.Product.Description).Text == description, $"{description} that is being displayed");
		}

		[Then(@"the product image is displayed")]
		public void ThenTheProductImageIsDisplayed()
		{
			Assert.IsTrue(Utilities.DriverManager.WebDriver.FindElement(Pages.Product.ProductImage).Displayed, "Product image is not being displayed");
		}

	}
}
