using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Application.Elements;
using Roq.Automation.Demo.DemoBlaze.Utilities;

namespace Roq.Automation.Demo.DemoBlaze.Pages
{
	public static class Home
	{
        private static IWebDriver driver => DriverManager.WebDriver;
        public static string url => new("https://www.demoblaze.com/index.html");
        public static ElementWrapper AboutUs => new(driver, By.XPath("//a[text()='About Us']"));
        public static ElementWrapper Cart => new(driver, By.Id("cartur"));
        public static ElementWrapper Contact => new(driver, By.XPath("//a[text()='Contact']"));
        public static ElementWrapper LogIn => new ElementWrapper(driver, By.Id("login2"));
        public static ElementWrapper NameOfCategory(string cateogryName) => new(driver, By.XPath($"//a[text()='{cateogryName}']"));
        public static ElementWrapper NameOfProduct(string productName) => new(driver, By.XPath($"//a[text()='{productName}']"));
        public static ElementWrapper ProductCards => new(driver, By.XPath("//h4[@class='card-title']/a"));
        public static ElementWrapper SignUp => new(driver, By.XPath("//a[@data-target='#signInModal']"));


        public static bool IsCategoryAvailable(string categoryName)
        {
            return NameOfCategory(categoryName).Exists(); 
        }

        public static void NavigateToHomePage()
        {
            DriverManager.WebDriver.Navigate().GoToUrl(url);
        }

        public static void NavigateToRandomProductPage()
        {
            List<IWebElement> cards = driver.FindElements(ProductCards.By).ToList();
            IWebElement card = RandomSelector.SelectRandomElement(cards);
            card.Click();          
        }

        public static void NavigateToProductPage(string productName)
        {
            NameOfProduct(productName).Click();
        }
    }
}
