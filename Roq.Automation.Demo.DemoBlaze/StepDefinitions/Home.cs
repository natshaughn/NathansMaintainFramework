using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using Roq.Automation.Demo.DemoBlaze.Utilities;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.StepDefinitions
{
	[Binding]
	public class Home
	{
		[Given(@"I am on the demo blaze website")]
		public void GivenIAmOnTheDemoBlazeWebsite()
		{
			DriverManager.WebDriver.Navigate().GoToUrl(Pages.Home.url);
            DriverManager.WebDriver.FindElement(Pages.Home.SignUp).Click();

            string username = Guid.NewGuid().ToString();
			string password = Guid.NewGuid().ToString();			

			DriverManager.WebDriver.FindElement(Pages.Popups.SignUp.Username).SendKeys(username);
			DriverManager.WebDriver.FindElement(Pages.Popups.SignUp.Password).SendKeys(password);
			DriverManager.WebDriver.FindElement(Pages.Popups.SignUp.SignUpButton).Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));
			//SpinWait.SpinUntil(() => DriverManager.WebDriver.SwitchTo().Alert(), TimeSpan.FromSeconds(5));
            DriverManager.WebDriver.SwitchTo().Alert().Accept();

            //Thread.Sleep(TimeSpan.FromSeconds(3));

			SpinWait.SpinUntil(() => DriverManager.WebDriver.FindElement(Pages.Home.LogIn).Equals("login2"), TimeSpan.FromSeconds(3));
            DriverManager.WebDriver.FindElement(Pages.Home.LogIn).Click();
			//Thread.Sleep(TimeSpan.FromSeconds(3));

			DriverManager.WebDriver.FindElement(Pages.Popups.LogIn.Username).SendKeys(username);
			DriverManager.WebDriver.FindElement(Pages.Popups.LogIn.Password).SendKeys(password);
			DriverManager.WebDriver.FindElement(Pages.Popups.LogIn.LogInButton).Click();
            //Thread.Sleep(TimeSpan.FromSeconds(3));
            SpinWait.SpinUntil(() => DriverManager.WebDriver.FindElement(Pages.Home.LogOut).Equals("logout2"), TimeSpan.FromSeconds(3));

            // Added to check that Login button has gone after logging in
            Assert.IsTrue(DriverManager.WebDriver.FindElement(Pages.Home.LogOut).Displayed, "LogOut button is not displayed after logging in");
        }

		[Given(@"I am on a product page")]
		public void GivenIAmOnAProductPage()
		{
			List<IWebElement> cards = DriverManager.WebDriver.FindElements(By.XPath("//h4[@class='card-title']/a")).ToList();
			IWebElement card = cards[new Random().Next(0, cards.Count)];
			card.Click();
		}

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
			Thread.Sleep(TimeSpan.FromSeconds(5));
			DriverManager.WebDriver.SwitchTo().Alert().Accept();
		}

        [Given(@"I navigate to my basket")]
        public void GivenINavigateToMyBasket()
        {
            By cart = Pages.Home.Cart;
            IWebElement cartElement = DriverManager.WebDriver.FindElement(cart);
            cartElement.Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        [When(@"I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            DriverManager.WebDriver.Navigate().GoToUrl(Pages.Home.url);
        }

        [When(@"I navigate to my basket")]
		public void WhenINavigateToMyBasket()
		{
			By cart = Pages.Home.Cart;
			IWebElement cartElement = DriverManager.WebDriver.FindElement(cart);
			cartElement.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [When(@"I open the basket")]
        public void WhenIOpenTheBasket()
        {
            DriverManager.WebDriver.FindElement(Pages.Home.Cart).Click();
        }

        /*[Then(@"the total of my basket is correct")]
		public void ThenTheTotalOfMyBasketIsCorrect()
		{
			Assert.IsTrue(Pages.Cart.PriceIsCorrect((int)TestData.TestDataDictionary["CartTotal"]));
		}*/

        [Then(@"the total of the basket is correct")]
        public void ThenTheTotalOfTheBasketIsCorrect()
        {
            Assert.IsTrue(Pages.Cart.PriceIsCorrect((int)TestData.TestDataDictionary["CartTotal"]), "Total price of the basket is incorrect");
        }

		[Then(@"the total of my basket is (.*)")]
        public void ThenTheTotalOfMyBasketIs(int total)
        {
            Assert.IsTrue(Pages.Cart.PriceIsCorrect(total), $"The actual total of the basket is {total}");
        }

		[Then(@"my basket is empty")]
		public void ThenMyBasketIsEmpty()
		{
			Assert.IsTrue(DriverManager.WebDriver.FindElements(By.XPath("//tbody[@id='tbodyid']/tr")).Count == 0, "The basket is not empty");
		}

		[Then(@"the ""([^""]*)"" category is available")]
		public void ThenTheCategoryIsAvailable(string category)
		{
			Assert.IsTrue(DriverManager.WebDriver.FindElements(By.XPath($"//a[text()='{category}']")).Count == 1, $"{category} category is not available");
		}
	}
}