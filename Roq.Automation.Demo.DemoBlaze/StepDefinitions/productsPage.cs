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
	internal class productsPage
	{
		[When(@"I open the product page for the ""([^""]*)""")]
		public void WhenIOpenTheProductPageForThe(string p0)
		{
			string productName = p0;
			Utilities.DriverManager.WebDriver.FindElement(By.XPath($"//a[text()='{productName}']")).Click();
		}

		[Then(@"the price per unit is ""([^""]*)""")]
		public void ThenThePricePerUnitIs(string p0)
		{
			string expectedPrice = p0;
			Assert.AreEqual(expectedPrice, Pages.Product.Getprice());
		}

		[Then(@"the product description is:")]
		public void ThenTheProductDescriptionIs(Table table)
		{
			string description = table.Rows[0][0];
			Assert.IsTrue(Utilities.DriverManager.WebDriver.FindElement(Pages.Product.Description).Text == description);
		}

		[Then(@"the product image is displayed")]
		public void ThenTheProductImageIsDisplayed()
		{
			Assert.IsTrue(Utilities.DriverManager.WebDriver.FindElement(Pages.Product.ProductImage).Displayed);
		}

	}
}
