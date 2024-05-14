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
			//DriverManager.WebDriver.Navigate().GoToUrl(Pages.Home.url);
			/*DriverManager.WebDriver.FindElement(Pages.Home.SignUp).Click();

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
            SpinWait.SpinUntil(() => DriverManager.WebDriver.FindElement(Pages.Home.LogOut).Equals("logout2"), TimeSpan.FromSeconds(3));*/

			// Added to check that Login button has gone after logging in
			//Assert.That(DriverManager.WebDriver.FindElement(Pages.Home.LogIn).Displayed, "LogIn button is not displayed after logging in");
			Assert.That(DriverManager.WebDriver.Url, Is.EqualTo("https://www.demoblaze.com/index.html"));
        }

		[Given(@"I am on a product page"), When(@"I am on a product page")]
		public void GivenIAmOnAProductPage()
		{
            /*List<IWebElement> cards = DriverManager.WebDriver.FindElements(By.XPath("//h4[@class='card-title']/a")).ToList();
			IWebElement card = cards[new Random().Next(0, cards.Count)];
			card.Click();*/
            Pages.Home.NavigateToRandomProductPage();

        }

        [Given(@"I navigate to my basket"), When(@"I navigate to my basket")]
        public void GivenINavigateToMyBasket()
        {
            By cart = Pages.Home.Cart;
            IWebElement cartElement = DriverManager.WebDriver.FindElement(cart);
            cartElement.Click();
            //Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        [When(@"I open the page for the (.*)")]
        public void WhenIOpenThePageForTheProduct(string productName)
        {
            /*DriverManager.WebDriver.FindElement(By.XPath($"//a[text()='{productName}']")).Click();*/
            Pages.Home.NavigateToProductPage(productName);
        }

/*        // Moved from product page to home page 
        [When(@"I open the product page for the ""([^""]*)""")]
        public void WhenIOpenTheProductPageForThe(string productName)
        {
            DriverManager.WebDriver.FindElement(By.XPath($"//a[text()='{productName}']")).Click();
        }*/

        [When(@"I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            DriverManager.WebDriver.Navigate().GoToUrl(Pages.Home.url);
        }


		// Added to one above 
        /*[When(@"I navigate to my basket")] 
		public void WhenINavigateToMyBasket()
		{
			By cart = Pages.Home.Cart;
			IWebElement cartElement = DriverManager.WebDriver.FindElement(cart);
			cartElement.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }*/

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


		[Then(@"the ""([^""]*)"" category is available")]
		public void ThenTheCategoryIsAvailable(string category)
		{
            /*Assert.That(DriverManager.WebDriver.FindElements(By.XPath($"//a[text()='{category}']")).Count, Is.EqualTo(1), $"{category} category is not available");*/
            string actualCategory = Pages.Home.IsCategoryAvailable(category);
            Assert.That(actualCategory, Is.EqualTo(category), $"{category} category is not available");
        }
	}
}